using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebProject.Database;
using WebProject.Models;
using WebProject.Models.Users;
using WebProject.Models.Vehicle;
using WebProject.ViewModels;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> userManager { get; }
        private ICarRepository context{ get; }
        private ApplicationContext ApplicationContext { get; }
        public HomeController(UserManager<User> user, ICarRepository application,ApplicationContext applicationcontext)
        {
            userManager = user;
            context = application;
            ApplicationContext = applicationcontext;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var result = await userManager.GetUserAsync(HttpContext.User);
            var user = ApplicationContext.Users.Include(user => user.PassengerCars).FirstOrDefault(p => p.Id == result.Id);

            UserViewModel userViewModel = new UserViewModel() {
                User = user,
            };
  
            return View(userViewModel);
        }
        public async Task<IActionResult> List(string search)
        {
            if (string.IsNullOrWhiteSpace(search)) {
                return View(ApplicationContext.PassengerСars.OrderBy(p => p.Price));
            }
            var cars = await ApplicationContext.PassengerСars.AsNoTracking().ToListAsync();
            var result = cars.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).OrderBy(car => car.Price);

            return View(result);
        }
        public IActionResult Details(string id,string carname) {

            return View(ApplicationContext.PassengerСars
                .Include(p => p.User).FirstOrDefault(p => p.UserId == id && p.Name == carname));
        }

        [Authorize]
        public IActionResult Post() => View();
        [HttpPost]
        public async Task<IActionResult> Post(PassengerCarViewModel model)
        {

            if (ModelState.IsValid){
                var user = await userManager.GetUserAsync(HttpContext.User);
                PassengerCar passengerCar = new PassengerCar(){
                    Name = model.Name,
                    Color = model.Color,
                    BodyWork = model.BodyWork,
                    Description = model.Description,
                    Motor = model.Motor,
                    Price = model.Price,
                    UserId = user.Id,
                    User = user,

                };

                if (model.Image != null){

                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Image.Length);
                    }
                    passengerCar.Image = imageData;
                    context.Add(passengerCar);

                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult StatusCodePageError() => Content("NOT FOUND");
        [Authorize]
        public IActionResult Delete(int id) {
             context.Remove(context.GetId(id));
             return View("Deleted");
        }
        public IActionResult Deleted() => Content("Has been deleted");
        [Authorize]
        public async Task<IActionResult> DeleteUser() {

            var user = await userManager.GetUserAsync(User);
            await userManager.DeleteAsync(user);
            return RedirectToAction("Login","Account");
             
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
