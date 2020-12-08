using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models.Vehicle
{
    public interface ICarRepository 
    {
        public IEnumerable<Car> GetAll();
        public Car GetId(int id);
        public void Add(Car car);
        public void Remove(Car car);
    }
}
