using System.Collections.Generic;
using GRM.Emmanuel.Domain.Model;
using GRM.Emmanuel.Domain.Model.Request;

namespace GRM.Emmanuel.Domain.Query.Interface
{
    public interface IQueryMusicRecords
    {
        IEnumerable<Record> RetrieveMusicRecord(RecordQuery recordQuery);
    }
}
