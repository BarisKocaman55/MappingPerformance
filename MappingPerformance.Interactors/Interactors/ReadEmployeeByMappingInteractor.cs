using FluentValidation;
using MappingPerformance.Entities;
using MappingPerformance.Entities.Models;
using MappingPerformance.Infrastructure.Services;
using MappingPerformance.Interactors.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MappingPerformance.Interactors.Interactors
{
    public class ReadEmployeeByMappingInteractor : IRequestHandler<ReadEmployeeByMappingRequestMessage, ReadEmployeeByMappingResponseMessage>
    {
        public async Task<ReadEmployeeByMappingResponseMessage> Handle(ReadEmployeeByMappingRequestMessage request, CancellationToken cancelletaionToken)
        {
            try
            {
                List<Employee> employeeList = EmploeeService.GetEmployees();
                if (employeeList != null && employeeList.Count > 0)
                {
                    List<EmployeeInformation> result = new List<EmployeeInformation>();
                    foreach (Employee employee in employeeList)
                    {
                        EmployeeInformation employeeInformation = MappingHelper.MappingObject<EmployeeInformation>(employee);
                        result.Add(employeeInformation);
                    }

                    return new ReadEmployeeByMappingResponseMessage(null, result);
                }

                return new ReadEmployeeByMappingResponseMessage("Employee List is null or empty...");
            }
            catch(Exception exp)
            {
                return new ReadEmployeeByMappingResponseMessage(exp.Message);
            }
        }
    }

    public class ReadEmployeeByMappingRequestMessage : IRequest<ReadEmployeeByMappingResponseMessage>
    {

    }

    public class ReadEmployeeByMappingResponseMessage
    {
        public List<EmployeeInformation> Result { get; set; }
        public string Error { get; set; }
        public bool IsFaulted => !string.IsNullOrEmpty(Error);

        public ReadEmployeeByMappingResponseMessage(string error, List<EmployeeInformation> result = null)
        {
            Result = result;
            Error = error;
        }
    }

    public class ReadEmployeeByMappingValidator : AbstractValidator<ReadEmployeeByMappingRequestMessage>
    {

    }
}
