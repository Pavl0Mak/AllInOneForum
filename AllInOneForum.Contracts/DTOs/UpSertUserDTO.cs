using AllInOneForum.Contracts.Atributes;

namespace AllInOneForum.Contracts.DTOs
{
    public class UpSertUserDTO : UserBaseDTO
    {
        [OptionalParameter]
        public string Name { get; set; }
    }
}
