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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //Set Primary Key
            builder.HasKey(p => p.Id);

            //Set Property configurations
            builder.Property(p => p.Title)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.ShortDescription)
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                  .HasMaxLength(5000);

            builder.Property(p => p.ShortDescription)
                  .HasMaxLength(100);



            //Set Relationship configurations
            builder.HasMany(p => p.PostImages)
                   .WithOne(pi => pi.Post)
                   .HasForeignKey(p => p.PostId);

            // Category to SubCategory (One-to-Many)
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);


        }
    }
}
