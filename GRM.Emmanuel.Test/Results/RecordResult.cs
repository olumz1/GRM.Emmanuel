using System;
using System.Collections.Generic;
using System.Text;
using GRM.Emmanuel.Domain.Extension;
using GRM.Emmanuel.Domain.Model;

namespace GRM.Emmanuel.Test.Results
{
    internal static class RecordResult
    {
        public static List<Record> ExpectedRecord => new List<Record>
        {
            new Record
            {
                Artist = "Monkey Claw",
                Title = "Black Mountain",
                Usages = "digital download",
                StartDate = "1st Feb 2012".RemoveSuffix().ToDateTimeFormat(),
                EndDate = null
            },
            new Record
            {
                Artist = "Tinie Tempah",
                Title = "Frisky (Live from SoHo)",
                Usages = "digital download, streaming",
                StartDate = "1 Feb 2012".RemoveSuffix().ToDateTimeFormat(),
                EndDate = null
            },
            new Record
            {
                Artist = "Tinie Tempah",
                Title = "Miami 2 Ibiza",
                Usages = "digital download",
                StartDate = "1 Feb 2012".RemoveSuffix().ToDateTimeFormat()
            },
            new Record
            {
                Artist = "Monkey Claw",
                Title = "Iron Horse",
                Usages = "digital download, streaming",
                StartDate = "1 June 2012".RemoveSuffix().ToDateTimeFormat()
            },
            new Record
            {
                Artist = "Monkey Claw",
                Title = "Christmas Special",
                Usages = "streaming",
                StartDate = "25st Dec 2012".RemoveSuffix().ToDateTimeFormat(),
                EndDate = "31st Dec 2012".RemoveSuffix().ToDateTimeFormat()
            }
        };
    }
}
