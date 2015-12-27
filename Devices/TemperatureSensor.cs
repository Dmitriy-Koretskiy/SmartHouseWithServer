using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    class TemperatureSensor : ISensor
    {
        private Random random = new Random();
        private int currentState = 28;

        public int GenerateValue()
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
            Console.WriteLine("Temperature value = {0}", currentState);
            return currentState;
        }
    }
}
