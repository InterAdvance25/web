using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Database;
using WebProject.Models.Vehicle;

namespace WebProject.Models
{
    public class ManagementPassengerCar : Management, ICarRepository
    {
        private ApplicationContext context { get; }
        public ManagementPassengerCar(ApplicationContext applicationContext) => context = applicationContext;
        public void Add(Car car) => AddCarToDatabase(car);
        public IEnumerable<Car> GetAll() => GetCarList();

        public Car GetId(int id) => GetCarId(id);

        public void Remove(Car car) => RemoveCarFromDatabase(car);

        protected override void AddCarToDatabase(Car car)
        {
            PassengerCar passengerCar = car as PassengerCar;
            context.PassengerСars.Add(passengerCar);
            context.SaveChanges();
        }

        protected override Car GetCarId(int id) => context.PassengerСars.Find(id);

        protected override IEnumerable<Car> GetCarList() => context.PassengerСars;

        protected override void RemoveCarFromDatabase(Car car) {
            PassengerCar passengerCar = car as PassengerCar;
            context.PassengerСars.Remove(passengerCar);
            context.SaveChangesAsync();
        }
    }
}
