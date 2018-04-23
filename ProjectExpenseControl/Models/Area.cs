using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectExpenseControl.Models
{
    public class Area
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Display(Name ="Código de Área")]
        public string ARE_IDE_AREA { get; set; }
        [Required]
        [StringLength(60)]
        [Display(Name ="Área")]
        public string ARE_DES_NAME { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public DateTime ARE_FH_CREATED { get; set; }
    }
}