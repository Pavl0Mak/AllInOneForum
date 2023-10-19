using AllInOneForum.DataAccess.Contracts.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AllInOneForum.DataAccess.Contracts.Models
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public int AccessLevel { get; set; }
    }
}
