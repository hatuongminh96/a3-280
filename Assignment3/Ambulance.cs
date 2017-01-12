using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3
{
    public class AmbulanceContext : DbContext
    {
        public AmbulanceContext() : base("MySqlConnection") { }
        public DbSet<Ambulance> Ambulance { get; set; }
    }
    [Table("Ambulance")]
    public class Ambulance
    {
        [Key]
        public string a_id { get; set; }
        public string station { get; set; }
    }
}
