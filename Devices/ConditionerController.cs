using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class ConditionerController: IController
    {
        public void On()
        {
            Console.WriteLine("Conditioner ON");
        }

        public void Off()
        {
            Console.WriteLine("Conditioner OFF");
        }
    }
}
