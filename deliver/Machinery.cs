using System;
using System.Collections.Generic;
using System.Text;

namespace zad.deliver
{
    public class Machinery
    {
        public float AgriculturalMachineryWeight;
        public string status;
        public Machinery(float agriculturalMachineryWeight)
        {
            AgriculturalMachineryWeight = agriculturalMachineryWeight;
            status = "Do zaladowania";
        }
    }
}
