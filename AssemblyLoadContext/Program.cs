using System;
using System.Linq;
using System.Reflection;

namespace NETCoreAssemblyLoad
{
    class Program
    {
         static int Main(string[] args)
        {
            //Assembly assembly =
            //    AssemblyLoadContext.Default.LoadFromAssemblyPath(args[0]);

            //PrintTypes(assembly);
            //return 0;
            using (var dynamicContext = new AssemblyResolver(args[0]))
            {
                PrintTypes(dynamicContext.Assembly);
            }
            return 0;
        }

        private static void PrintTypes(Assembly assembly)
        {
            foreach (TypeInfo type in assembly.DefinedTypes)
            {
                Console.WriteLine(type.Name);
                foreach (PropertyInfo property in type.DeclaredProperties)
                {
                    string attributes = string.Join(
                        ", ",
                        property.CustomAttributes.Select(a => a.AttributeType.Name));

                    if (!string.IsNullOrEmpty(attributes))
                    {
                        Console.WriteLine("    [{0}]", attributes);
                    }
                    Console.WriteLine("    {0} {1}", property.PropertyType.Name, property.Name);
                }
            }
        }
    }
}
