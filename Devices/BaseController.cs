using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public abstract class BaseController: IController
    {
        public int id;

        public BaseController(int id) 
        {
            this.id = id;
        }

        public abstract void On();
        public abstract void Off();
    }
}
