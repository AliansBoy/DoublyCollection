using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoblyCollection
{
    class Notebook
    {
        public Notebook(int serialNumber, string name)
        {
            SerialNumber = serialNumber;
            Name = name;
        }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
    }
}
