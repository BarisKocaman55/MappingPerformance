using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using MappingPerformance.Interactors.Interactors;
using MappingPerformance.TestBenchmark.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MappingPerformance.TestBenchmark.BenchmarkPerformance
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class MappingPerformanceBenchmark : BaseBenchmarkClass
    {
        [Benchmark]
        public ReadEmployeeWithOutMappingResponseMessage ReadEmployeeWithoutMappingInteractorTest()
        {
            var request = new ReadEmployeeWithOutMappingRequestMessage();

            var interactor = GetService<IRequestHandler<ReadEmployeeWithOutMappingRequestMessage, ReadEmployeeWithOutMappingResponseMessage>>();

            return interactor.Handle(request, CancellationToken.None).Result;
        }
            
        [Benchmark]
        public ReadEmployeeByMappingResponseMessage ReadEmployeeWithMappingInteractorTest()
        {
            var request = new ReadEmployeeByMappingRequestMessage();

            var interactor = GetService<IRequestHandler<ReadEmployeeByMappingRequestMessage, ReadEmployeeByMappingResponseMessage>>();

            return interactor.Handle(request, CancellationToken.None).Result;
        }
            
        [Benchmark]
        public ReadEmployeeByAutoMapperResponseMessage ReadEmployeeByAutoMapperInteractorTest()
        {
            var request = new ReadEmployeeByAutoMapperRequestMessage();

            var interactor = GetService<IRequestHandler<ReadEmployeeByAutoMapperRequestMessage, ReadEmployeeByAutoMapperResponseMessage>>();
            
            return interactor.Handle(request, CancellationToken.None).Result;
        }

        [Benchmark]
        public ReadEmployeeWithMapsterResponseMessage ReadEmployeeWithMapsterInteractorTest()
        {
            var request = new ReadEmployeeWithMapsterRequestMessage();

            var interactor = GetService<IRequestHandler<ReadEmployeeWithMapsterRequestMessage, ReadEmployeeWithMapsterResponseMessage>>();

            return interactor.Handle(request, CancellationToken.None).Result;
        }


    }
}
