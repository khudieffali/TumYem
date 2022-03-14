using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WhatWeDo:Base
    {
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Sol Yazı")]
        public string LeftText { get; set; }
        [Column(TypeName ="nvarchar(800)")]
        [Display(Name = "Məqalə")]
        public string Description { get; set; }
    }
}
