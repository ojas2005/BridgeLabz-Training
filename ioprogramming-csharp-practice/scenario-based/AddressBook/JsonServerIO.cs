using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AddressBookApp
{
    public class JsonServerIO : IFileIO
    {
        private readonly ThreadSafeLogger _logger = ThreadSafeLogger.Instance;
        private readonly string _serverUrl;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public JsonServerIO(string serverUrl = "http://localhost:3000")
        {
            _serverUrl = serverUrl;
            _httpClient = new HttpClient();
        }

        public void SaveContacts(List<ContactPerson> contacts, string filename)
        {
            try
            {
                if (contacts == null || contacts.Count == 0)
                {
                    _logger.Log("No contacts to save to JSON server");
                    return;
                }

                Task.Run(async () =>
                {
                    await SaveContactsAsync(contacts, filename);
                }).Wait();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving contacts to JSON server", ex);
                throw new AddressBookException($"Failed to save contacts to JSON server", ex);
            }
        }

        public List<ContactPerson> LoadContacts(string filename)
        {
            List<ContactPerson> contacts = new List<ContactPerson>();

            try
            {
                Task.Run(async () =>
                {
                    contacts = await LoadContactsAsync(filename);
                }).Wait();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading contacts from JSON server", ex);
                throw new AddressBookException($"Failed to load contacts from JSON server", ex);
            }

            return contacts;
        }

        private async Task SaveContactsAsync(List<ContactPerson> contacts, string resourceName)
        {
            try
            {
                string url = $"{_serverUrl}/{resourceName}";
                
                foreach (var contact in contacts)
                {
                    string jsonContent = JsonSerializer.Serialize(contact, _jsonOptions);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.Log($"Failed to save contact to server: HTTP {response.StatusCode}");
                    }
                }

                _logger.Log($"Contacts saved successfully to JSON server at {url}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during async save to JSON server", ex);
                throw;
            }
        }

        private async Task<List<ContactPerson>> LoadContactsAsync(string resourceName)
        {
            List<ContactPerson> contacts = new List<ContactPerson>();

            try
            {
                string url = $"{_serverUrl}/{resourceName}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.Log($"Failed to load contacts from server: HTTP {response.StatusCode}");
                    return contacts;
                }

                string jsonContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    _logger.Log("No contacts returned from JSON server");
                    return contacts;
                }

                contacts = JsonSerializer.Deserialize<List<ContactPerson>>(jsonContent) ?? new List<ContactPerson>();
                _logger.Log($"Loaded {contacts.Count} contacts from JSON server at {url}");
            }
            catch (JsonException ex)
            {
                _logger.LogError($"Invalid JSON format from server", ex);
                throw new DataValidationException($"Invalid JSON format from server", ex);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"HTTP error connecting to JSON server", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during async load from JSON server", ex);
                throw;
            }

            return contacts;
        }
    }
}
