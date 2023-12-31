﻿using AllInOneForum.DataAccess.Contracts.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AllInOneForum.DataAccess.Contracts.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public int RoleId { get; set; } 
    }
}