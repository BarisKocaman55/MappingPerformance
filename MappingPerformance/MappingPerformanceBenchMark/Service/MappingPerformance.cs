using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MappingPerformance.Interactors.Interactors;
using MappingPerformance.MappingPerformanceBenchMark.IService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MappingPerformance
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class MappingPerformance : IMappingPerformance
    {

        private static HttpClient client;

        public MappingPerformance()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44366/api/employee/");
        }

        [Benchmark]
        public void ReadEmployeeByMappingInteractorPerformance()
        {
            var result = client.GetAsync(string.Format("{0}", "getEmployeesWithMapping")).Result;
        }

        [Benchmark]
        public void ReadEmployeeWithOutMappingInteractorPerformance()
        {
            var result = client.GetAsync(string.Format("{0}", "getEmployeesWithoutMapping")).Result;
        }

    }
}
