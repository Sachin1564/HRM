using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.CategoryVM
{
    public class CategoryUpdateVM
    {
        public int Id { get; set; }

        public string? UpdateDate { get; set; } = DateTime.Now.ToString("d");

        public byte[] RowVersion { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
