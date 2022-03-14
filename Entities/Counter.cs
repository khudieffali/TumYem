using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Counter:Base
    {
        [Display(Name = "Say")]
        public int Count { get; set; }
        [Column(TypeName="nvarchar(100)")]
        [Display(Name = "Alt Yazı")]
        public string CountText { get; set; }
       
    }
}
