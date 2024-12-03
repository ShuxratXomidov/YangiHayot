﻿using System.ComponentModel.DataAnnotations;

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
        public string Password { get; set; } 
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        
    }
}