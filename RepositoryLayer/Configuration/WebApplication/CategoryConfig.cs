﻿
using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration.WebApplication
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasData(new Category
            {
                Id = 1,
                Name = "Project",
            }, new Category
            {
                Id = 2,
                Name = "Siteworks",
            }
            );
        }
    }
}
