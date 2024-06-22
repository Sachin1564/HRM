using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.CandidateVM
{
    public class CandidateUpdateVM
    {
        public int Id { get; set; }

        public string? UpdateDate { get; set; } = DateTime.Now.ToString("d");

        public byte[] RowVersion { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public int Phone { get; set; }

        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public int ZipCode { get; set; }
        public string EducationLevel { get; set; } = null!;
        public string University { get; set; } = null!;
        public string Major { get; set; } = null!;
        public DateTime GraduationDate { get; set; }

        // Work Experience
        public string WorkExperience { get; set; } = null!;

        // Skills
        public string Skills { get; set; } = null!;

    }
}
