using AddressBookAPI.Models;
using AddressBookAPI.Services;
using AddressBookAPI.Services.Logging;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IApplicationLogger _logger;

        public ContactsController(IContactService contactService, IApplicationLogger logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            try
            {
                var contacts = await _contactService.GetAllContactsAsync();
                _logger.LogInfo("Retrieved all contacts");
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving contacts", ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id)
        {
            try
            {
                var contact = await _contactService.GetContactByIdAsync(id);
                
                if (contact == null)
                {
                    _logger.LogWarning($"Contact not found: {id}");
                    return NotFound();
                }

                return Ok(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving contact {id}", ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact([FromBody] Contact contact)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(contact.FirstName) || string.IsNullOrWhiteSpace(contact.LastName))
                {
                    _logger.LogWarning("Invalid contact data");
                    return BadRequest("First name and last name are required");
                }

                var createdContact = await _contactService.CreateContactAsync(contact);
                _logger.LogInfo($"Contact created: {createdContact.Id}");
                return CreatedAtAction(nameof(GetContactById), new { id = createdContact.Id }, createdContact);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating contact", ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateContact(int id, [FromBody] Contact contact)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(contact.FirstName) || string.IsNullOrWhiteSpace(contact.LastName))
                {
                    _logger.LogWarning("Invalid contact data");
                    return BadRequest("First name and last name are required");
                }

                var updatedContact = await _contactService.UpdateContactAsync(id, contact);
                
                if (updatedContact == null)
                {
                    _logger.LogWarning($"Contact not found: {id}");
                    return NotFound();
                }

                _logger.LogInfo($"Contact updated: {id}");
                return Ok(updatedContact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating contact {id}", ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            try
            {
                var result = await _contactService.DeleteContactAsync(id);
                
                if (!result)
                {
                    _logger.LogWarning($"Contact not found: {id}");
                    return NotFound();
                }

                _logger.LogInfo($"Contact deleted: {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting contact {id}", ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
