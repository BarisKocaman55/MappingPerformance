using MappingPerformance.Interactors.Interactors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly IRequestHandler<ReadEmployeeByAutoMapperRequestMessage, ReadEmployeeByAutoMapperResponseMessage> ReadEmployeeWithAutoMapperInteractor;
        private readonly IRequestHandler<ReadEmployeeWithMapsterRequestMessage, ReadEmployeeWithMapsterResponseMessage> ReadEmployeeWithMapsterInteractor;
        private readonly IRequestHandler<ReadEmployeeByLINQMappingRequestMessage, ReadEmployeeByLINQMappingResponseMessage> ReadEmployeeByLINQMappingInteractor;

        public EmployeeController(ILogger<EmployeeController> logger,
            IRequestHandler<ReadEmployeeWithOutMappingRequestMessage, ReadEmployeeWithOutMappingResponseMessage> readEmployeeWithoutInteractor,
            IRequestHandler<ReadEmployeeByMappingRequestMessage, ReadEmployeeByMappingResponseMessage> readEmployeeWithMappingInteractor,
            IRequestHandler<ReadEmployeeByIdRequestMessage, ReadEmployeeByIdResponseMessage> readEmployeeByIdInteractor,
            IRequestHandler<ReadEmployeeByAutoMapperRequestMessage, ReadEmployeeByAutoMapperResponseMessage> readEmployeeWithAutoMapperInteractor,
            IRequestHandler<ReadEmployeeWithMapsterRequestMessage, ReadEmployeeWithMapsterResponseMessage> readEmployeeWithMapsterInteractor,
            IRequestHandler<ReadEmployeeByLINQMappingRequestMessage, ReadEmployeeByLINQMappingResponseMessage> readEmployeeByLINQMappingInteractor)
        {
            Logger = logger;
            ReadEmployeeWithoutMappingInteractor = readEmployeeWithoutInteractor;
            ReadEmployeeWithMappingInteractor = readEmployeeWithMappingInteractor;
            ReadEmployeeByIdInteractor = readEmployeeByIdInteractor;
            ReadEmployeeWithAutoMapperInteractor = readEmployeeWithAutoMapperInteractor;
            ReadEmployeeWithMapsterInteractor = readEmployeeWithMapsterInteractor;
            ReadEmployeeByLINQMappingInteractor = readEmployeeByLINQMappingInteractor;
        }

        [HttpGet]
        [Route("getEmployeesWithoutMapping")]
        public ReadEmployeeWithOutMappingResponseMessage GetEmployeeWithoutMapping([FromRoute] ReadEmployeeWithOutMappingRequestMessage request)
        {
            Logger.LogInformation("GetEmployeeWithoutMapping Controller - start");

            var response = ReadEmployeeWithoutMappingInteractor.Handle(request, CancellationToken.None).Result;

            Logger.LogInformation($"GetEmployeeWithoutMapping Controller - response - {JsonConvert.SerializeObject(response)}");
            Logger.LogInformation("GetEmployeeWithoutMapping Controller - end");
            return response;
        }

        [HttpGet]
        [Route("getEmployeesWithMapping")]
        public ReadEmployeeByMappingResponseMessage GetEmployeeWithtMapping([FromRoute] ReadEmployeeByMappingRequestMessage request)
        {
            Logger.LogInformation("GetEmployeeWithtMapping Controller - start");

            var response = ReadEmployeeWithMappingInteractor.Handle(request, CancellationToken.None).Result;

            Logger.LogInformation($"GetEmployeeWithtMapping Controller - response - {JsonConvert.SerializeObject(response)}");
            Logger.LogInformation("GetEmployeeWithtMapping Controller - end");
            return response;
        }

        [HttpGet]
        [Route("getEmployeeWithAutoMapper")]
        public ReadEmployeeByAutoMapperResponseMessage GetEmployeeWithAutoMapper([FromRoute] ReadEmployeeByAutoMapperRequestMessage request)
        {
            Logger.LogInformation("GetEmployeeWithAutoMapper Controller - start");

            var response = ReadEmployeeWithAutoMapperInteractor.Handle(request, CancellationToken.None).Result;

            Logger.LogInformation($"GetEmployeeWithAutoMapper Controller - response - {JsonConvert.SerializeObject(response)}");
            Logger.LogInformation("GetEmployeeWithAutoMapper Controller - end");
            return response;
        }

        [HttpGet]
        [Route("getEmployeeWithMapster")]
        public ReadEmployeeWithMapsterResponseMessage GetEmployeeWithMapster([FromRoute] ReadEmployeeWithMapsterRequestMessage request)
        {
            Logger.LogInformation("GetEmployeeWithMapster Controller - start");

            var response = ReadEmployeeWithMapsterInteractor.Handle(request, CancellationToken.None).Result;

            Logger.LogInformation($"GetEmployeeWithMapster Controller - response - {JsonConvert.SerializeObject(response)}");
            Logger.LogInformation("GetEmployeeWithMapster Controller - end");
            return response;
        }

        [HttpGet]
        [Route("getEmployeeWithLINQMapping")]
        public ReadEmployeeByLINQMappingResponseMessage GetEmployeeByLINQMapping([FromRoute] ReadEmployeeByLINQMappingRequestMessage request)
        {
            Logger.LogInformation("GetEmployeeByLINQMapping Controller - start");

            var response = ReadEmployeeByLINQMappingInteractor.Handle(request, CancellationToken.None).Result;

            Logger.LogInformation($"GetEmployeeByLINQMapping Controller - response - {JsonConvert.SerializeObject(response)}");
            Logger.LogInformation("GetEmployeeByLINQMapping Controller - end");
            return response;
        }

        [HttpGet]
        [Route("getEmployeeById/{Id}")]
        public ReadEmployeeByIdResponseMessage ReadEmployeeById([FromRoute] ReadEmployeeByIdRequestMessage request)
        {
            Logger.LogInformation("ReadEmployeeById Controller - start");
            Logger.LogInformation($"ReadEmployeeById Controller - request - {request}");
            
            var response = ReadEmployeeByIdInteractor.Handle(request, CancellationToken.None).Result;
            
            Logger.LogInformation($"ReadEmployeeById Controller - response - {JsonConvert.SerializeObject(response)}");
            Logger.LogInformation("ReadEmployeeById Controller - end");
            return response;
        }
    }
}
