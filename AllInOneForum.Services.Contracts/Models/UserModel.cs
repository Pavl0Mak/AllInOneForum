﻿namespace AllInOneForum.Services.Contracts.Models
{
    public class UserModel : UserBaseModel
    {
        public int Id { get; set; }
        public RoleModel Role { get; set; }
    }
}
