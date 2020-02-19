using System;
using System.Collections.Generic;
using GRM.Emmanuel.Domain.Abstract;
using GRM.Emmanuel.Domain.Extension;
using GRM.Emmanuel.Domain.Model;

namespace GRM.Emmanuel.Domain.Repository
{
    public class MusicContracts : FileReader<Record>
    {
        public override IEnumerable<Record> Get()
        {
            var currentDomain = AppDomain.CurrentDomain.BaseDirectory;
            var directory = @"\MusicContracts\MusicContracts.txt";
            string path = $"{currentDomain}{directory}";
            return GetData(path);
        }

        protected override Record MapData(string[] csvLineResult)
        {
            return new Record
            { 
               Artist = csvLineResult[0],
               Title = csvLineResult[1], 
               Usages = csvLineResult[2],
               StartDate = string.IsNullOrEmpty(csvLineResult[3]) ? null : csvLineResult[3]?.RemoveSuffix().ToDateTimeFormat(),
               EndDate = string.IsNullOrEmpty(csvLineResult[4]) ? null : csvLineResult[4]?.RemoveSuffix().ToDateTimeFormat()
            };
        }
    }
}
