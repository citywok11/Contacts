using Contacts.Server.Config;
using Contacts.Server.Entities;
using Contacts.Server.Repositories;
using Contacts.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

public class ContactsRepository : IContactsRepository
{
    private readonly ContactsDbContext _context;
    private readonly ILogger<ContactsRepository> _logger;

    public ContactsRepository(ContactsDbContext context, ILogger<ContactsRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Contact>> GetAllAsync()
    {
        try
        {
            return await _context.Set<Contact>().ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all contacts");
            throw;
        }
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Set<Contact>().FindAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting contact with ID {Id}", id);
            throw;
        }
    }

    public async Task AddAsync(Contact contact)
    {
        try
        {
            await _context.Set<Contact>().AddAsync(contact);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while adding a new contact");
            throw;
        }
    }

    public async Task UpdateAsync(Contact contact)
    {
        try
        {
            var existingContact = await _context.Contacts.FindAsync(contact.ContactID);

            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                existingContact.PhoneNumber = contact.PhoneNumber;
                existingContact.HouseNumber = contact.HouseNumber;
                existingContact.HouseName = contact.HouseName;
                existingContact.PostCode = contact.PostCode;

                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating contact with ID {Id}", contact.ContactID);
            throw;
        }
    }
}
