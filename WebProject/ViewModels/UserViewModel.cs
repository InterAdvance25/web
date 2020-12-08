using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;
using WebProject.Models.Users;
using WebProject.Models.Vehicle;

namespace WebProject.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<PassengerCar> PassengerCars { get; set; }
        public User User { get; set; }

    }
}
