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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Set Primary Key
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasIdentityOptions(startValue: 100);

            //Set Property configurations
            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Description)
                  .HasMaxLength(300);


            //Set Relationship configurations
            builder.HasMany(p => p.Posts)
                   .WithOne(pi => pi.Category)
                   .HasForeignKey(p => p.CategoryId);


        }
    }
}
