using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration.WebApplication
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            //builder.Property(x => x.Twitter).IsRequired().HasMaxLength(10);
            //builder.Property(x => x.Linkedin).IsRequired().HasMaxLength(10);
            //builder.Property(x => x.Facebook).IsRequired().HasMaxLength(10);
            //builder.Property(x => x.Instagram).IsRequired().HasMaxLength(10);

            builder.HasData(new SocialMedia
            {
                Id = 1,
                Facebook = "testFacebook",
                Instagram = "testInstagram",
                Linkedin = "testLinkedin",
                Twitter = "testTwitter"
            }
                );

        }
    }
}
