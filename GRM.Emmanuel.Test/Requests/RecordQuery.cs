using GRM.Emmanuel.Domain.Model.Request;


namespace GRM.Emmanuel.Test.Requests
{
    class RecordQueryRequest
    {
        public RecordQuery RecordInvalidQuery()
        {
            return new RecordQuery
            {
                Date = "1st March 2012",
                Partner = "ouTube"
            };
        }
    }
}
