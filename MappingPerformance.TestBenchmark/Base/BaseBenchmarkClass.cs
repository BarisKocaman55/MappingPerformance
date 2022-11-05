using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace MappingPerformance.TestBenchmark.Base
{
    public abstract class BaseBenchmarkClass
    {
        protected IUnityContainer Container
        {
            get { return UnityConfig.GetUnityContainer(); }
        }

        protected T GetService<T>() => Container.Resolve<T>();
    }
}
