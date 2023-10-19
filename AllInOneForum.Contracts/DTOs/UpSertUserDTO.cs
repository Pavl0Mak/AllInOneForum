using AllInOneForum.Contracts.Atributes;
using System.ComponentModel.DataAnnotations;

namespace AllInOneForum.Contracts.DTOs
{
    public class UpSertUserDTO : UserBaseDTO
    {
        [OptionalParameter]
        public string Name { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
