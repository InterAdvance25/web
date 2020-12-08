using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Пустая строка")]
        [EmailAddress(ErrorMessage = "Не валидный Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пустая строка")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }

    }
}
