using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Blog:Base
    {
        [MaxLength(800)]
        [Display(Name = "Şəkil")]
        public string? BlogPhoto { get; set; }
        [Display(Name = "Yaradılma Tarixi")]
        public DateTime PublishDate { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        [Display(Name = "Bloq Adı")]
        public string HeaderText { get; set; }
        [Column(TypeName = "nvarchar(600)")]
        [Display(Name = "Haqqında")]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
