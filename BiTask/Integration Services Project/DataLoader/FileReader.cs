using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataLoader
{
    public class FileReader
    {
        private string _path;
        private StreamReader _streamReader;

        public FileReader(string path = "Environment.CurrentDirectory/../../../result.csv")
        {
            _path = path;
            _streamReader = new StreamReader(_path);
            
            //get rid of the first line
            _streamReader.ReadLine();
        }

        public List<string> GetNextDataRow()
        {
            var line = _streamReader.ReadLine();

            if (line == null) return null;

            return line.Split(',').ToList();
        }
    }
}
