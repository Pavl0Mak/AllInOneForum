namespace AllInOneForum.Services.Contracts.Models
{
    public class UpSertUserModel : UserBaseModel
    {
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
