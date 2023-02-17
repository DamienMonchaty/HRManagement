using HRManagement.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Business.Services
{
    public interface IMailingService
    {
        void Send(string to, string subject, MailContentDTO model);

        void SendSimple(string to, string subject, string messageContent);
    }
}
