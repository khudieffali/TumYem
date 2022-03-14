using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product:Base
    {
        [Column(TypeName ="nvarchar(100)")]
        [Display(Name="Məhsulun Adı")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(800)")]
        [Display(Name = "Haqqında")]
        public string Description { get; set; }
        [Display(Name = "Qiymət")]
        public decimal Price { get; set; }
        [Display(Name = "Endirim Qiyməti")]
        public decimal? Discount { get; set; }
        [Display(Name = "Anbardakı çəkisi")]
        public int InStock { get; set; }
        [Column(TypeName = "nvarchar(800)")]
        [Display(Name = "Şəkil")]
        public string? PhotoUrl { get; set; }
        [Display(Name = "Yaradılma Tarixi")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "Son Dəyişiklik Tarixi")]
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Məhsul Kodu")]
        public string SKU { get; set; }
        [Display(Name = "Önə Çıxarmaq")]
        public bool IsFeatured { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDay { get; set; }
        [Display(Name = "Kateqoriya")]
        public int CategoryID { get; set; }
        public virtual Category? Category { get; set; }
    }


}
