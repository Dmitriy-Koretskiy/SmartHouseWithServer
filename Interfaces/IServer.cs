using Interfaces.InteractionWithouyApplications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IServer
    {
        List<MissingDevice> CheckConfiguration();
        void Initialize();
        void StopWork();
    }
}
