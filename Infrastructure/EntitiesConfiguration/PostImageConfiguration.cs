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
    public class PostImageConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            //Set Primary Key
            builder.HasKey(p => p.Id);

           
            // Category to SubCategory (One-to-Many)
            builder
                .HasOne(p => p.Post)
                .WithMany(c => c.PostImages)
                .HasForeignKey(p => p.PostId);


        }
    }
}
