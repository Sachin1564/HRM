using EntityLayer.WebApplication.ViewModels.AboutVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.SocialMediaVM
{
    public class SocialMediaUpdateVM
    {
        public int Id { get; set; }
        public string? UpdateDate { get; set; } = DateTime.Now.ToString("d");
        public byte[] RowVersion { get; set; } = null!;
        public string Twitter { get; set; } = null!;
        public string Linkedin { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string Instagram { get; set; } = null!;
        public AboutUpdateVM About { get; set; } = null!;
    }
}
