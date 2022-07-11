using System;
using System.Collections.Generic;
using System.Text;
using zad.hangar;

namespace zad.deliver
{
    public class Delivery
    {
        int idPackage = 0;
        public Delivery()
        {

        }
        public List<Packages> GeneratePackages(int howMenyPackage)
        {
            Random weight = new Random();
            List<Packages> recoveredPackage = new List<Packages>();
            Packages package;
            for (int i = 0; i < howMenyPackage; i++)
            {
                package = new Packages(idPackage, (float)Math.Round((float)weight.NextDouble() + (float)weight.Next(10, 20), 2), -1);
                recoveredPackage.Add(package);
                idPackage++;
            }
            return recoveredPackage;
        }
    }
}
