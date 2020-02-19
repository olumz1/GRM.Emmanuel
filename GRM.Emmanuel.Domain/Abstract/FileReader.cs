using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GRM.Emmanuel.Domain.Abstract
{
    public abstract class FileReader<T> where T : class, new()
    {
        public abstract IEnumerable<T> Get();
        protected IEnumerable<T> GetData(string file)
        {
            var fileDataResults = File.ReadAllLines(file).Skip(1);
            return fileDataResults.Select(fileData => MapData(fileData.Split('|'))).ToList();
        }

        protected abstract T MapData(string[] csvLineResult);

    }
}
