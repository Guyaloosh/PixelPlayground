﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace ShopWeb.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic to sent email
            return Task.CompletedTask;
        }
    }
}
