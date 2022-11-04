using MappingPerformance.Interactors.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MappingPerformance.MappingPerformanceBenchMark.IService
{
    public interface IMappingPerformance
    {
        void ReadEmployeeByMappingInteractorPerformance();
        void ReadEmployeeWithOutMappingInteractorPerformance();
    }
}
