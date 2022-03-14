using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Contact :Base
    {
        [Column(TypeName = "nvarchar(400)")]
        [Display(Name = "Ünvan")]
        public string? WeAddress { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Telefon")]
        public string?  PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
