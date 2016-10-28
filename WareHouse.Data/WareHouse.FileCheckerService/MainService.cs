using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.FileWatcher;
using WareHouse.FileCheckerService.Repositories;

namespace WareHouse.FileCheckerService
{
    public partial class MainService : ServiceBase
    {
        RuntimeCsvFileWatcher watcher;

        public MainService()
        {
            InitializeComponent();
        }

        public void Start()
        {
            this.OnStart(new string[0]);
        }

        protected override void OnStart(string[] args)
        {
            StartUpConfigurateAsync();
        }


        protected override void OnStop()
        {

        }


        private Task StartUpConfigurateAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                watcher = new RuntimeCsvFileWatcher(@"D:\in", new ChangeRepository(new Context.HistoryDbContext()));
            });
        }

    }
}
