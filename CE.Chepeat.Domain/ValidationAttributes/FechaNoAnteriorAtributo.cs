using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.ValidationAttributes;
public class FechaNoAnteriorAtributo : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime fecha && fecha < DateTime.UtcNow)
        {
            return new ValidationResult("La fecha no puede ser anterior a la fecha actual.");
        }
        return ValidationResult.Success;
    }
}

