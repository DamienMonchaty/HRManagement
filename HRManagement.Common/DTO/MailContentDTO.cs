using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Common.DTO
{
    public class MailContentDTO
    {
        public LinkedResource HeaderImage { get; set; }
        public string HtmlContent { get; set; }
        public LinkedResource FooterImage { get; set; }
        public LinkedResource Attachment { get; set; }
    }

    public class LinkedResource
    {
        public string ContentId { get; set; }
        public string ContentPath { get; set; }
        public string ContentType { get; set; }
        public byte[] ContentBytes { get; set; }
    }
}
