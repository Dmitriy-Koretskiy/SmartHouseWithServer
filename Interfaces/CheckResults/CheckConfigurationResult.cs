using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.CheckResults
{
    public class CheckConfigurationResult
    {
        public bool errorExist; 
        public List<string> missingDevice = new List<string>();
    }
}
