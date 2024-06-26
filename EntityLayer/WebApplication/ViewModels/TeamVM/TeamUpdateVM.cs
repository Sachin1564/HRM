﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.TeamVM
{
    public class TeamUpdateVM
    {
        public int Id { get; set; }
        public string? UpdateDate { get; set; } = DateTime.Now.ToString("d");
        public byte[] RowVersion { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public string Twitter { get; set; } = null!;
        public string Linkedin { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string Instagram { get; set; } = null!;
    }
}
