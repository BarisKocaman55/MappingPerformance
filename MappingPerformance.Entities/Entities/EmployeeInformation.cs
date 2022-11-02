using System;

namespace MappingPerformance.Entities
{
    public class EmployeeInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
    }
}
