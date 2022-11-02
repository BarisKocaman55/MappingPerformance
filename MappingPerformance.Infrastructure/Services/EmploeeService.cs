using MappingPerformance.Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MappingPerformance.Infrastructure.Services
{
    public static class EmploeeService
    {
        public static List<Employee> GetEmployees()
        {
            string employeeListOfJson = ConvertJsonFile();
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(employeeListOfJson);

            return employees;
        }

        public static string ConvertJsonFile()
        {
            string employeeJsonData = File.ReadAllText("C:/Users/baris/source/repos/MappingPerformanceSolution/MappingPerformance.Entities/JsonFormattedEntities/Employee.json");
            return employeeJsonData;
        }
    }
}
