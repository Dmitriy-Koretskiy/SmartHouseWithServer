using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Devices
{
    class LightController: IController
    {
        public void On()
        {
            Console.WriteLine("Lamp ON");
        }

        public void Off()
        {
            Console.WriteLine("Lamp OFF");
        }
    }
}
