using System;
using System.Collections.Generic;
using System.IO;
using AddressBookApp.Interfaces;
using AddressBookApp.Models;
using AddressBookApp.Exceptions;
using AddressBookApp.Utilities;

namespace AddressBookApp.DataAccess
{
    public class TextFileIO : IFileIO
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

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (var contact in contacts)
                    {
                        string line = $"{contact.FirstName}|{contact.LastName}|{contact.Address}|{contact.City}|{contact.State}|{contact.Zip}|{contact.Phone}|{contact.Email}";
                        writer.WriteLine(line);
                    }
                }

                _logger.Log($"Contacts saved successfully to {filename}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving contacts to file: {filename}", ex);
                throw new AddressBookException($"Failed to save contacts to file: {filename}", ex);
            }
        }

        public List<ContactPerson> LoadContacts(string filename)
        {
            List<ContactPerson> contacts = new List<ContactPerson>();

            try
            {
                if (!File.Exists(filename))
                {
                    _logger.Log($"File not found: {filename}");
                    return contacts;
                }

                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] parts = line.Split('|');
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

                _logger.Log($"Loaded {contacts.Count} contacts from {filename}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading contacts from file: {filename}", ex);
                throw new AddressBookException($"Failed to load contacts from file: {filename}", ex);
            }

            return contacts;
        }
    }
}
