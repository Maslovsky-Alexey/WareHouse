using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.LogHelper
{
    public class FileLog<TModel> : ILog, IObserver<TModel>
    {
        public string FileName { get; private set; }

        private static FileLog<TModel> instance;

        public static FileLog<TModel> Instance(string fileName)
        {
            if (instance == null)
                instance = new FileLog<TModel>(fileName);

            return instance;
        }

        private FileLog(string fileName)
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

        public void OnNext(TModel value)
        {
            Log(value.ToString());
        }
    }
}
