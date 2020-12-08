using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Database;
using WebProject.Models.Users;

namespace WebProject.Models.Vehicle
{
    public class PassengerCar : Car
    {
        public string Description { get; set; }
        public string BodyWork { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public byte[] Image { get; set; }
        public override string Type => "PassengerCar";
    }
}
