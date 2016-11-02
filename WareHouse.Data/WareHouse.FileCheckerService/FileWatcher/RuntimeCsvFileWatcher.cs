using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.APIMediator.Interfaces;
using WareHouse.FileCheckerService.Repositories.Interfaces;

namespace WareHouse.FileCheckerService.FileWatcher
{
    public abstract class RuntimeCsvFileWatcher<TCsvModel, TAPIModel>
        where TCsvModel : class
        where TAPIModel : class
    {
        protected readonly IChangeRepository changeRepository;
        protected readonly ISenderAPI<TAPIModel> mediator;
        private Mapper.ModelsMapper<TCsvModel, TAPIModel> mapper;

        protected FileSystemWatcher watcher;
        protected string folder;

        public RuntimeCsvFileWatcher(string folder, IChangeRepository changeRepository, ISenderAPI<TAPIModel> mediator, Mapper.ModelsMapper<TCsvModel, TAPIModel> mapper)
        {
            this.mapper = mapper;

            this.folder = folder;

            this.changeRepository = changeRepository;
            this.mediator = mediator;

            AddAllChanges(folder);
            ConfigurateFileWathcer();
        }

        private void ConfigurateFileWathcer()
        {
            watcher = new FileSystemWatcher(this.folder, "*.csv");

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

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
            if (!IsFisrtTimeChange(e.FullPath))
                return;

            AddChangeNow(e.FullPath);
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (!IsFisrtTimeChange(e.FullPath))
                return;

            AddChangeNow(e.FullPath);
        }
       
        private OperationStatus AddChangeNow(string fullpath)
        {
            SendChangesToServer(fullpath);
            return changeRepository.AddOrUpdate(new Models.ChangeModel
            {
                LastChange = File.GetLastWriteTime(fullpath),
                FullPath = fullpath
            });
        }

        private bool IsFisrtTimeChange(string path)
        {
            var item = changeRepository.GetByFullPath(path);

            if (item == null || item.LastChange != File.GetLastWriteTime(path))
                return true;

            return false;
        }

        protected void SendChangesToServer(string fullpath)
        {
            var a = new CsvParser.CsvParser().Parse<TCsvModel>(File.ReadAllText(fullpath));

            foreach (var item in a)
                mediator.AddItem(mapper.MapService(item));
        }

        private void AddAllChanges(string path)
        {
            if (File.GetLastWriteTime(folder) <= changeRepository.GetDateTimeLastChange())
                return;

            foreach (var dir in Directory.GetDirectories(path))
                AddAllChanges(dir);

            foreach (var file in Directory.GetFiles(path, "*.csv"))
                if (File.GetLastAccessTime(file) > (changeRepository.GetByFullPath(file)?.LastChange ?? DateTime.MinValue))
                    AddChangeNow(file);
        }
    }
}
