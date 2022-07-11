using System;
using System.Collections.Generic;
using System.Text;

namespace zad.hangar
{
    public class Packages
    {
        public int IdPackage { get; set; }
        public float WaightPackage { get; set; }
        public int  IdCar { get; set; }
        public Packages(int idPackage, float waightPackage,int idCar)
        {
            IdPackage = idPackage;
            WaightPackage = waightPackage;
            IdCar = idCar;
        }
    }
}
