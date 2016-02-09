using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Interfaces;
using DAL;
using Interfaces.Tables;
using BLL;
using Interfaces.DTO;


namespace SmartHouseWithServer
{
    class Program
    {
        static void Main(string[] args)
        {
            CastleWindsorInit.BootstrapContainer();

            Server server = new Server();

            for (; ; )
            {
                var checkResult = server.CheckConfiguration();
                if (!checkResult.errorExist)
                {
                    break;
                }
                Thread.Sleep(10000);
            }
            server.StartSystemWork();
        }
    }
}
