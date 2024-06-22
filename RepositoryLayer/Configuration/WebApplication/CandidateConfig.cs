using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configuration.WebApplication
{
    public class CandidateConfig : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

         
            builder.Property(x=> x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x=> x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x=> x.DateOfBirth).IsRequired().HasMaxLength(10);
            builder.Property(x=> x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(1000);
            builder.Property(x=> x.City).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.State).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(8);
            builder.Property(x => x.EducationLevel).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.University).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Major).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.GraduationDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.WorkExperience).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Skills).IsRequired().HasMaxLength(1000);


          
        }
    }
}
