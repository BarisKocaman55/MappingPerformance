using System;
using System.Collections.Generic;
using System.Text;

namespace MappingPerformance.Adapters.DataAccess
{
    public class RepositoryBase
    {
        protected static DatabaseContext db;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {
            db = CreateContext();
        }

        private static DatabaseContext CreateContext()
        {
            if(db == null)
            {
                lock(_lockSync)
                {
                    if(db == null)
                    {
                        db = new DatabaseContext();
                    }
                }
            }

            return db;
        }
    }
}
