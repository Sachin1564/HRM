using EntityLayer.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Configuration.Identity
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //var admin = Guid.Parse("070A9212-D4A9-44DA-8479-4EC813B63621").ToString(),
            //Email = "test.video.lesson@gmail.com",
            //NormalizedEmail = "TEST.VIDEO.LESSON@GMAIL.COM",
            //UserName = "TestAdmin",
            //NormalizedUserName = "TESTADMIN",
            //ConcurrencyStamp = Guid.NewGuid().ToString(),
            //SecurityStamp = Guid.NewGuid().ToString(),
         
        }
         
        
    }
}
