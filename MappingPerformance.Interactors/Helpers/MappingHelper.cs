using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MappingPerformance.Interactors.Helpers
{
    public static class MappingHelper
    {
        public static T MappingObject<T>(object sourceObject) where T : class
        {
            var sourceObjPropList = sourceObject.GetType().GetProperties();
            var targetObjPropList = typeof(T).GetProperties();
            T returnObject = (T)Activator.CreateInstance(typeof(T));

            foreach(PropertyInfo prop in sourceObjPropList)
            {
                if(targetObjPropList.Any(i => i.Name == prop.Name && i.PropertyType == prop.PropertyType))
                {
                    var value = prop.GetValue(sourceObject);
                    var choosePropOnTarget = targetObjPropList.First(i => i.Name == prop.Name && i.PropertyType == prop.PropertyType);
                    choosePropOnTarget.SetValue(returnObject, value);
                }
            }

            return returnObject;
        }
    }
}
