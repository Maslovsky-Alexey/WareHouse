using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model.ViewModel;

namespace WebAPI.LogHelper
{
    public class LogHelper : ILog, IObserver<SignInLogModel> // TODO: Это общая логика приложения, этот класс не должен находится в сборке webapi.
    {
        public string FileName { get; private set; }

        private static LogHelper instance;

        public static LogHelper Instance(string fileName)
        {
            if (instance == null)
                instance = new LogHelper(fileName);

            return instance;
        }

        private LogHelper(string fileName)
        {
            FileName = fileName;

            if (!File.Exists(FileName))
                File.Create(FileName).Dispose();
        }

        public void Clear()
        {
            File.Create(FileName).Dispose();
        }

        public void Log(string text)
        {
            using (var sw = File.AppendText(FileName))
                sw.WriteLine(text);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(SignInLogModel value)
        {
            Log(value.ToString());
        }
    }
}
