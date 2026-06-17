using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AddressBookApp.Interfaces;
using AddressBookApp.Models;
using AddressBookApp.Exceptions;
using AddressBookApp.Utilities;

namespace AddressBookApp.DataAccess
{
    public class JsonFileIO : IFileIO
    {
        private readonly ThreadSafeLogger _logger = ThreadSafeLogger.Instance;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public void SaveContacts(List<ContactPerson> contacts, string filename)
        {
            try
            {
                if (contacts == null || contacts.Count == 0)
                {
                    _logger.Log("No contacts to save");
                    return;
                }

                string jsonContent = JsonSerializer.Serialize(contacts, _jsonOptions);

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.Write(jsonContent);
                }

                _logger.Log($"Contacts saved successfully to JSON file: {filename}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving contacts to JSON file: {filename}", ex);
                throw new AddressBookException($"Failed to save contacts to JSON file: {filename}", ex);
            }
        }

        public List<ContactPerson> LoadContacts(string filename)
        {
            List<ContactPerson> contacts = new List<ContactPerson>();

            try
            {
                if (!File.Exists(filename))
                {
                    _logger.Log($"JSON file not found: {filename}");
                    return contacts;
                }

                string jsonContent;
                using (StreamReader reader = new StreamReader(filename))
                {
                    jsonContent = reader.ReadToEnd();
                }

                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    _logger.Log("JSON file is empty");
                    return contacts;
                }

                contacts = JsonSerializer.Deserialize<List<ContactPerson>>(jsonContent) ?? new List<ContactPerson>();
                _logger.Log($"Loaded {contacts.Count} contacts from JSON file: {filename}");
            }
            catch (JsonException ex)
            {
                _logger.LogError($"Invalid JSON format in file: {filename}", ex);
                throw new DataValidationException($"Invalid JSON format in file: {filename}", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading contacts from JSON file: {filename}", ex);
                throw new AddressBookException($"Failed to load contacts from JSON file: {filename}", ex);
            }

            return contacts;
        }
    }
}
