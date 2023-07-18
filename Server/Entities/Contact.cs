using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts.Server.Entities
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int HouseNumber { get; set; }
        public string? HouseName { get; set; }
        public string? PostCode { get; set; }
    }
}
