#nullable disable
using AllInOneForum;

namespace AllInOneForum.Services.Contracts.Models
{
    public abstract class UserBaseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
