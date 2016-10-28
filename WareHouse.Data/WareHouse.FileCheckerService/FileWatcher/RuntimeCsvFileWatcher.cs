using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.Repositories.Interfaces;

namespace WareHouse.FileCheckerService.FileWatcher
{
    public class RuntimeCsvFileWatcher
    {
        private readonly IChangeRepository changeRepository;
        private FileSystemWatcher watcher;
        private string folder;

        public RuntimeCsvFileWatcher(string folder, IChangeRepository changeRepository)
        {
            this.folder = folder;

            this.changeRepository = changeRepository;
            FileSystemWatcher watcher = new FileSystemWatcher(this.folder, "*.csv");

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite| NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;

            watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        { 
            changeRepository.RemoveByFullPath(e.FullPath);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            AddChangeNow(e.FullPath);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            AddChangeNow(e.FullPath);
        }

        private OperationStatus AddChangeNow(string fullpath)
        {
            return changeRepository.AddOrUpdate(new Models.ChangeModel
            {
                LastChange = DateTime.Now,
                FullPath = fullpath
            });
        }

        private void CheckFiles()
        {
            var lastChange = changeRepository.GetDateTimeLastChange();



        }
    }
}
