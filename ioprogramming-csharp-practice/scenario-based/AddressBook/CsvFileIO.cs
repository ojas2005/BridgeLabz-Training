using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookApp
{
    public class CsvFileIO : IFileIO
    {
        private readonly ThreadSafeLogger _logger = ThreadSafeLogger.Instance;

        public void SaveContacts(List<ContactPerson> contacts, string filename)
        {
            try
            {
                if (contacts == null || contacts.Count == 0)
                {
                    _logger.Log("No contacts to save");
                    return;
                }

                using (StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8))
                {
                    writer.WriteLine("FirstName,LastName,Address,City,State,Zip,Phone,Email");

                    foreach (var contact in contacts)
                    {
                        string line = $"\"{EscapeCsvField(contact.FirstName)}\",\"{EscapeCsvField(contact.LastName)}\",\"{EscapeCsvField(contact.Address)}\",\"{EscapeCsvField(contact.City)}\",\"{EscapeCsvField(contact.State)}\",\"{EscapeCsvField(contact.Zip)}\",\"{EscapeCsvField(contact.Phone)}\",\"{EscapeCsvField(contact.Email)}\"";
                        writer.WriteLine(line);
                    }
                }

                _logger.Log($"Contacts saved successfully to CSV file: {filename}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving contacts to CSV file: {filename}", ex);
                throw new AddressBookException($"Failed to save contacts to CSV file: {filename}", ex);
            }
        }

        public List<ContactPerson> LoadContacts(string filename)
        {
            List<ContactPerson> contacts = new List<ContactPerson>();

            try
            {
                if (!File.Exists(filename))
                {
                    _logger.Log($"CSV file not found: {filename}");
                    return contacts;
                }

                using (StreamReader reader = new StreamReader(filename, Encoding.UTF8))
                {
                    string headerLine = reader.ReadLine();
                    if (headerLine == null)
                    {
                        _logger.Log("CSV file is empty");
                        return contacts;
                    }

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] parts = ParseCsvLine(line);
                        if (parts.Length == 8)
                        {
                            ContactPerson contact = new ContactPerson(
                                parts[0], parts[1], parts[2], parts[3],
                                parts[4], parts[5], parts[6], parts[7]
                            );
                            contacts.Add(contact);
                        }
                    }
                }

                _logger.Log($"Loaded {contacts.Count} contacts from CSV file: {filename}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading contacts from CSV file: {filename}", ex);
                throw new AddressBookException($"Failed to load contacts from CSV file: {filename}", ex);
            }

            return contacts;
        }

        private string EscapeCsvField(string field)
        {
            if (field == null)
                return "";
            return field.Replace("\"", "\"\"");
        }

        private string[] ParseCsvLine(string line)
        {
            List<string> fields = new List<string>();
            StringBuilder currentField = new StringBuilder();
            bool insideQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    if (insideQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        currentField.Append('"');
                        i++;
                    }
                    else
                    {
                        insideQuotes = !insideQuotes;
                    }
                }
                else if (c == ',' && !insideQuotes)
                {
                    fields.Add(currentField.ToString().Trim());
                    currentField.Clear();
                }
                else
                {
                    currentField.Append(c);
                }
            }

            fields.Add(currentField.ToString().Trim());
            return fields.ToArray();
        }
    }
}
