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
            currentTact++;
            currentState = currentState - 3 + random.Next(0, 7);
            if (currentState < 20)
            {
                currentState = 25;
            }
            if (currentState > 40)
            {
                currentState = 35;
            }

            if (currentTact >= amountTactsToWriteToDB)
            {
                SensorsValue sensorsValue = new SensorsValue() { SensorId = id, TimeMeasurement = DateTime.Now, Value = currentState };

                repository.Add(sensorsValue);
                repository.SaveChanges();
                currentTact = 0;
            }
            Console.WriteLine("Temperature value" + id + " = {0}", currentState);
            return currentState;
        }
    }
}
