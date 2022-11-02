using MappingPerformance.Interactors.Interactors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace MappingPerformance.Controllers
{
    [ApiController]
    [Route("api/employee/")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> Logger;
        private readonly IRequestHandler<ReadEmployeeWithOutMappingRequestMessage, ReadEmployeeWithOutMappingResponseMessage> ReadEmployeeWithoutMappingInteractor;
        private readonly IRequestHandler<ReadEmployeeByMappingRequestMessage, ReadEmployeeByMappingResponseMessage> ReadEmployeeWithMappingInteractor;
        private readonly IRequestHandler<ReadEmployeeByIdRequestMessage, ReadEmployeeByIdResponseMessage> ReadEmployeeByIdInteractor;

        public EmployeeController(ILogger<EmployeeController> logger,
            IRequestHandler<ReadEmployeeWithOutMappingRequestMessage, ReadEmployeeWithOutMappingResponseMessage> readEmployeeWithoutInteractor,
            IRequestHandler<ReadEmployeeByMappingRequestMessage, ReadEmployeeByMappingResponseMessage> readEmployeeWithMappingInteractor,
            IRequestHandler<ReadEmployeeByIdRequestMessage, ReadEmployeeByIdResponseMessage> readEmployeeByIdInteractor)
        {
            Logger = logger;
            ReadEmployeeWithoutMappingInteractor = readEmployeeWithoutInteractor;
            ReadEmployeeWithMappingInteractor = readEmployeeWithMappingInteractor;
            ReadEmployeeByIdInteractor = readEmployeeByIdInteractor;
        }

        [HttpGet]
        [Route("getEmployeesWithoutMapping")]
        public ReadEmployeeWithOutMappingResponseMessage GetEmployeeWithoutMapping([FromBody] ReadEmployeeWithOutMappingRequestMessage request)
        {
            Logger.LogInformation("GetEmployeeWithoutMapping Controller start");
            return ReadEmployeeWithoutMappingInteractor.Handle(request, CancellationToken.None).Result;
        }

        [HttpGet]
        [Route("getEmployeesWithMapping")]
        public ReadEmployeeByMappingResponseMessage GetEmployeeWithtMapping([FromBody] ReadEmployeeByMappingRequestMessage request)
        {
            return ReadEmployeeWithMappingInteractor.Handle(request, CancellationToken.None).Result;
        }

        [HttpGet]
        [Route("getEmployeeById")]
        public ReadEmployeeByIdResponseMessage ReadEmployeeById([FromBody] ReadEmployeeByIdRequestMessage request)
        {
            return ReadEmployeeByIdInteractor.Handle(request, CancellationToken.None).Result;
        }
    }
}
