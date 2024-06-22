using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Identity.Entities
{
    public class AppRole : IdentityRole

    {
        public string? FileName { get; set; }
        public string? FileType {  get; set; }
    }
}
