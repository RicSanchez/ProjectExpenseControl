using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectExpenseControl.DataAccess
{
    public class Role
    {
        [Key]
        public int TUSR_IDE_RESOURCE { get; set; }
        [Required]
        [StringLength(70)]
        public string TUSR_DES_TYPE { get; set; }
        [Required]
        public DateTime TUSR_FH_CREATED { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}