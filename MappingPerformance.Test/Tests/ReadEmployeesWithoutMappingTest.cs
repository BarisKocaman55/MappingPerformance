using MappingPerformance.Interactors.Interactors;
using MappingPerformance.Test.Base;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading;

namespace MappingPerformance.Test
{
    [TestClass]
    public class ReadEmployeesWithoutMappingTest : BaseTestClass
    {
        [TestMethod]
        public void Handle()
        {
            Stopwatch TimeCheck = new Stopwatch();
            var interactor = GetService<IRequestHandler<ReadEmployeeWithOutMappingRequestMessage, ReadEmployeeWithOutMappingResponseMessage>>();
            ReadEmployeeWithOutMappingRequestMessage request = new ReadEmployeeWithOutMappingRequestMessage();

            TestOut(request);

            TimeCheck.Start();
            var response = interactor.Handle(request, CancellationToken.None).Result;
            TimeCheck.Stop();

            Debug.WriteLine($"ReadEmployeesWithoutMapping took  {TimeCheck.ElapsedMilliseconds} ms");

            TestOut(response);
        }
    }
}
