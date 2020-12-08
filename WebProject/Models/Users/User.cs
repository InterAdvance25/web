using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models.Vehicle;

namespace WebProject.Models.Users
{
    public class User : IdentityUser
    {
        public string SurName { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public IEnumerable<PassengerCar> PassengerCars { get; set; }
        
    }
}
