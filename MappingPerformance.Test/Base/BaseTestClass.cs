using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unity;

namespace MappingPerformance.Test.Base
{
    public abstract class BaseTestClass
    {
        private TestContext _textContext;

        public TestContext TestContext
        {
            get { return _textContext; }
            set { _textContext = value; }
        }

        protected IUnityContainer Container
        {
            get { return UnityConfig.GetUnityContainer(); }
        }

        protected T GetService<T>() => Container.Resolve<T>();

        protected void TestOut(object value)
        {
            var json = JsonConvert.SerializeObject(value);
            TestContext.WriteLine(JToken.Parse(json).ToString(Formatting.Indented));
        }
    }
}
