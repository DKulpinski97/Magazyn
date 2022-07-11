using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using zad.deliver;

namespace zad.hangar
{
    class Hangar 
    {
        List<Packages> listCollectPackage = new List<Packages>();
        public int idPackage = 0;
        public Hangar()
        {
        }
        public List<Packages> sortPackages(List<Packages> recoveredPackage, List<Car> listCar)
        {
            int idCar = 0;
            for (int i = 0; i < recoveredPackage.Count; i++)
            {
                if(listCar[idCar].ActualWeight+recoveredPackage[i].WaightPackage<=200)
                {
                    addToCar(recoveredPackage, listCar, idCar,i);
                    collectPackage(recoveredPackage, idCar, i);
                }
                else
                {
                    idCar++;
                    i--;
                }
            }
            recoveredPackage.Clear();
            return listCollectPackage;


        }
        public List<Packages> manualSortPackages(List<Packages> recoveredPackage, List<Car> listCar, int idCar,int idPackage)
        {
            int i,tmp=0;
            for (i=0;i<recoveredPackage.Count;i++)
            {
                if(recoveredPackage[i].IdPackage == idPackage)
                {
                    tmp = 1;
                    break;
                }
                

            }
            if (tmp == 0)
            {
                Console.Clear();
                Console.WriteLine("Nie ma paczki o takim numerze");
                Thread.Sleep(2000);
                return null;
            }

            if (listCar[idCar].ActualWeight + recoveredPackage[i].WaightPackage <= 200)
                {
                    addToCar(recoveredPackage, listCar, idCar, i);
                    collectPackage(recoveredPackage, idCar, i);
                    recoveredPackage.RemoveAt(i);
                }
                else
                {
                Console.Clear();
                Console.WriteLine("Nie można dodać paczki do tego samochodu bo przekroczymy dopuszczalną ładowność");
                Thread.Sleep(2000);
                return null;
                }
                return listCollectPackage;


        }
        private void addToCar(List<Packages> recoveredPackage, List<Car> listCar,int idCar,int idPackage)
        {
            listCar[idCar].IdPackage.Add(recoveredPackage[idPackage].IdPackage);
            listCar[idCar].ActualWeight += recoveredPackage[idPackage].WaightPackage;
        }
        private void collectPackage(List<Packages> recoveredPackage, int idCar, int idPackage)
        {
            Packages collectPackage = recoveredPackage[idPackage];
            collectPackage.IdCar = idCar;
            listCollectPackage.Add(collectPackage);
        }
        public void changeStatusMachinary(int id, List<Machinery> listMachinery) => listMachinery[id].status = "Załadowana";
        public void manualChangeStatusMachinary(float weight, List<Machinery> listMachinery)
        {
            int tmp = 0;
            foreach (var x in listMachinery)
            {
                if (x.AgriculturalMachineryWeight == weight && x.status!= "Załadowana")
                {
                    tmp = 1;
                    x.status = "Załadowana";
                }
            }
            if(tmp==0)
            {
                Console.Clear();
                Console.WriteLine("Maszyna o podanej masie nie istnieje lub została już załadowana");
                Thread.Sleep(2000);
            }
        }
        public void removeChangeStatusMachinary(float weight, List<Machinery> listMachinery)
        {
            int tmp = 0;
            foreach (var x in listMachinery)
            {
                if (x.AgriculturalMachineryWeight == weight && x.status != "Do zaladowania")
                {
                    tmp = 1;
                    x.status = "Do zaladowania";
                }
            }
            if (tmp == 0)
            {
                Console.Clear();
                Console.WriteLine("Maszyna o podanej masie nie istnieje lub została już wyładowana");
                Thread.Sleep(2000);
            }
        }
        public void remowPackage(List<Packages> recoveredPackage, List<Car> listCar, List<Packages> listCollectPackage,int idCar,int idPackage)
        {
            int i;
            int tmp = 0;
            for ( i = 0; i < listCollectPackage.Count; i++)
            { 
            if(listCollectPackage[i].IdPackage==idPackage)
                {
                    tmp = 1;
                    break;
                }
            }
            if(tmp==0)
            {
                Console.Clear();
                Console.WriteLine("Paczka o takim numerze nie została załadowana");
                Thread.Sleep(2000);
                return ;
            }
            tmp = 0;
            int b = -1;
            foreach(var x in listCar[idCar].IdPackage)
            {
                if(x==idPackage)
                {
                    tmp = 1;
                    b++;
                    break;
                }
                b++;
            }
            if(tmp==0)
            {
                Console.Clear();
                Console.WriteLine("W podanym samochodzie nie ma takiej paczki");
                Thread.Sleep(2000);
                return;
            }
            listCollectPackage[i].IdCar = -1;
            recoveredPackage.Add(listCollectPackage[i]);
            
            listCar[idCar].IdPackage.RemoveAt(b);
            listCar[idCar].ActualWeight -= listCollectPackage[i].WaightPackage;
            listCollectPackage.RemoveAt(i);
            

            
        }
        public void send(List<Packages> recoveredPackage, List<Car> listCar, List<Packages> listCollectPackage, List<Machinery> listMachinery)
        {
            if(recoveredPackage.Count==0)
            {

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Przynajmniej jedna paczka nie została załadowana do samochodu");
                Thread.Sleep(4000);
                return;
            }
            foreach(var x in listMachinery)
            {
                if (x.status== "Do zaladowania")
                {
                    Console.Clear();
                    Console.WriteLine("Przynajmniej jedna maszyna rolnicza nie została załadowana do samolotu");
                    Thread.Sleep(4000);
                    return;
                }
            }
            recoveredPackage.Clear();
            listCar.Clear();
            listCollectPackage.Clear();
            listMachinery.Clear();
            
            Console.WriteLine("Dostawa została nadana");
            Thread.Sleep(4000);
            Console.Clear();
        }
    }
}
