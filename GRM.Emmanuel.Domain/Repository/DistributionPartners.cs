using System;
using System.Collections.Generic;
using GRM.Emmanuel.Domain.Abstract;
using GRM.Emmanuel.Domain.Model;

namespace GRM.Emmanuel.Domain.Repository
{
    public class DistributionPartners : FileReader<PartnersContract>
    {
        public override IEnumerable<PartnersContract> Get()
        {
            var currentDomain = AppDomain.CurrentDomain.BaseDirectory;
            var directory = @"\MusicContracts\DistributionPartners.txt";
            string path = $"{currentDomain}{directory}";
            return GetData(path);
        }

        protected override PartnersContract MapData(string[] csvLineResult)
        {
            return new PartnersContract
            {
                Partner = csvLineResult[0],
                Usage = csvLineResult[1]
            };
        }
    }
}
