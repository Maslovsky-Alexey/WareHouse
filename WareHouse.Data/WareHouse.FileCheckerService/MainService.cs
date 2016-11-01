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
using WareHouse.FileCheckerService.APIMediator;
using WareHouse.FileCheckerService.FileWatcher;
using WareHouse.FileCheckerService.Models.APIModel;
using WareHouse.FileCheckerService.Repositories;

namespace WareHouse.FileCheckerService
{
    public partial class MainService : ServiceBase
    {
        private ItemsCsvFileWatcher watcherItems;
        private OrdersCsvFileWatcher watcherOrders;

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


        private void StartUpConfigurateAsync()
        {
            Task.Factory.StartNew(() =>
            {
                watcherOrders = new OrdersCsvFileWatcher(@"D:\in\orders", new ChangeRepository(new Context.HistoryDbContext()), new OrdersAPIMediator());
                watcherItems = new ItemsCsvFileWatcher(@"D:\in\items", new ChangeRepository(new Context.HistoryDbContext()), new ItemsAPIMediator());                      
            });     
        }

    }
}
