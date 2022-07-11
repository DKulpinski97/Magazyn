using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using zad.deliver;
using zad.hangar;

namespace zad.wraiting
{
   public class Wraiting
    {
        public void packageToBePickedUp(List<Packages> recoveredPackage)
        { int i = 0;
            Console.WriteLine("Paczki do przydzielenia do samochodów");
            foreach(var x in recoveredPackage)
            {
                
                Console.Write(x.IdPackage + "   ");
                if (i == 15)
                {
                    Console.WriteLine();
                    i = 0;
                }
                i++;
            }
        }
        public void packageInCar(List<Packages> listCollectPackage)
        {
            int i = 0;
            Console.WriteLine("Paczki przydzielone do samochodów");
            foreach (var x in listCollectPackage)
            {

                Console.Write(x.IdPackage + "   ");
                if (i == 15)
                {
                    Console.WriteLine();
                    i = 0;
                }
                i++;
            }
        }
        public void AgriculturalMachineryToBePickedUp(List<Machinery> listMachinery)
        {
            
            Console.WriteLine('\n'+"Maszyny do załadowania");
            foreach (var x in listMachinery)
            {
                if(x.status== "Do zaladowania")
                {
                    Console.Write(x.AgriculturalMachineryWeight + "  ");
                }


            }
        }
        public void PackageInCar(List<Car> listCar)
        {
            int idCar = 0;
            Console.WriteLine('\n' + "Paczki przypisywane do samochodów");
            foreach(var x in listCar)
            {
                
                Console.WriteLine("Paczki w samochodzie " + idCar + '\n');
                foreach(var z in x.IdPackage)
                {
                    Console.Write(z + " ");
                }
                idCar++;
                Console.WriteLine();
            }

        }
        public void AgriculturalMachineryInAirplan(List<Machinery> listMachinery)
        {
            Console.WriteLine('\n'+"Maszyny rolnicze załadowane w samolocie");
            foreach(var x in listMachinery)
            {
                if(x.status== "Załadowana")
                {
                    Console.Write(x.AgriculturalMachineryWeight + " ");
                }
                
            }

        }
        public void Menu(List<Packages> recoveredPackage, List<Machinery> listMachinery, List<Car> listCar)
        {
            packageToBePickedUp(recoveredPackage);
            AgriculturalMachineryToBePickedUp(listMachinery);
            PackageInCar(listCar);
            AgriculturalMachineryInAirplan(listMachinery);
            Console.WriteLine('\n'+"Menu");
            Console.WriteLine("1 - odbierz dostawy");
            Console.WriteLine("2 - Automatycznie rozdziel dostawę do samochodów i samolotu");
            Console.WriteLine("3 - Ręczne przypisywanie paczek");
            Console.WriteLine("4 - Ręczne przypisywanie maszyny do samolotu");
            Console.WriteLine("5 - Odnajdź paczkę");
            Console.WriteLine("6 - Zatwierdź i wyślij dostawę");
            Console.WriteLine("7 - Zamknij program");

        }
        public void Menu2()
        {
            Console.WriteLine('\n' + "Menu");
            Console.WriteLine("1 - Dodaj paczkę do samochodu");
            Console.WriteLine("2 - Usuń paczke z samochodu");
            Console.WriteLine("3 - Powrut do poprzedniego menu");

        }
        public void Menu3()
        {
            Console.WriteLine('\n' + "Menu");
            Console.WriteLine("1 - Przenieś maszyne do samolotu");
            Console.WriteLine("2 - Usuń paczkę z samochodu");
            Console.WriteLine("3 - Powrót do poprzedniego menu");

        }
        public void Menu4()
        {
            Console.WriteLine('\n' + "Menu");
            Console.WriteLine("1 - Odszukaj paczkę");
            Console.WriteLine("2 - Powrót do poprzedniego menu");

        }
        public void error()
        {
            Console.Clear();
            Console.WriteLine("Należy najpierw wygenerować dostawę");
            Thread.Sleep(4000);
        }
        public void error2()
        {
            Console.Clear();
            Console.WriteLine("Nie można wygenerować nowej dostawy nim poprzednią nie zostanie wysłana");
            Thread.Sleep(4000);
        }
    }
}
