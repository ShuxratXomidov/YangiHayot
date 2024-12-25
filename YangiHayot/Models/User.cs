using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using YangiHayot.Services;

namespace YangiHayot.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; } = new byte[32];

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int RoleId { get; set; }
        //public Role Role { get; set; }
        
    }
}
