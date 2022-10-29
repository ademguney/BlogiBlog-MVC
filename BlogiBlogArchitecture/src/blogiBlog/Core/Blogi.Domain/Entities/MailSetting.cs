﻿using Core.Persistence.Common;

namespace Blogi.Domain.Entities
{
    public class MailSetting : BaseDomainEntity
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool SslEnabled { get; set; }
        public bool UseDefaultCredentials { get; set; }

    }
}