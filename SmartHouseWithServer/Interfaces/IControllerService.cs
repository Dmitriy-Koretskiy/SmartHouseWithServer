using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouseWithServer.DTO;
 
namespace SmartHouseWithServer.Interfaces
{
    public interface IControllerService
    {
        ControllerDTO GetController(int? id);
        IEnumerable<ControllerDTO> GetControllers();
        void Dispose();
    }
}
