using System;
using System.Reflection;

namespace Course
{
    public class Extensions
    {
        /// <summary>
        /// Rotina capaz de chamar qualquer método presente no escopo desta classe pelo nome (via <see cref="string"/>)
        /// </summary>
        public static void CallByName(string methodName, string param = null)
        {
            var program = new Program();
            Type type = program.GetType();
            MethodInfo methodInfo = type.GetMethod(methodName);
            if (methodInfo != null)
            {
                if (param != null)
                    methodInfo.Invoke(program, new object[] { param });
                else
                    methodInfo.Invoke(program, new object[] { });
            }
            else
            {
                Console.WriteLine("Método não encontrado!");
            }
        }
    }
}
