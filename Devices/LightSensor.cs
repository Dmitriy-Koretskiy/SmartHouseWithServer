using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Devices
{
    class LightSensor: BaseSensor
    {
        public LightSensor (int id)
            :base (id)
        {
        }

        private Random random = new Random();
        private int currentState = 495;

        public override int GenerateValue()
        {
            currentState = currentState - 10 + random.Next(0,21);
            if (currentState < 440)
            {
                currentState = 490;
            }
            if (currentState > 550)
            {
                currentState = 510;
            }
            Console.WriteLine("Light value = {0}", currentState);
            return currentState;
        }
    }
}
