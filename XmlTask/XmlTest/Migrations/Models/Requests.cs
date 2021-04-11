using System;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Migrations.Models
{
    public class RequestsContext : DbContext
    {
        public RequestsContext() : base("XmlTest2")
        {
            
        }

        public DbSet<Requests> Requests { get; set; }
    }

    [Table("requests")]
    public class Requests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Index { get; set; }
        public string Name { get; set; }
        public int? Visits { get; set; }
        public DateTime Date { get; set; }
    }
}
