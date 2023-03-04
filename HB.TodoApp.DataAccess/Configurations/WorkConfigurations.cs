using HB.TodoApp.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.TodoApp.DataAccess.Configurations
{
    public class WorkConfigurations : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {

            builder.Property(x => x.Defination).HasMaxLength(300);
            builder.Property(x => x.Defination).IsRequired(true);
            builder.Property(x=>x.IsCompleted).IsRequired(true);

        }
    }
}
