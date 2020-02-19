using System;
using System.Collections.Generic;
using System.Linq;
using GRM.Emmanuel.Domain.Abstract;
using GRM.Emmanuel.Domain.Enum;
using GRM.Emmanuel.Domain.Extension;
using GRM.Emmanuel.Domain.Model;
using GRM.Emmanuel.Domain.Model.Request;
using GRM.Emmanuel.Domain.Query.Interface;

namespace GRM.Emmanuel.Domain.Query.Service
{
    public class QueryMusicRecords : IQueryMusicRecords
    {
        private readonly FileReader<Record> _recordsReader;
        private readonly FileReader<PartnersContract> _distributionsReader;

        public QueryMusicRecords(FileReader<Record> recordsReader, FileReader<PartnersContract> distributionsReader)
        {
            _recordsReader = recordsReader;
            _distributionsReader = distributionsReader;
        }

        public IEnumerable<Record> RetrieveMusicRecord(RecordQuery recordQuery)
        {
            var queryDate = recordQuery.Date.RemoveSuffix().ToDateTimeFormat();
            var musicContractResponse = _recordsReader.Get();
            var partnerResponse = _distributionsReader.Get();
            var isPartnerValid = partnerResponse?.Any(_ => _.Partner.Equals(recordQuery.Partner));

            if (isPartnerValid != true)
            {
                throw new ArgumentNullException(nameof(recordQuery));
            }
            
            var usage = DetermineMusicContractUsage(recordQuery.Partner);

            var musicResult = musicContractResponse.Where(x => x.StartDate <= queryDate && x.Usages.Contains(usage));

            return musicResult;
        }

        private string DetermineMusicContractUsage(string partnersContract)
        {
            var usageType = new UsageType();
            switch (partnersContract)
            {
                case nameof(PartnerType.ITunes):
                    return usageType.Download;
                
                case nameof(PartnerType.YouTube):
                    return usageType.Streaming;

                default: return null;
            }
        }

    }
}
