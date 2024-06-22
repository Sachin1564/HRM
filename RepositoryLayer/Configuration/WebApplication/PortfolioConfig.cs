﻿
using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration.WebApplication
{
    public class PortfolioConfig : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {

            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Portfolio
            {
                Id = 1,
                CategoryId = 1,
                FileName = "Test",
                FileType = "Test",
                Title = "Test Picture"
            },
            new Portfolio
            {
                Id = 2,
                CategoryId = 1,
                FileName = "Test2",
                FileType = "Test2",
                Title = "Test Picture2"
            },
            new Portfolio
            {
                Id = 3,
                CategoryId = 2,
                FileName = "Test3",
                FileType = "Test3",
                Title = "Test Picture3"
            },
            new Portfolio
            {
                Id = 4,
                CategoryId = 3,
                FileName = "Test4",
                FileType = "Test4",
                Title = "Test Picture4"
            }
            );
        }
    }
}
