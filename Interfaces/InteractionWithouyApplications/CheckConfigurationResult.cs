using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.InteractionWithouyApplications
{
    public class CheckConfigurationResult
    {
        public bool errorExist; 
        public List<MissingDevice> missingDevices = new List<MissingDevice>();
    }
}
