using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Slider:Base
    {
        [Column(TypeName ="nvarchar(50)")]
        [Display(Name = "Üst Sol Yazı")]
        public string HeaderLeft { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Üst Sağ Yazı")]
        public string HeaderRight { get; set; }
        [Column(TypeName = "nvarchar(400)")]
        [Display(Name = "Alt Yazı")]
        public string? Summary { get; set; }
        [Column(TypeName = "varchar(800)")]
        [Display(Name = "Şəkil")]
        public string? BackgroundPhoto { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Göstərmək")]
        public bool IsShow { get; set; }

    }
}
