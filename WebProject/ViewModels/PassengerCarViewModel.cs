using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.ViewModels
{
    public class PassengerCarViewModel
    {
        [Required(ErrorMessage = "Пустая строка")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пустая строка")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Пустая строка")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Пустая строка")]
        public string Motor { get; set; }
        [Required(ErrorMessage = "Пустая строка")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Пустая строка")]
        public string BodyWork { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
