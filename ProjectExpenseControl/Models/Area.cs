using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectExpenseControl.Models
{
    public class Area
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Display(Name ="CÓDIGO DE ÁREA")]
        public string ARE_IDE_AREA { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name ="ÁREA")]
        public string ARE_DES_NAME { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public DateTime ARE_FH_CREATED { get; set; }

    }
}