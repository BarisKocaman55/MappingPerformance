using MappingPerformance.Interactors.Interactors;
using MappingPerformance.Test.Base;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MappingPerformance.Test.Tests
{
    [TestClass]
    public class ReadEmployeeByMappingInteractorTest : BaseTestClass
    {
        [TestMethod]
        public void Handle()
        {
            Stopwatch TimeCheck = new Stopwatch();
            var interactor = GetService<IRequestHandler<ReadEmployeeByMappingRequestMessage, ReadEmployeeByMappingResponseMessage>>();
            var request = new ReadEmployeeByMappingRequestMessage();

            TestOut(request);

            TimeCheck.Start();
            var response = interactor.Handle(request, CancellationToken.None);
            TimeCheck.Stop();

            Debug.WriteLine($"ReadEmployeeByMappingInteractor took {TimeCheck.ElapsedMilliseconds} ms");

            TestOut(response);
        }
    }
}
