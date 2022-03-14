using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AboutUs:Base
    {
        [Column(TypeName = "nvarchar(800)")]
        [Display(Name = "Haqqımızda")]
        public string Description { get; set; }
        [MaxLength(800)]
        [Display(Name = "Şəkil")]
        public string CompanyPhoto { get; set; }
    }
}
