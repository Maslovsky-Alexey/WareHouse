using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //new MainService().Start();

            //Thread.Sleep(999999999);

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MainService()
            };
            ServiceBase.Run(ServicesToRun);
           
        }


    }

       /*
             Add-Migration SampleMigrations -ProjectName "WareHouse.FileCheckerService"
             Update-Database -ProjectName "WareHouse.FileCheckerService" 
      */
}
