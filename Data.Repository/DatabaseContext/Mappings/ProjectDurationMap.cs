using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.DatabaseContext.Mappings
{
    public class ProjectDurationMap : IEntityTypeConfiguration<ProjectDuration>
    {
        public void Configure(EntityTypeBuilder<ProjectDuration> builder)
        {
            builder.HasKey(x => new { x.Id });
        }


    }
}
