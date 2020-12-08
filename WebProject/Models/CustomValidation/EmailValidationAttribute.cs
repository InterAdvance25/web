using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models.CustomValidation
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) => ((string)value).EndsWith("@mail.ru");

    }
}
