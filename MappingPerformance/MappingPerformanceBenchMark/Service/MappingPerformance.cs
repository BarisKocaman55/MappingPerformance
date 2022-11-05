using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MappingPerformance.MappingPerformanceBenchMark.IService;
using System;
using System.Net.Http;

namespace MappingPerformance
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class MappingPerformance : IMappingPerformance
    {
        private static HttpClient client;
        private readonly string baseUri  = "https://localhost:44366/api/employee/";

        public MappingPerformance()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
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
        
        [Benchmark]
        public void ReadEmployeeWithAutoMapper()
        {
            var result = client.GetAsync(string.Format("{0}", "getEmployeeWithAutoMapper")).Result;
        }

        [Benchmark]
        public void ReadEmployeeWithMapsterInteractorPerformance()
        {
            var result = client.GetAsync(string.Format("{0}", "getEmployeeWithMapster")).Result;
        }
    }
}
