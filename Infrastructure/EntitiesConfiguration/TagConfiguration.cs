using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntitiesConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            //Set Primary Key
            builder.HasKey(t => t.Id);

            //Set Property configurations
            builder.Property(t => t.Name)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(t => t.Description)
                   .HasMaxLength(300);


        }
    }
}
