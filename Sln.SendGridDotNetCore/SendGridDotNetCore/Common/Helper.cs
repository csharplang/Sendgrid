using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace SendGridDotNetCore.Common
{
    public static class Helper
    {
        public static async Task<Tuple<string, string, string>> SendEmailUsingSendGrid()
        {
            try
            {
                var apiKey = EmailComponents.apiKey;
                var client = new SendGridClient(apiKey);
                var messageEmail = new SendGridMessage()
                {
                    From = new EmailAddress(EmailComponents.fromEmail, EmailComponents.fromEmaliUserName),
                    Subject = EmailComponents.Subject,
                    PlainTextContent = EmailComponents.plainTextContent,
                    HtmlContent = EmailComponents.htmlContent
                };
                messageEmail.AddTo(new EmailAddress(EmailComponents.emailTo, EmailComponents.emailToUserName));
                var response = await client.SendEmailAsync(messageEmail);

                return new Tuple<string, string, string>(response.StatusCode.ToString(), 
                    response.Headers.ToString(), 
                    response.Body.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //General v3 Web API Usage
        public static async Task<string> Generalv3WebAPIUsage()
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var queryParams = @"{'limit': 100}";
            var response = await client.RequestAsync(method: SendGridClient.Method.GET,
                                                     urlPath: "suppression/bounces",
                                                     queryParams: queryParams);
            return response.StatusCode.ToString();
        }



        public static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("test@example.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public static async Task ExecuteAdv()
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("test@example.com", "DX Team"),
                Subject = "Sending with SendGrid is Fun",
                PlainTextContent = "and easy to do anywhere, even with C#",
                HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
            };
            msg.AddTo(new EmailAddress("test@example.com", "Test User"));
            var response = await client.SendEmailAsync(msg);
        }

    }
}
