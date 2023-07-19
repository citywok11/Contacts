namespace Contacts.Server.Repositories;

using Contacts.Server.Entities;
using Contacts.Shared.Models;

public interface IContactsRepository
{
    Task<List<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task AddAsync(Contact contact);
    Task UpdateAsync(Contact contact);
}