using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.CategoryVM
{
    public class CategoryListVM
    {
        public  int Id { get; set; }
        public  string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public  string? UpdateDate { get; set; } = DateTime.Now.ToString("d");

        public string Name { get; set; } = null!;

        
    }
}
