using CE.Chepeat.Domain.Aggregates.Email;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface IEmailServiceInfraestructure
{
    Task SendEmailAsync(EmailModel emailModel, string templatePath);
}
