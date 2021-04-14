using Course.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Course.Service
{
    public static class ServiceManager
    {
        public static IService GetByName(string name)
        {
            string serviceName = name.ToService();
            var types = GetTypes("Course.Service.Services");
            var serviceType = types.FirstOrDefault(x => x.Name == serviceName);

            if (serviceType == null)
                throw new ApplicationException("Serviço não encontrado.");

            ConstructorInfo ctor = serviceType.GetConstructor(System.Type.EmptyTypes);
            IService instance = (IService) ctor.Invoke(null);
            return instance;
        }

        public static List<Type> GetTypes(string nameSpace)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.GetTypes()
                .Where(type => type.Namespace == nameSpace).ToList();
        }

        public static List<string> GetServices()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.GetTypes()
                .Where(type => type.Namespace == "Course.Service.Services")
                .Select(x => x.Name)
                .ToList();
        }
    }
}
