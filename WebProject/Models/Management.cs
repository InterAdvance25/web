using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public abstract class Management
    {
        protected abstract Car GetCarId(int id);
        protected abstract IEnumerable<Car> GetCarList();
        protected abstract void AddCarToDatabase(Car car);
        protected abstract void RemoveCarFromDatabase(Car car);
        
    }
}
