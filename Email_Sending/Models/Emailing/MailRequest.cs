﻿namespace Email_Sending.Models.Emailing
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attacgments { get; set; }
    }
}
