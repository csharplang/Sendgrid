# Sendgrid ASP.NET core Implementations Details

# Overview 
This library allows you to quickly and easily use the SendGrid Web API v3 via C# with .NET.  Version 9.X.X+ of this library provides full support for all SendGrid Web API v3 endpoints, including the new v3 /mail/send.  

<br /> 
We want this library to be community driven, and SendGrid led. We need your help to realize this goal. To help make sure we are building the right things in the right order, we ask that you create issues and pull requests or simply upvote or comment on existing issues or pull requests.  For updates to this library, see our CHANGELOG and releases.  Subscribe to email release notifications to receive emails about releases and breaking changes. <br />


### Nuget
Install-Package SendGrid <br />


### Setup Environment Variables using CMD:
01. Run CMD as administrator <br />
02. > setx SENDGRID_API_KEY "YOUR_API_KEY" <br />

### Environment Variable
Get <br />
var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY"); <br />
Set Environment Variable <br />
var setKey = Environment.SetEnvironmentVariable("SENDGRID_API_KEY", "YOUR_API_KEY"); <br /><br />

###  Code Snippet
```csharp
public async Task<Tuple<string, string, string>> Execute(string filePath)
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
        var bytes = File.ReadAllBytes(filePath);
        var file = Convert.ToBase64String(bytes);
        messageEmail.AddAttachment("Voucher Details Report.pdf", file);


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
```



###  Send Mail UI
![SendMailUI](https://github.com/csharplang/Sendgrid/blob/master/Sln.SendGridDotNetCore/SendGridDotNetCore/README/Resources/SendMailUI.png)



###  Mail Sending
![Code Snippet](https://github.com/csharplang/Sendgrid/blob/master/Sln.SendGridDotNetCore/SendGridDotNetCore/README/Resources/MailSending.png)



### Sendgrid API Status
![Code Snippet](https://github.com/csharplang/Sendgrid/blob/master/Sln.SendGridDotNetCore/SendGridDotNetCore/README/Resources/SendMailStatus.png)


### Sendgrid API variable setup using ASP.NET resource file
![Email components-resouce files](https://github.com/csharplang/Sendgrid/blob/master/Sln.SendGridDotNetCore/SendGridDotNetCore/README/Resources/Email%20components-resouce%20files.png)


### Add Attachment
```C#
    var messageEmail = new SendGridMessage();
    var bytes = File.ReadAllBytes(filePath);
    var file = Convert.ToBase64String(bytes);
    messageEmail.AddAttachment("Voucher Details Report.pdf", file);
```

