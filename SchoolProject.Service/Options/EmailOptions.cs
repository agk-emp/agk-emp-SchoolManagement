﻿namespace SchoolProject.Service.Options
{
    public class EmailOptions
    {

        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}