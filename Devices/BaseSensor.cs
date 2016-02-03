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
        public int id;
        protected int currentTact = 0;
        protected int amountTactsToWriteToDB = 10;
        protected IRepository repository = new Repository();

        public BaseSensor(int id) 
        {
            this.id = id;
        }

        public abstract  int GenerateValue();
    }
}
