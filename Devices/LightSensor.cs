using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Interfaces.Tables;

namespace Devices
{
    class LightSensor: BaseSensor
    {
        public LightSensor (int id)
            :base (id)
        {
             CurrentValue = 495;
        }

        private Random random = new Random();

        protected override void GenerateValue()
        {
            CurrentValue = CurrentValue - 10 + random.Next(0,21);
            if (CurrentValue < 440)
            {
                CurrentValue = 490;
            }
            if (CurrentValue > 550)
            {
                CurrentValue = 510;
            }

            Console.WriteLine("Light value" + Id + " = {0}", CurrentValue);
        }
    }
}
