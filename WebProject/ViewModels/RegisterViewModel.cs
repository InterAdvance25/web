using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.CustomValidation;

namespace WebProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Пустая строка")]
        [Display(Name = "Имя")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Пустая строка")]
        [Display(Name = "Фамилия")]
        [DataType(DataType.Text)]
        public string SurName { get; set; }

        [Range(18,120, ErrorMessage = "Вне Диапазона")]
        [Required(ErrorMessage = "Пустая строка")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [EmailValidation(ErrorMessage = "Неккоректный email")]
        [EmailAddress]
        [Required(ErrorMessage = "Пустая строка")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пустая строка")]
        [StringLength(maximumLength:90,MinimumLength = 6,ErrorMessage = "Минимум 6 символов")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пустая строка")]
        [Compare("Password",ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтвердить пароль")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Пустая строка")]
        [Display(Name = "Страна")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Пустая строка")]
        [DataType(DataType.Text)]
        [Display(Name = "Город")]
        public string City { get; set; }

        [PhoneNumberValidation(ErrorMessage = "Только цифры")]
        [StringLength(maximumLength:11, ErrorMessage = "11 цифр")]
        [Required(ErrorMessage = "Пустая строка")]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
