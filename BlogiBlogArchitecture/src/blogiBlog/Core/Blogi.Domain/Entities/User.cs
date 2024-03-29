﻿using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class User : BaseDomainEntity
    {
        public User() { }
        
        public User(int id, string name, string surname, string password, string email, byte[] photo):base(id)
        {             
            Name = name;
            Surname = surname;
            Password = password;
            Email = email;
            Photo = photo;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
    }
}