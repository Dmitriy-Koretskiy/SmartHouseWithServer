using Interfaces;
using Interfaces.Tables;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChangesOfDB
    {
        public void WriteSensorsValuesToDB(List<object> sensors)
        {
            using (IRepository repository = ServiceLocator.Current.GetInstance<IRepository>())
            {
                foreach(ISensor sensor in sensors){

                    SensorsValue sensorsValue = new SensorsValue() { SensorId = sensor.Id, TimeMeasurement = DateTime.Now, Value = sensor.CurrentValue };

                    repository.Add(sensorsValue);              
                }
                repository.SaveChanges();
            }
        }
    }
}
