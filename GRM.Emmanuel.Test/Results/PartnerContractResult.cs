using System.Collections.Generic;
using GRM.Emmanuel.Domain.Model;

namespace GRM.Emmanuel.Test.Results
{
    internal static class PartnerContractResult
    {
        public static List<PartnersContract> PartnerContractResponse => new List<PartnersContract>
        {
            new PartnersContract
            {
                Partner = "ITunes",
                Usage = "digital download"
            },
            new PartnersContract
            {
                Partner = "YouTube",
                Usage = "streaming"
            }
        };
    }
}