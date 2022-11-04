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
    public class ReadEmployeeWithAutoMapperTest : BaseTestClass
    {
        [TestMethod]
        public void Handle()
        {
            Stopwatch TimeCheck = new Stopwatch();
            var interactor = GetService<IRequestHandler<ReadEmployeeByAutoMapperRequestMessage, ReadEmployeeByAutoMapperResponseMessage>>();
            ReadEmployeeByAutoMapperRequestMessage request = new ReadEmployeeByAutoMapperRequestMessage();

            TestOut(request);

            TimeCheck.Start();
            var response = interactor.Handle(request, CancellationToken.None).Result;
            TimeCheck.Stop();

            Debug.WriteLine($"ReadEmployeesWithoutMapping took  {TimeCheck.ElapsedMilliseconds} ms");

            TestOut(response);
        }
    }
}
