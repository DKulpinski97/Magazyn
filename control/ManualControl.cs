using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using zad.deliver;
using zad.hangar;
using zad.wraiting;

namespace zad.control
{
    public class ManualControl
    {
        Hangar hangar = new Hangar();
        Wraiting wraiting = new Wraiting();
        public void control(List<Packages> recoveredPackage, List<Car> listCar, List<Packages> listCollectPackage)
        {
            
            bool tmp = false;
            while(tmp!=true)
            {
                
                wraiting.packageToBePickedUp(recoveredPackage);
                wraiting.PackageInCar(listCar);
                wraiting.Menu2();
                string car, id;
                int idCar, idPackage;
                Console.WriteLine("Wybierz polecenie ");
                string order = Console.ReadLine();
                switch (order)
                {
                    case "1":
                        To:
                       try
                            {
                            Console.WriteLine("Wybierz numer samochodu");
                            car = Console.ReadLine();
                            idCar = int.Parse(car);
                            Console.WriteLine("Wybierz numer paczki");
                            id = Console.ReadLine();
                            idPackage = int.Parse(id);
                            hangar.manualSortPackages(recoveredPackage, listCar, idCar, idPackage);
                        }
                        catch
                        {
                            Console.WriteLine("Podano błędnie dane proszę spróbować ponownie");
                            Thread.Sleep(4000);
                            goto To;
                        }
                        Console.Clear();
                        break;
                    case "2":
                        To1:
                            try
                            {
                                Console.WriteLine("Wybierz numer samochodu");
                                car = Console.ReadLine();
                                idCar = int.Parse(car);
                                Console.WriteLine("Wybierz numer paczki");
                                id = Console.ReadLine();
                                idPackage = int.Parse(id);
                                hangar.remowPackage(recoveredPackage, listCar, listCollectPackage, idCar, idPackage);
                            }
                            catch
                            {
                                Console.WriteLine("Podano błędnie dane proszę spróbować ponownie");
                                Thread.Sleep(4000);
                                goto To1;
                            }
                        Console.Clear();
                        
                        break;
                    case "3":
                        Console.Clear();
                        tmp = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Podano błędne polecenie spróbuj ponownie");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
        public void mahinControl(List<Machinery> listMachinery)
        {
            
            bool tmp = false;
            while (tmp != true)
            {

                wraiting.AgriculturalMachineryToBePickedUp(listMachinery);
                wraiting.AgriculturalMachineryInAirplan(listMachinery);
                wraiting.Menu3();
                string waigtS;
                float waigt;
                Console.WriteLine("Wybierz polecenie ");
                string order = Console.ReadLine();
                switch (order)
                {
                    case "1":
                        To:
                            Console.WriteLine("Wprowadź masę maszyny");
                        try
                        {
                            waigtS = Console.ReadLine();
                            waigt = float.Parse(waigtS);
                            hangar.manualChangeStatusMachinary(waigt, listMachinery);
                        }
                        catch
                        {
                            Console.WriteLine("Podano błędnie dane proszę spróbować ponownie");
                            Thread.Sleep(4000);
                            goto To;
                        }
                       
                        Console.Clear();
                        break;
                    case "2":
                        To1:
                            Console.WriteLine("Wprowadź masę maszyny");
                        try
                        {
                            waigtS = Console.ReadLine();
                            waigt = float.Parse(waigtS);
                            hangar.removeChangeStatusMachinary(waigt, listMachinery);
                        }
                        catch
                        {
                            Console.WriteLine("Podano błędnie dane proszę spróbować ponownie");
                            Thread.Sleep(4000);
                            goto To1;
                        }
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        tmp = true;

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Podano błędne polecenie spróbuj ponownie");
                        Thread.Sleep(2000);
                        break;

                }
            }
        }
        public void findPackage(List<Packages> listCollectPackage)
        {
            bool tmp = false;
            while (tmp != true)
            {
                wraiting.packageInCar(listCollectPackage);
                wraiting.Menu4();
                string id;
                int idPackage;
                Console.WriteLine("Wybierz polecenie ");
                string order = Console.ReadLine();
                switch (order)
                {
                    case "1":
                        To:
                            try
                            {
                                Console.WriteLine("Wprowadź numer paczki");
                                id = Console.ReadLine();
                                idPackage = int.Parse(id);
                                find(listCollectPackage, idPackage);
                            }
                            catch
                            {
                                Console.WriteLine("Podano błędnie dane proszę spróbować ponownie");
                                Thread.Sleep(4000);
                                goto To;
                            }
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        tmp = true;

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Podano błędne polecenie spróbuj ponownie");
                        Thread.Sleep(2000);
                        break;

                }
            }
        }
        public void find(List<Packages> listCollectPackage,int idPacckage)
        {
            foreach(var x in listCollectPackage)
            {
                if(x.IdPackage==idPacckage)
                {
                    Console.Clear();
                    Console.WriteLine("Paczka o numerze id =" + x.IdPackage + " znajduje się w samochodzie o id =" + x.IdCar);
                    Thread.Sleep(4000);
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine("paczka o takim numerze nie została odebrana lub nie istnieje");
            Thread.Sleep(2000);
        }
    }

}
