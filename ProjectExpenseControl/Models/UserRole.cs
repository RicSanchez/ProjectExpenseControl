using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectExpenseControl.Models
{
    public class UserRole
    {
        [Key]
        [Column(Order =1)]
        [Required]
        [Display(Name ="USUARIO")]
        public int USR_IDE_USER { get; set; }

        [Key]
        [Column(Order =2)]
        [Required]
        [Display(Name ="TIPO DE USUARIO")]
        public int TUSR_IDE_RESOURCE { get; set; }
    }
}