using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.FileCheckerService.CsvParser
{
    public class CsvParser
    {
        public CsvParser()
        {

        }

        public IEnumerable<T> Parse<T>(string text)
        {
            var csvReader = new CsvReader(new StringReader(text), new CsvHelper.Configuration.CsvConfiguration
            {
                Encoding = Encoding.UTF8
            });

            return csvReader.GetRecords<T>();
        }
    }
}
