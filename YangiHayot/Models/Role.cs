using System.ComponentModel.DataAnnotations;

namespace YangiHayot.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(2)]
        public string Name { get; set; }
    }
}
