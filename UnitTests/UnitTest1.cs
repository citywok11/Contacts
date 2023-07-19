using Contacts.Server.Config;
using Contacts.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    public class Tests
    {
        private ContactsRepository _contactsRepository;

        [SetUp]
        public void SetUp()
        {
            // Set up a mock DbContext
            var options = new DbContextOptionsBuilder<ContactsDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var context = new ContactsDbContext(options);

            // Create an instance of the ContactsRepository
            _contactsRepository = new ContactsRepository(context);
        }


        [Test]
        public async Task GetAllAsync_ReturnsAllContacts()
        {
            // Arrange
            var contact1 = new Contact { FirstName = "John", LastName = "Testington" };
            var contact2 = new Contact { FirstName = "Joe", LastName = "Testington" };
            await _contactsRepository.AddAsync(contact1);
            await _contactsRepository.AddAsync(contact2);

            // Act
            var result = await _contactsRepository.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task UpdateAsync_UpdatesExistingContact()
        {
            // Arrange
            var contact = new Contact { FirstName = "Mike", LastName = "Testington" };
            await _contactsRepository.AddAsync(contact);

            // Act
            contact.FirstName = "Mike";
            await _contactsRepository.UpdateAsync(contact);

            // Assert
            var updatedContact = await _contactsRepository.GetByIdAsync(contact.ContactID);
            Assert.AreEqual("Mike", updatedContact.FirstName);
        }

        [Test]
        public async Task UpdateAsync_DoesNotUpdateNonExistingContact()
        {
            // Arrange
            var contact = new Contact { ContactID = 999, FirstName = "John", LastName = "Doe" };

            // Act
            await _contactsRepository.UpdateAsync(contact);

            // Assert
            var nonExistingContact = await _contactsRepository.GetByIdAsync(contact.ContactID);
            Assert.IsNull(nonExistingContact);
        }

    }
}