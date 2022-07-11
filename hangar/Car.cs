using System;
using System.Collections.Generic;
using System.Text;

namespace zad.hangar
{
    public class Car
    {
        public List<int> IdPackage { get; set; }
        public float ActualWeight { get; set; }
        public Car()
        {
            IdPackage = new List<int>();
            ActualWeight = 0;
        }
        public List<Car> generationCar()
        {
            List<Car> listCar = new List<Car>();
            Car car;
            for (int i=0;i<4;i++)
            {
                car = new Car();
                listCar.Add(car);
            }
            return listCar;
        }
    }
}
