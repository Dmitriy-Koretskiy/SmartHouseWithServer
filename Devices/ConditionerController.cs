using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Devices
{
    class ConditionerController: BaseController
    {
        public ConditionerController(int id)
            : base(id)
        {
        }

        public override void On()
        {
            Console.WriteLine("Conditioner"+ id + " ON");
        }

        public override void Off()
        {
            Console.WriteLine("Conditioner" + id + " OFF");
        }
    }
}
