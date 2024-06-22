using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.BaseEntities
{
    public abstract class BaseEntity : IBaseEntity
    {

        public virtual int Id { get; set; }

        public virtual string CreatedDate { get; set; } = DateTime.Now.ToString("d");

        public virtual string? UpdateDate { get; set; } = DateTime.Now.ToString("d");

        public virtual byte[] RowVersion { get; set; } = null!;

        public virtual string? Status { get; set; } = null!;
    }
}
