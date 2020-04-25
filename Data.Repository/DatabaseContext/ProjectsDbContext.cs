using Data.Repository.DatabaseContext.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.DatabaseContext
{
   public class ProjectsDbContext : DbContext
    {

        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectDurationMap());
        }
    }
}
