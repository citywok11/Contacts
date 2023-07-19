using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Contacts.Shared.Models;

namespace Contacts.Client.Services
{
    public class ContactsService : IContactsService
    {
        private readonly HttpClient _httpClient;

        public ContactsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ContactsResponse>> GetContactsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ContactsResponse>>("Contacts");
        }

        public async Task AddContactAsync(ContactsModel contact)
        {
            var response = await _httpClient.PostAsJsonAsync("Contacts", contact);
            response.EnsureSuccessStatusCode();
        }

        public async Task EditContactASync(ContactsModel contact)
        {
            var response = await _httpClient.PutAsJsonAsync("Contacts", contact);
            response.EnsureSuccessStatusCode();
        }
    }
}