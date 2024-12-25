using System.ComponentModel.DataAnnotations;

namespace YangiHayot.Requests
{
    public class UserRequest
    {
       [Required]
       [MaxLength(25)]
       [MinLength(2)]
       public string FirstName {  get; set; }

       [Required]
       [MaxLength(20)]
       [MinLength(2)]
       public string LastName { get; set; }

       [Phone]
       public string PhoneNumber {  get; set; }

       [MaxLength(25)]
       [EmailAddress]
       public string Email { get; set; }

       [MinLength(8)]
       public string Password {  get; set; } 
       public int RoleId { get; set; }
    }
}
