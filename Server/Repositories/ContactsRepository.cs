using Contacts.Server.Entities;
using Contacts.Server.Repositories;
using Contacts.Shared.Models;
using Microsoft.EntityFrameworkCore;

public class ContactsRepository : IContactsRepository
{
    private readonly DbContext _context;

    public ContactsRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<List<Contact>> GetAllAsync()
    {
        return await _context.Set<Contact>().ToListAsync();
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        return await _context.Set<Contact>().FindAsync(id);
    }

    public async Task AddAsync(Contact contact)
    {
        await _context.Set<Contact>().AddAsync(contact);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Contact contact)
    {
        _context.Entry(contact).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var contact = await GetByIdAsync(id);
        if (contact != null)
        {
            _context.Set<Contact>().Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
