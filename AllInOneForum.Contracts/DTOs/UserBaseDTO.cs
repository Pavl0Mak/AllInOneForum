#nullable disable
using System.ComponentModel.DataAnnotations;

namespace AllInOneForum.Contracts.DTOs
{
    public abstract class UserBaseDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
