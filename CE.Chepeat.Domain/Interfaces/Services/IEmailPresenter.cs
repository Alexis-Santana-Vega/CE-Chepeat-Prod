using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Interfaces.Services;
public interface IEmailPresenter
{
    Task SendEmailAsync(string to);
}
