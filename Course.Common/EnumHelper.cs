using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Course.Common
{
    public class EnumHelper
    {
        public static Dictionary<string, List<EnumData>> GetServicesByNameSpace(string nameSpace)
        {
            var allEnums = new Dictionary<string, List<EnumData>>();

            var enumTypes = GetEnumTypes(nameSpace);

            foreach (var enumType in enumTypes)
            {
                var enumValues = new List<EnumData>();

                var convertedEnum = Enum.GetValues(enumType);

                foreach (var value in convertedEnum)
                {
                    enumValues.Add(new EnumData
                    {
                        Description = value.GetEnumDescription(),
                        Value = value.ToString()
                    });
                }
                allEnums.Add(enumType.Name, enumValues);
            }
            return allEnums;
        }

        public static List<Type> GetEnumTypes(string nameSpace)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.GetTypes()
                .Where(type => type.Namespace == nameSpace).ToList();
        }

        public class EnumData
        {
            public string Description { get; set; }
            public string Value { get; set; }
        }
    }
}
