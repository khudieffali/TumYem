using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class AboutUsText : Base
    {
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Üst Yazı")]
        public string OneMain { get; set; }
        [Column(TypeName = "nvarchar(800)")]
        [Display(Name = "Alt Yazı")]
        public string OneText { get; set; }
        public bool IsDeleted { get; set; }
    }
}
