using MappingPerformance.Entities;
using MappingPerformance.Entities.Models;
using MappingPerformance.Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MappingPerformance.Interactors.Interactors
{
    public class ReadEmployeeByLINQMappingInteractor : IRequestHandler<ReadEmployeeByLINQMappingRequestMessage, ReadEmployeeByLINQMappingResponseMessage>
    {
        public async Task<ReadEmployeeByLINQMappingResponseMessage> Handle(ReadEmployeeByLINQMappingRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                List<Employee> employees = EmploeeService.GetEmployees();
                if(employees != null && employees.Count > 0)
                {
                    List<EmployeeInformation> result = employees.Select(employeeInfo => new EmployeeInformation 
                    {
                         FirstName = employeeInfo.FirstName,
                         LastName = employeeInfo.LastName,
                         Gender = employeeInfo.Gender,
                         DOB = employeeInfo.DOB,
                         Phone = employeeInfo.Phone,
                         Email = employeeInfo.Email,
                         Title = employeeInfo.Title
                    }).ToList();

                    if (result != null && result.Count > 0)
                        return new ReadEmployeeByLINQMappingResponseMessage(result);

                    return new ReadEmployeeByLINQMappingResponseMessage(null, "Employee information is null or empty after mapping");
                }

                return new ReadEmployeeByLINQMappingResponseMessage(null, "Employee list is null or empty...");
            }

            catch(Exception exp)
            {
                return new ReadEmployeeByLINQMappingResponseMessage(null, exp.Message);
            }
        }
    }

    public class ReadEmployeeByLINQMappingRequestMessage : IRequest<ReadEmployeeByLINQMappingResponseMessage>
    {

    }

    public class ReadEmployeeByLINQMappingResponseMessage
    {
        public List<EmployeeInformation> Result { get; set; }
        public string Error { get; set; }
        public bool IsFaulted => !string.IsNullOrEmpty(Error);

        public ReadEmployeeByLINQMappingResponseMessage(List<EmployeeInformation> result, string error = null)
        {
            Result = result;
            Error = error;
        }
    }
}
