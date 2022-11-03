using System;
using System.Collections.Generic;
using System.Text;

namespace MappingPerformance.Adapters.DataAccess
{
    public static class DbInitiliazer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
