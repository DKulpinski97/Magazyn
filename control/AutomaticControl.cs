using System;
using System.Collections.Generic;
using System.Text;
using zad.deliver;
using zad.hangar;

namespace zad.control
{
    class AutomaticControl
    {
        public List<Packages> automatic(List<Packages> listCollectPackage, List<Packages> recoveredPackage, List<Car> listCar, List<Machinery> listMachinery)
        {
            Hangar hangar = new Hangar();
            //rozdzielanie paczek 
            listCollectPackage=hangar.sortPackages(recoveredPackage, listCar);

            //przeladowanie maszyny rolniczej
            hangar.changeStatusMachinary(0, listMachinery);
            hangar.changeStatusMachinary(1, listMachinery);
            return listCollectPackage;


        }
    }
    
}
