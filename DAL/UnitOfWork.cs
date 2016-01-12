using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tables;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private SmartHouseContext db = new SmartHouseContext();
        private ControllerRepository controllerRepository;
        private SensorRepository sensorRepository;
        private SensorsValueRepository sensorsValueRepository;
        private TriggerRepository triggerRepository;
        private TriggersActionRepository triggersActionRepository;


        public ControllerRepository Controllers
        {
            get
            {
                if (controllerRepository == null)
                    controllerRepository = new ControllerRepository(db);
                return controllerRepository;
            }
        }

        public SensorRepository Sensors
        {
            get
            {
                if (sensorRepository == null)
                    sensorRepository = new SensorRepository(db);
                return sensorRepository;
            }
        }

        public SensorsValueRepository SensorsValues
        {
            get
            {
                if (sensorsValueRepository == null)
                    sensorsValueRepository = new SensorsValueRepository(db);
                return sensorsValueRepository;
            }
        }

        public TriggerRepository Triggers
        {
            get
            {
                if (triggerRepository == null)
                    triggerRepository = new TriggerRepository(db);
                return triggerRepository;
            }
        }

        public TriggersActionRepository TriggersActions
        {
            get
            {
                if (triggersActionRepository == null)
                    triggersActionRepository = new TriggersActionRepository(db);
                return triggersActionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
