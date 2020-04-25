using Data.Repository.DatabaseContext;
using Domain.Core.Repositories;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Repositories
{
    public class ProjectRepository : EfGenericRepository<ProjectDuration>, IProjectRepository
    {
        public ProjectRepository(ProjectsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
