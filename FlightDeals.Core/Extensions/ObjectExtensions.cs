using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FlightDeals.Core.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>       
        /// Retrieves the default value for a given Type
        /// </summary>       
        /// <remarks>
        ///  If a value type is supplied which is not publicly visible or which contains generic parameters, this method will fail with an 
        /// exception.
        /// </remarks>      
        public static object GetDefault(this Type type)
        {
            // If no Type was supplied, if the Type was a reference type, or if the Type was a System.Void, return null
            if (type == null || !type.IsValueType || type == typeof(void))
                return null;

            // If the supplied Type has generic parameters, its default value cannot be determined
            if (type.ContainsGenericParameters)
                throw new ArgumentException(
                    "{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" + type +
                    "> contains generic parameters, so the default value cannot be retrieved");

            // If the Type is a primitive type, or if it is another publicly-visible value type (i.e. struct), return a 
            //  default instance of the value type
            if (type.IsPrimitive || !type.IsNotPublic)
            {
                try
                {
                    return Activator.CreateInstance(type);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(
                        "{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nThe Activator.CreateInstance method could not " +
                        "create a default instance of the supplied value type <" + type +
                        "> (Inner Exception message: \"" + e.Message + "\")", e);
                }
            }

            // Fail with exception
            throw new ArgumentException("{" + MethodInfo.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" + type +
                "> is not a publicly-visible type, so the default value cannot be retrieved");
        }


        public static Dictionary<string, string> ToDictionary(this object obj)
        {
            var dictionary = new Dictionary<string, string>();
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties.Where(p => p.GetValue(obj) != null && !p.GetValue(obj).Equals(p.PropertyType.GetDefault())))
            {
                dictionary.Add(property.Name, property.GetValue(obj).ToString());
            }

            return dictionary;

        }
    }
}
