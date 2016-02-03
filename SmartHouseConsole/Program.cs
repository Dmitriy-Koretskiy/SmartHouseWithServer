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
            for (; ; )
            {
                var checkResult = Server.CheckConfiguration();
                if (!checkResult.errorExist)
                {
                    break;
                }
                Thread.Sleep(10000);
            }
            Server.StartWork();
            //SensorDTO s1 = new SensorDTO() { Id = 1, Name = "s1" };
            //SensorDTO s2 = new SensorDTO() { Id = 2, Name = "s2" };
            //List<SensorDTO> list = new List<SensorDTO>();
            //list.Add(s1);
            //list.Add(s2);
            //int id = list.First(s => s.Name == "s1").Id;
        }
    }
}
