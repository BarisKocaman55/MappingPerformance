using MappingPerformance.Entities;
using MappingPerformance.Entities.Models;
using MappingPerformance.Infrastructure.Services;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MappingPerformance.Interactors.Interactors
{
    public class ReadEmployeeWithMapsterInteractor : IRequestHandler<ReadEmployeeWithMapsterRequestMessage, ReadEmployeeWithMapsterResponseMessage>
    {
        public async Task<ReadEmployeeWithMapsterResponseMessage> Handle(ReadEmployeeWithMapsterRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                List<Employee> employees = EmploeeService.GetEmployees();
                if(employees != null && employees.Count > 0)
                {
                    var result = employees.Adapt<List<EmployeeInformation>>();
                    if (result != null && result.Count > 0)
                        return new ReadEmployeeWithMapsterResponseMessage(result);

                    return new ReadEmployeeWithMapsterResponseMessage(null, "result is null or empty after mapping...");
                }

                return new ReadEmployeeWithMapsterResponseMessage(null, "employee list is null or empty...");
            }

            catch(Exception exp)
            {
                return new ReadEmployeeWithMapsterResponseMessage(null, exp.Message);
            }
        }
    }

    public class ReadEmployeeWithMapsterRequestMessage : IRequest<ReadEmployeeWithMapsterResponseMessage>
    {

    }

    public class ReadEmployeeWithMapsterResponseMessage
    {
        public List<EmployeeInformation> Result { get; set; }
        public string Error { get; set; }
        public bool IsFaulted => !string.IsNullOrEmpty(Error);

        public ReadEmployeeWithMapsterResponseMessage(List<EmployeeInformation> result, string error = null)
        {
            Result = result;
            Error = error;
        }
    }
}
