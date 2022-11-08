using MappingPerformance.Interactors.Interactors;
using MappingPerformance.Test.Base;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MappingPerformance.Test
{
    [TestClass]
    public class ReadEmployeeByLINQMappingInteractorTest : BaseTestClass
    {
        [TestMethod]
        public void Handle()
        {
            Stopwatch TimeCheck = new Stopwatch();
            var request = new ReadEmployeeByLINQMappingRequestMessage();
            var interactor = GetService<IRequestHandler<ReadEmployeeByLINQMappingRequestMessage, ReadEmployeeByLINQMappingResponseMessage>>();

            TimeCheck.Start();
            var response = interactor.Handle(request, CancellationToken.None).Result;
            TimeCheck.Stop();

            Debug.WriteLine($"ReadEmployeeByLINQMapping took {TimeCheck.ElapsedMilliseconds} ms");
            TestOut(response);
        }
    }
}
