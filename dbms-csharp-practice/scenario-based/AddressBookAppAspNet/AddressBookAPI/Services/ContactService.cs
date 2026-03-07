using AddressBookAPI.Models;
using AddressBookAPI.Services.Logging;
using AddressBookAPI.Services.Cache;
using AddressBookAPI.Services.Queue;

namespace AddressBookAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IApplicationLogger _logger;
        private readonly IRedisService _redisService;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly List<Contact> _contacts = new List<Contact>();
        private int _nextId = 1;

        public ContactService(IApplicationLogger logger, IRedisService redisService, IRabbitMQService rabbitMQService)
        {
            _logger = logger;
            _redisService = redisService;
            _rabbitMQService = rabbitMQService;
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            try
            {
                var cacheKey = "all_contacts";
                var cachedContacts = await _redisService.GetAsync<List<Contact>>(cacheKey);
                
                if (cachedContacts != null)
                {
                    _logger.LogInfo("Contacts retrieved from cache");
                    return cachedContacts;
                }

                _logger.LogInfo("Contacts retrieved from memory");
                await _redisService.SetAsync(cacheKey, _contacts, TimeSpan.FromMinutes(30));
                return _contacts;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error getting all contacts", ex);
                return _contacts;
            }
        }

        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            try
            {
                var cacheKey = $"contact_{id}";
                var cachedContact = await _redisService.GetAsync<Contact>(cacheKey);
                
                if (cachedContact != null)
                {
                    _logger.LogInfo($"Contact {id} retrieved from cache");
                    return cachedContact;
                }

                var contact = _contacts.FirstOrDefault(c => c.Id == id);
                
                if (contact != null)
                {
                    await _redisService.SetAsync(cacheKey, contact, TimeSpan.FromMinutes(30));
                    _logger.LogInfo($"Contact {id} retrieved from memory");
                }
                else
                {
                    _logger.LogWarning($"Contact with ID {id} not found");
                }

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting contact {id}", ex);
                return null;
            }
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            try
            {
                contact.Id = _nextId++;
                _contacts.Add(contact);

                await _redisService.DeleteAsync("all_contacts");
                _rabbitMQService.PublishMessage("contacts", $"Contact created: {contact.FirstName} {contact.LastName}");

                _logger.LogInfo($"Contact created: {contact.FirstName} {contact.LastName}");
                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating contact", ex);
                throw;
            }
        }

        public async Task<Contact?> UpdateContactAsync(int id, Contact contact)
        {
            try
            {
                var existingContact = _contacts.FirstOrDefault(c => c.Id == id);
                
                if (existingContact == null)
                {
                    _logger.LogWarning($"Contact with ID {id} not found for update");
                    return null;
                }

                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Address = contact.Address;
                existingContact.City = contact.City;
                existingContact.State = contact.State;
                existingContact.Zip = contact.Zip;
                existingContact.Phone = contact.Phone;
                existingContact.Email = contact.Email;

                var cacheKey = $"contact_{id}";
                await _redisService.DeleteAsync(cacheKey);
                await _redisService.DeleteAsync("all_contacts");
                _rabbitMQService.PublishMessage("contacts", $"Contact updated: {existingContact.FirstName} {existingContact.LastName}");

                _logger.LogInfo($"Contact updated: {id}");
                return existingContact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating contact {id}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            try
            {
                var contact = _contacts.FirstOrDefault(c => c.Id == id);
                
                if (contact == null)
                {
                    _logger.LogWarning($"Contact with ID {id} not found for deletion");
                    return false;
                }

                _contacts.Remove(contact);

                var cacheKey = $"contact_{id}";
                await _redisService.DeleteAsync(cacheKey);
                await _redisService.DeleteAsync("all_contacts");
                _rabbitMQService.PublishMessage("contacts", $"Contact deleted: {contact.FirstName} {contact.LastName}");

                _logger.LogInfo($"Contact deleted: {id}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting contact {id}", ex);
                return false;
            }
        }
    }
}