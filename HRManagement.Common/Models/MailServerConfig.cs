using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Common.Models
{
    public class MailServerConfig
    {
        public string FromAddress { get; set; }
        public string ServerAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool IsUseSsl { get; set; }
    }
}
