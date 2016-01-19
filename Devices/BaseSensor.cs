using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public abstract class BaseSensor: ISensor
    {
        public int id;

        public BaseSensor(int id) 
        {
            this.id = id;
        }

        public abstract  int GenerateValue();
    }
}
