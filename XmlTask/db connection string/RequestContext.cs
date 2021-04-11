using Data.Access.Model;
using System.Data.Entity;

namespace Data.Access.Contexts
{
    public class RequestContext : DbContext
    {
        public RequestContext()
        {
            Database.Connection.ConnectionString = "Server = tcp:marjondemoserver.database.windows.net,1433; Initial Catalog = XmlTest; Persist Security Info = False; User ID = mjoniec; Password = paste here; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }

        public DbSet<Request> Requests { get; set; }
    }
}
