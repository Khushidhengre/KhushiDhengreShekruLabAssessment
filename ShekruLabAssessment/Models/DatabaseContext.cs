using Microsoft.EntityFrameworkCore;

namespace ShekruLabAssessment.Models
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<Employees> employees { get; set; }


        public virtual DbSet<Display> display { get; set; }
        public virtual DbSet<Designation> designation { get; set; }
        public virtual DbSet<DesignationGrade> designationgrade { get; set; }

    }
}
