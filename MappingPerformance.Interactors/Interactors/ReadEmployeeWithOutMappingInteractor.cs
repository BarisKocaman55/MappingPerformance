using FluentValidation;
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
    public class ReadEmployeeWithOutMappingInteractor : IRequestHandler<ReadEmployeeWithOutMappingRequestMessage, ReadEmployeeWithOutMappingResponseMessage>
    {
        public async Task<ReadEmployeeWithOutMappingResponseMessage> Handle(ReadEmployeeWithOutMappingRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                List<Employee> employeeList = EmploeeService.GetEmployees();
                if(employeeList != null && employeeList.Count > 0)
                {
                    List<EmployeeInformation> result = new List<EmployeeInformation>();
                    foreach(Employee employee in employeeList)
                    {
                        EmployeeInformation employeeInformation = new EmployeeInformation()
                        {
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Gender = employee.Gender,
                            Title = employee.Title,
                            Email = employee.Email,
                            Phone = employee.Phone,
                            DOB = employee.DOB
                        };

                        result.Add(employeeInformation);
                    }

                    return new ReadEmployeeWithOutMappingResponseMessage(null, result);
                }

                return new ReadEmployeeWithOutMappingResponseMessage("Employee List is null or empty...");
            }
            catch(Exception exp)
            {
                return new ReadEmployeeWithOutMappingResponseMessage(exp.Message);
            }
        }
    }

    public class ReadEmployeeWithOutMappingRequestMessage : IRequest<ReadEmployeeWithOutMappingResponseMessage>
    {
        
    }

    public class ReadEmployeeWithOutMappingResponseMessage
    {
        public List<EmployeeInformation> Result { get; set; }
        public string Error { get; set; }
        public bool IsFaulted => !string.IsNullOrEmpty(Error);

        public ReadEmployeeWithOutMappingResponseMessage(string error, List<EmployeeInformation> result = null)
        {
            Result = result;
            Error = error;
        }
    }
}
