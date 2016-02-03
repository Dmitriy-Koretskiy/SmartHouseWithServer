using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Devices
{
    class LightController: BaseController
    {
         public LightController(int id)
            : base(id)
        {
        }

         public override void On()
        {
            Console.WriteLine("Lamp" + id + " ON");
        }

         public override void Off()
        {
            Console.WriteLine("Lamp" + id + " OFF");
        }
    }
}
