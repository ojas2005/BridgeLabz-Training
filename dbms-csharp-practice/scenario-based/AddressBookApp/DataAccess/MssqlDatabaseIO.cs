using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AddressBookApp.Interfaces;
using AddressBookApp.Models;
using AddressBookApp.Exceptions;
using AddressBookApp.Utilities;

namespace AddressBookApp.DataAccess
{
    public class MssqlDatabaseIO : IDatabaseIO
    {
        private readonly ThreadSafeLogger _logger = ThreadSafeLogger.Instance;
        private readonly string _connectionString;

        public MssqlDatabaseIO(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null");
        }

        private void InitializeDatabase()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Contacts')
                        BEGIN
                            CREATE TABLE Contacts (
                                Id INT PRIMARY KEY IDENTITY(1,1),
                                FirstName NVARCHAR(100) NOT NULL,
                                LastName NVARCHAR(100) NOT NULL,
                                Address NVARCHAR(255),
                                City NVARCHAR(100),
                                State NVARCHAR(50),
                                Zip NVARCHAR(20),
                                Phone NVARCHAR(20),
                                Email NVARCHAR(100),
                                CONSTRAINT UK_FirstNameLastName UNIQUE(FirstName, LastName)
                            )
                        END";

                    using (var command = new SqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        _logger.Log("MSSQL database table 'Contacts' initialized successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error initializing MSSQL database", ex);
                throw new AddressBookException("Failed to initialize MSSQL database", ex);
            }
        }

        public void SaveContacts(List<ContactPerson> contacts, string databasePath)
        {
            try
            {
                if (contacts == null || contacts.Count == 0)
                {
                    _logger.Log("No contacts to save to database");
                    return;
                }

                InitializeDatabase();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Clear existing contacts
                    string deleteQuery = "DELETE FROM Contacts";
                    using (var command = new SqlCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Insert new contacts
                    string insertQuery = @"
                        INSERT INTO Contacts (FirstName, LastName, Address, City, State, Zip, Phone, Email)
                        VALUES (@firstName, @lastName, @address, @city, @state, @zip, @phone, @email)";

                    foreach (var contact in contacts)
                    {
                        using (var command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@firstName", contact.FirstName ?? "");
                            command.Parameters.AddWithValue("@lastName", contact.LastName ?? "");
                            command.Parameters.AddWithValue("@address", contact.Address ?? "");
                            command.Parameters.AddWithValue("@city", contact.City ?? "");
                            command.Parameters.AddWithValue("@state", contact.State ?? "");
                            command.Parameters.AddWithValue("@zip", contact.Zip ?? "");
                            command.Parameters.AddWithValue("@phone", contact.Phone ?? "");
                            command.Parameters.AddWithValue("@email", contact.Email ?? "");

                            command.ExecuteNonQuery();
                        }
                    }
                }

                _logger.Log($"Contacts saved successfully to MSSQL database");
            }
            catch (SqlException ex)
            {
                _logger.LogError("MSSQL error saving contacts", ex);
                throw new AddressBookException("Failed to save contacts to MSSQL database", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error saving contacts to MSSQL database", ex);
                throw new AddressBookException("Failed to save contacts to MSSQL database", ex);
            }
        }

        public List<ContactPerson> LoadContacts(string databasePath)
        {
            List<ContactPerson> contacts = new List<ContactPerson>();

            try
            {
                InitializeDatabase();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT FirstName, LastName, Address, City, State, Zip, Phone, Email FROM Contacts";

                    using (var command = new SqlCommand(selectQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var contact = new ContactPerson(
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString(),
                                    reader["Address"].ToString(),
                                    reader["City"].ToString(),
                                    reader["State"].ToString(),
                                    reader["Zip"].ToString(),
                                    reader["Phone"].ToString(),
                                    reader["Email"].ToString()
                                );
                                contacts.Add(contact);
                            }
                        }
                    }
                }

                _logger.Log($"Loaded {contacts.Count} contacts from MSSQL database");
            }
            catch (SqlException ex)
            {
                _logger.LogError("MSSQL error loading contacts", ex);
                throw new AddressBookException("Failed to load contacts from MSSQL database", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error loading contacts from MSSQL database", ex);
                throw new AddressBookException("Failed to load contacts from MSSQL database", ex);
            }

            return contacts;
        }

        public void InsertContact(ContactPerson contact, string databasePath)
        {
            try
            {
                if (contact == null)
                    throw new ArgumentNullException(nameof(contact), "Contact cannot be null");

                InitializeDatabase();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string insertQuery = @"
                        INSERT INTO Contacts (FirstName, LastName, Address, City, State, Zip, Phone, Email)
                        VALUES (@firstName, @lastName, @address, @city, @state, @zip, @phone, @email)";

                    using (var command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", contact.FirstName ?? "");
                        command.Parameters.AddWithValue("@lastName", contact.LastName ?? "");
                        command.Parameters.AddWithValue("@address", contact.Address ?? "");
                        command.Parameters.AddWithValue("@city", contact.City ?? "");
                        command.Parameters.AddWithValue("@state", contact.State ?? "");
                        command.Parameters.AddWithValue("@zip", contact.Zip ?? "");
                        command.Parameters.AddWithValue("@phone", contact.Phone ?? "");
                        command.Parameters.AddWithValue("@email", contact.Email ?? "");

                        command.ExecuteNonQuery();
                        _logger.Log($"Contact inserted: {contact.FirstName} {contact.LastName}");
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError("MSSQL error inserting contact", ex);
                throw new AddressBookException("Failed to insert contact into MSSQL database", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error inserting contact into MSSQL database", ex);
                throw new AddressBookException("Failed to insert contact into MSSQL database", ex);
            }
        }

        public void DeleteContact(string firstName, string lastName, string databasePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                    throw new ArgumentException("First name and last name cannot be empty");

                InitializeDatabase();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string deleteQuery = @"
                        DELETE FROM Contacts
                        WHERE FirstName = @firstName AND LastName = @lastName";

                    using (var command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            _logger.Log($"Contact deleted: {firstName} {lastName}");
                        }
                        else
                        {
                            _logger.Log($"Contact not found for deletion: {firstName} {lastName}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError("MSSQL error deleting contact", ex);
                throw new AddressBookException("Failed to delete contact from MSSQL database", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting contact from MSSQL database", ex);
                throw new AddressBookException("Failed to delete contact from MSSQL database", ex);
            }
        }

        public List<ContactPerson> GetContactsByCity(string city, string databasePath)
        {
            List<ContactPerson> contacts = new List<ContactPerson>();

            try
            {
                if (string.IsNullOrWhiteSpace(city))
                    return contacts;

                InitializeDatabase();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string selectQuery = @"
                        SELECT FirstName, LastName, Address, City, State, Zip, Phone, Email
                        FROM Contacts WHERE City = @city";

                    using (var command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@city", city);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var contact = new ContactPerson(
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString(),
                                    reader["Address"].ToString(),
                                    reader["City"].ToString(),
                                    reader["State"].ToString(),
                                    reader["Zip"].ToString(),
                                    reader["Phone"].ToString(),
                                    reader["Email"].ToString()
                                );
                                contacts.Add(contact);
                            }
                        }
                    }
                }

                _logger.Log($"Found {contacts.Count} contacts in city: {city}");
            }
            catch (SqlException ex)
            {
                _logger.LogError("MSSQL error retrieving contacts by city", ex);
                throw new AddressBookException("Failed to retrieve contacts by city", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving contacts by city", ex);
                throw new AddressBookException("Failed to retrieve contacts by city", ex);
            }

            return contacts;
        }

        public List<ContactPerson> GetContactsByState(string state, string databasePath)
        {
            List<ContactPerson> contacts = new List<ContactPerson>();

            try
            {
                if (string.IsNullOrWhiteSpace(state))
                    return contacts;

                InitializeDatabase();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string selectQuery = @"
                        SELECT FirstName, LastName, Address, City, State, Zip, Phone, Email
                        FROM Contacts WHERE State = @state";

                    using (var command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@state", state);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var contact = new ContactPerson(
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString(),
                                    reader["Address"].ToString(),
                                    reader["City"].ToString(),
                                    reader["State"].ToString(),
                                    reader["Zip"].ToString(),
                                    reader["Phone"].ToString(),
                                    reader["Email"].ToString()
                                );
                                contacts.Add(contact);
                            }
                        }
                    }
                }

                _logger.Log($"Found {contacts.Count} contacts in state: {state}");
            }
            catch (SqlException ex)
            {
                _logger.LogError("MSSQL error retrieving contacts by state", ex);
                throw new AddressBookException("Failed to retrieve contacts by state", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving contacts by state", ex);
                throw new AddressBookException("Failed to retrieve contacts by state", ex);
            }

            return contacts;
        }
    }
}
