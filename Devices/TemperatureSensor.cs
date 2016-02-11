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
            CurrentValue = 28;
        }

        private Random random = new Random();

        protected override void GenerateValue()
        {
            CurrentValue = CurrentValue - 3 + random.Next(0, 7);
            if (CurrentValue < 20)
            {
                CurrentValue = 25;
            }
            if (CurrentValue > 40)
            {
                CurrentValue = 35;
            }
        
            Console.WriteLine("Temperature value" + Id + " = {0}", CurrentValue);
        }
    }
}
