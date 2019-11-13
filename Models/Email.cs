using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyzeImageAPI.Models
{
    public class Email
    {
        private readonly IConfiguration config;

        public Email(IConfiguration config)
        {
            this.config = config;
        }

        public async Task Execute(string email)
        {
            var sendgridapiKey = config.GetSection("API:SendGridAPI:SENDGRID_API_KEY").Value;
            var client = new SendGridClient(sendgridapiKey);
            var from = new EmailAddress("franklinezeji@gmail.com", "Franklin Ezeji");
            var subject = "IMAGE ANALYSIS RESULT";
            var to = new EmailAddress(email);
            var body = "Hi there, please find attached text-file showing analysis of your image in JSON format.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, "");

            using (var fileStream = File.OpenRead(@"C:\Users\AnalyzedImage.txt"))
            {
                await msg.AddAttachmentAsync("AnalyzedImage.txt", fileStream);
                var response = await client.SendEmailAsync(msg);
            }
        }

    }
}
