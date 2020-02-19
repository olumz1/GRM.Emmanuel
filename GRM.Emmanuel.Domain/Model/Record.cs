using System;

namespace GRM.Emmanuel.Domain.Model
{
    public class Record
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Usages { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
