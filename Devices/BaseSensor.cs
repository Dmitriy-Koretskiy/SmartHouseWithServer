using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Devices
{
    public abstract class BaseSensor : ISensor
    {
        public int Id { get; set; }
        public int CurrentValue { get; set; }

        public BaseSensor(int id)
        {
            this.Id = id;
            StartSensor();
        }


        public async Task Periodic(Action func, TimeSpan period, CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                func();

                await Task.Delay(period);
            }
        }


        private void StartSensor()
        {
            Periodic(GenerateValue, TimeSpan.FromSeconds(2), CancellationToken.None);
        }

        protected abstract void GenerateValue();
    }
}
