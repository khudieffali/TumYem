using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Category:Base
    {
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Kateqoriya Adı")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(800)")]
        [Display(Name = "Şəkil")]
        public string? IconUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}
