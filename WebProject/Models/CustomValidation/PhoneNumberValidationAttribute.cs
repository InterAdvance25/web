using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models.CustomValidation
{
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) => long.TryParse((string)value, out long n);
    }
}
