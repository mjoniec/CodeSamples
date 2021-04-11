using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
            args.FirstOrDefault()
            ?? "Server=(local)\\SqlExpress; Database=XmlTest; Trusted_connection=true";

            var upgrader = DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
