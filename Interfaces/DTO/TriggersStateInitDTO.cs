using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class TriggersStateInitDTO:BaseEntityDTO
    {
        public string Name { get; set; }
        public string LastState { get; set; }      
        public string Image { get; set; }  
    }
}
