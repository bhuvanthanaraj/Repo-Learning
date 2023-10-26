using Learning.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Learning.DataDBContext
{

    public class LearningDbContext : DbContext
    {
        public LearningDbContext(DbContextOptions options) : base(options)
        {
        }
       
        public DbSet<Tag> Tags { get; set; }


    }


}
