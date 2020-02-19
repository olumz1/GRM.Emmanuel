using System;
using System.Collections.Generic;
using System.Linq;
using GRM.Emmanuel.Domain.Abstract;
using GRM.Emmanuel.Domain.Extension;
using GRM.Emmanuel.Domain.Model;
using GRM.Emmanuel.Domain.Model.Request;
using GRM.Emmanuel.Domain.Query.Service;
using GRM.Emmanuel.Test.Requests;
using GRM.Emmanuel.Test.Results;
using Xunit;
using Record = GRM.Emmanuel.Domain.Model.Record;
using Moq;

namespace GRM.Emmanuel.Test
{
    public class RecordTests
    {
        private readonly Mock<FileReader<Record>>  _mockFileReaderRecords = new Mock<FileReader<Record>>();
        private readonly Mock<FileReader<PartnersContract>> _mockFileReaderPartnersContract = new Mock<FileReader<PartnersContract>>();

        public RecordTests()
        {
            _mockFileReaderRecords.Setup(_ => _.Get()).Returns(RecordResult.ExpectedRecord);
            _mockFileReaderPartnersContract.Setup(_ => _.Get()).Returns(PartnerContractResult.PartnerContractResponse);
        }

        [Theory]
        [InlineData("1st March 2012", "ITunes", "digital download", 3)]
        [InlineData("1st February 2012", "YouTube", "streaming", 1)]
        [InlineData("1st March 2013", "ITunes", "digital download", 4)]
        public void GivenITunesAsAPartnerAndDate_ReturnTheExpectedRecords(string date, string partner, string expectedResult, int listCount)
        {
            //Arrange
            var query = new RecordQuery
            {
                Date = date,
                Partner = partner
            };

            //Act
            var sut = new QueryMusicRecords(_mockFileReaderRecords.Object, _mockFileReaderPartnersContract.Object);
            var result = sut.RetrieveMusicRecord(query).ToList();

            //Assert
            Assert.Equal(listCount, result.Count);
            Assert.True(result.All(x => x.Usages.Contains(expectedResult)));
            Assert.True(result.All(x => x.StartDate <= query.Date.RemoveSuffix().ToDateTimeFormat()));
        }


        [Theory]
        [InlineData("1st March 2012", "2012-3-1")]
        [InlineData("3rd February 2013", "2013-2-3")]
        [InlineData("24th May 2012", "2012-5-24")]
        public void GivenADateWithSuffix_ReturnDateWithOutSuffixAndInDateTimeFormat(string date, string expectedDate)
        {
            //Act
            var result = date.RemoveSuffix().ToDateTimeFormat();
            var expectedResult = Convert.ToDateTime(expectedDate);

            //Assert

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenAnInValidPartnerAndDate_ReturnANullValueAndErrorMessageDisplayed()
        {
            //Arrange
            var recordQuery = new RecordQueryRequest();
            
            //Act
            var sut = new QueryMusicRecords(_mockFileReaderRecords.Object, _mockFileReaderPartnersContract.Object);

            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.RetrieveMusicRecord(recordQuery.RecordInvalidQuery()));
            
        }
    }

}
