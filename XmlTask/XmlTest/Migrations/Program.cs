using Migrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new RequestsContext())
            {
                db.Requests.Add(new Requests { Index = 5, Name = "Another Blog ", Visits = null, Date = DateTime.Now });
                db.SaveChanges();

                var requests = db.Requests;

                foreach (var request in db.Requests)
                {
                    Console.WriteLine(request.Name);
                }

                var s = db.Database.Connection.Database;
                var t = db.Database.Connection.ConnectionString;
                var c = requests.Count();


            }

            //Console.WriteLine("Hello World!");
            //Console.ReadKey();
        }
    }
}
