using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FormBuilder.Models.FormData>? Forms { get; set; }
        public DbSet<FormBuilder.Models.FormElement>? Elements { get; set; }
        public DbSet<FormBuilder.Models.FormValidation>? Validations { get; set; }
    }
}