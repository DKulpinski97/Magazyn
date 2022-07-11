using System;
using System.Collections.Generic;
using System.Threading;
using zad.control;
using zad.deliver;
using zad.hangar;
using zad.wraiting;

namespace zad
{
    class Program
    {
        static void Main(string[] args)
        {
            Random howMenyPackage = new Random();
            Delivery generatePackages = new Delivery();
            Machinery machinary;
            Hangar hangar = new Hangar();
            Car car = new Car();
            AutomaticControl automaticControl = new AutomaticControl();
            ManualControl manualControl = new ManualControl();
            Wraiting wraiting = new Wraiting();

            //Dostarczenie paczek, maszyn i samochodów do przeładunku
            List<Packages> recoveredPackage = new List<Packages>();
            List<Car> listCar = new List<Car>();
            List<Packages> listCollectPackage = new List<Packages>() ;
            List<Packages> listCollectPackageCopy = new List<Packages>();
            List<Machinery> listMachinery = new List<Machinery>();
            /*recoveredPackage = generatePackages.GeneratePackages(howMenyPackage.Next(5,41));
            listCar = car.generationCar();
            listMachinery.Add(machinary = new Machinery((float)1.5));
            listMachinery.Add(machinary = new Machinery((float)2));*/

            //Wypisywanie
            /*wraiting.packageToBePickedUp(recoveredPackage);
            wraiting.AgriculturalMachineryToBePickedUp(listMachinery);*/

            //automatyczna kontrola
            //automaticControl.automatic(listCollectPackage, recoveredPackage, listCar, listMachinery);
           /* hangar.manualSortPackages(recoveredPackage, listCar, 0, 0);
            wraiting.PackageInCar(listCar);
            wraiting.AgriculturalMachineryInAirplan(listMachinery);*/
            /* foreach (var x in recoveredPackage)
             {
                 Console.WriteLine(x.WaightPackage);
             }*/
            
            // string order = Console.ReadLine();

            //int order = int.Parse(number);


            
            wraiting.Menu(recoveredPackage, listMachinery, listCar);
            bool tmp = false;
            while (tmp!=true)
            {
                Console.WriteLine("Wybierz polecenie ");
                string order = Console.ReadLine();
                switch (order)
                {
                    case "1":
                        Console.Clear();
                        if (listCar.Count == 0)
                        {
                            recoveredPackage = generatePackages.GeneratePackages(howMenyPackage.Next(5, 41));
                            listCar = car.generationCar();
                            listMachinery.Add(machinary = new Machinery((float)1.5));
                            listMachinery.Add(machinary = new Machinery((float)2));
                                                    }
                        else
                        {
                            wraiting.error2();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        if (listCar.Count != 0)
                        {
                            //Dodano kopie listy z powodu możliwości usunięcia zawartości oryginału po ponownym automatycznym sortowanu problem rozwiązany
                            listCollectPackageCopy = automaticControl.automatic(listCollectPackage, recoveredPackage, listCar, listMachinery);
                            foreach(var x in listCollectPackageCopy)
                            {
                                listCollectPackage.Add(x);
                            }
                        }
                        else
                        {
                            wraiting.error();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        if (listCar.Count != 0)
                        {
                            manualControl.control(recoveredPackage, listCar, listCollectPackage);
                        }
                        else
                        {
                            wraiting.error();
                        }
                        break;
                    case "4":
                        Console.Clear();
                        if (listCar.Count != 0)
                        {
                            manualControl.mahinControl(listMachinery);
                        }
                        else
                        {
                            wraiting.error();
                        }
                        break;
                    case "5":
                        Console.Clear();
                        if (listCar.Count != 0)
                        {
                            manualControl.findPackage(listCollectPackage);
                        }
                        else
                        {
                            wraiting.error();
                        }
                        break;
                    case "6":
                        Console.Clear();
                        if (listCar.Count != 0)
                        {
                            
                            hangar.send(recoveredPackage, listCar, listCollectPackage, listMachinery);
                        }
                        else
                        {
                            wraiting.error();
                        }
                            break;
                    case "7":
                        tmp = true;
                        
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Podano błędne polecenie spróbuj ponownie");
                        Thread.Sleep(4000);
                        break;
                }
                wraiting.Menu(recoveredPackage, listMachinery, listCar);
            }
            Console.Clear();

        }
    }
}
