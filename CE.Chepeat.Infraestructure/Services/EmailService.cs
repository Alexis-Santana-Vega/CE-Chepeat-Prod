using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Email;
using MailKit.Net.Smtp;
using MimeKit;
using RazorLight;

namespace CE.Chepeat.Infraestructure.Services;
public class EmailService : IEmailServiceInfraestructure
{
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly string _smtpUser;
    private readonly string _smtpPass;
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        _smtpUser = _configuration["EmailSettings:SmtpUser"];
        _smtpPass = _configuration["EmailSettings:SmtpPass"];
    }
    public async Task SendEmailAsync(EmailModel emailModel, string templatePath)
    {
        // Cargar la plantilla HTML y renderizar con RazorLight
        var templateContent = await File.ReadAllTextAsync(templatePath);
        var engine = new RazorLightEngineBuilder()
            .UseMemoryCachingProvider()
            .Build();

        string emailBody = await engine.CompileRenderStringAsync(templatePath, templateContent, emailModel.ModelData);

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Chepeat", _smtpUser));
        message.To.Add(new MailboxAddress(null, emailModel.To));
        message.Subject = emailModel.Subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = emailBody };
        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();
        await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_smtpUser, _smtpPass);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
