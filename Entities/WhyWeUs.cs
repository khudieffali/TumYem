using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WhyWeUs:Base
    {

        [MaxLength(800)]
        [Display(Name = "Şəkil")]
        public string PhotoUrl { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Üst Yazı")]
        public string Header { get; set; }
        [Column(TypeName ="nvarchar(800)")]
        [Display(Name = "Məqalə")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Sol Üst Yazı")]
        public string LeftStaff { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Sol Alt Yazı")]
        public string StaffBottomText { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Sağ Üst Yazı")]
        public string RightService { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Sağ Alt Yazı")]
        public string ServiceBottomText { get; set; }

    }
}
