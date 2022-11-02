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
using System.Linq;
using MappingPerformance.Interactors.Helpers;

namespace MappingPerformance.Interactors.Interactors
{
    public class ReadEmployeeByIdInteractor : IRequestHandler<ReadEmployeeByIdRequestMessage, ReadEmployeeByIdResponseMessage>
    {
        public async Task<ReadEmployeeByIdResponseMessage> Handle(ReadEmployeeByIdRequestMessage request, CancellationToken cancellationToken)
        {
            var validator = new ReadEmployeeByIdValidator();
            var isValidated = validator.Validate(request);

            if (!isValidated.IsValid)
                return new ReadEmployeeByIdResponseMessage(null, "Request is not valid...");

            try
            {
                List<Employee> employeeList = EmploeeService.GetEmployees();
                if(employeeList != null && employeeList.Count > 0)
                {
                    var employee = employeeList.Where(i => i.Id == request.Id).FirstOrDefault();
                    if(employee != null)
                    {
                        var employeeResult = MappingHelper.MappingObject<EmployeeInformation>(employee);
                        return new ReadEmployeeByIdResponseMessage(employeeResult);
                    }
                    return new ReadEmployeeByIdResponseMessage(null, "Employee could not be found...");
                }

                return new ReadEmployeeByIdResponseMessage(null, "Employee list is null or empty...");
            }
            catch(Exception exp)
            {
                return new ReadEmployeeByIdResponseMessage(null, exp.Message);
            }
        }
    }

    public class ReadEmployeeByIdRequestMessage : IRequest<ReadEmployeeByIdResponseMessage>
    {
        public int  Id { get; set; }
    }

    public class ReadEmployeeByIdResponseMessage
    {
        public EmployeeInformation Result { get; set; }
        public string Error { get; set; }
        public bool IsFaulted => !string.IsNullOrEmpty(Error);

        public ReadEmployeeByIdResponseMessage(EmployeeInformation result, string error = null)
        {
            Result = result;
            Error = error;
        }
    }

    public class ReadEmployeeByIdValidator : AbstractValidator<ReadEmployeeByIdRequestMessage>
    {
        public ReadEmployeeByIdValidator()
        {
            RuleFor(i => i.Id).NotNull().NotEmpty();
        }
    }
}
