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
    public class StaffMemberContext : DbContext
    {
        public StaffMemberContext() : base("MySqlConnection") { }
        public DbSet<Officer> StaffMember { get; set; }
    }
    [Table("StaffMember")]
    public class Officer
    {
        public string FIRST_NAME { get; set; }
        public string SURNAME { get; set; }
        [Key]
        public string ID { get; set; }
        public string LEVEL { get; set; }
        public string AMBULANCE_ID { get; set; }

    }
}
