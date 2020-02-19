using GRM.Emmanuel.Domain.Abstract;
using GRM.Emmanuel.Domain.Extension;
using GRM.Emmanuel.Domain.Model;
using GRM.Emmanuel.Domain.Model.Request;
using GRM.Emmanuel.Domain.Query.Interface;
using GRM.Emmanuel.Domain.Query.Service;
using GRM.Emmanuel.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GRM.Emmanuel.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = InitializeServiceProvider();

            var record = serviceProvider.GetService<IQueryMusicRecords>();

            var searchQuery = Console.ReadLine();

            if (searchQuery != null)
            {
                var partner = searchQuery.Split(new[] { ' ' })[0];
                var date = searchQuery.Replace($"{partner} ", "");

                if (!string.IsNullOrEmpty(partner) && !string.IsNullOrEmpty(date))
                {
                    var recordQuery = new RecordQuery
                    {
                        Partner = partner,
                        Date = date
                    };

                    var musicResult = record.RetrieveMusicRecord(recordQuery);

                    if (musicResult != null)
                    {
                        Console.WriteLine("Artist|Title|Usage|StartDate|EndDate");
                        foreach (var musicContract in musicResult)
                        {
                            var startDate = musicContract.StartDate.HasValue
                                ? $"{musicContract.StartDate.Value.Day.AddSuffixToDay()} {musicContract.StartDate.Value:MMM} {musicContract.StartDate.Value:yyyy}"
                                : "";
                            var endDate = musicContract.EndDate.HasValue
                                ? $"{musicContract.EndDate.Value.Day.AddSuffixToDay()} {musicContract.EndDate.Value:MMM} {musicContract.EndDate.Value:yyyy}"
                                : "";
                            Console.WriteLine(
                                $"{musicContract.Artist}|{musicContract.Title}|{musicContract.Usages}|{startDate}|{endDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("We couldn't complete your query at the moment due to an error");
                    }
                }
                else { Console.WriteLine("Please provide valid query parameters");}

            }
        }

        private static ServiceProvider InitializeServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<IQueryMusicRecords, QueryMusicRecords>()
                .AddTransient<FileReader<Record>, MusicContracts>()
                .AddTransient<FileReader<PartnersContract>, DistributionPartners>()
            
                .BuildServiceProvider();
        }

    }
}
