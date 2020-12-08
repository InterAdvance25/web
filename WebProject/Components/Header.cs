using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Components
{
    public class Header : ViewComponent
    {
        public IViewComponentResult Invoke() => View("Header");
    }
}
