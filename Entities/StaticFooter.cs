using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class StaticFooter : Base
    {
        [Column(TypeName = "nvarchar(600)")]
        [Display(Name = "Sol Məqalə")]
        public string LeftDescription { get; set; }
        [Column(TypeName = "nvarchar(400)")]
        [Display(Name = "Ünvan")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }
        [MaxLength(1000)]
        [Display(Name ="Whatsapp Link")]
        public string? PhoneNumberLink { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Email Link")]
        public string? EmailLink { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Facebook Link")]
        public string? FacebookLink { get; set; }
        [MaxLength(1000)]
        [Display(Name = "İnstagram Link")]
        public string? InstagramLink { get; set; }
        [MaxLength(1000)]
        [Display(Name = "Twitter Link")]
        public string? TwitterLink { get; set; }
    }
}
