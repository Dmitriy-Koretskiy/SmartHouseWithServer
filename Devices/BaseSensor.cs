using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public abstract class BaseSensor: ISensor
    {
        public  int Id { get; set; }
        protected IRepository repository = new Repository();

        public BaseSensor(int id) 
        {
            this.Id = id;
        }

        public abstract  int GenerateValue();
    }
}
