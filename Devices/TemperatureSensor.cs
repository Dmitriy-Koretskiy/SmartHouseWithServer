using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Tables;

namespace Devices
{
    class TemperatureSensor : BaseSensor
    {
        public TemperatureSensor (int id)
            :base (id)
        {
        }

        private Random random = new Random();
        private int currentState = 28;
 
        public override int GenerateValue()
        {
            currentState = currentState - 3 + random.Next(0, 7);
            if (currentState < 20)
            {
                currentState = 25;
            }
            if (currentState > 40)
            {
                currentState = 35;
            }
        
            Console.WriteLine("Temperature value" + Id + " = {0}", currentState);
            return currentState;
        }
    }
}
