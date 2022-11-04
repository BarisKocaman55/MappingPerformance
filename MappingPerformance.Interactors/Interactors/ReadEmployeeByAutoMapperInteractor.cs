using AutoMapper;
using MappingPerformance.Entities;
using MappingPerformance.Entities.Models;
using MappingPerformance.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MappingPerformance.Interactors.Interactors
{
    public class ReadEmployeeByAutoMapperInteractor : IRequestHandler<ReadEmployeeByAutoMapperRequestMessage, ReadEmployeeByAutoMapperResponseMessage>
    {
        private readonly IMapper _mapper;

        public ReadEmployeeByAutoMapperInteractor(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ReadEmployeeByAutoMapperResponseMessage> Handle(ReadEmployeeByAutoMapperRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                List<Employee> employees = EmploeeService.GetEmployees();
                if(employees != null && employees.Count > 0)
                {
                    var result = _mapper.Map<List<EmployeeInformation>>(employees);
                   
                    if (result != null && result.Count > 0)
                        return new ReadEmployeeByAutoMapperResponseMessage(result);

                    return new ReadEmployeeByAutoMapperResponseMessage(null, "Mapping error...");
                }

                return new ReadEmployeeByAutoMapperResponseMessage(null ,"Employee list is null or empty...");
            }

            catch(Exception exp)
            {
                return new ReadEmployeeByAutoMapperResponseMessage(null, exp.Message);
            }
        }
    }

    public class ReadEmployeeByAutoMapperRequestMessage : IRequest<ReadEmployeeByAutoMapperResponseMessage>
    {

    }

    public class ReadEmployeeByAutoMapperResponseMessage
    {
        public List<EmployeeInformation> Result { get; set; }
        public string Error { get; set; }
        public bool IsFaulted => !string.IsNullOrEmpty(Error);

        public ReadEmployeeByAutoMapperResponseMessage(List<EmployeeInformation> result, string error = null)
        {
            Result = result;
            Error = error;
        }
    }
}
