using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectExpenseControl.DataAccess
{
    public class User
    {
        [Key]
        [Required]
        public int USR_IDE_USER { get; set; }
        [Required]
        [StringLength(100)]
        public string USR_IDE_AREA { get; set; }
        [Required]
        [StringLength(60)]
        public string USR_DES_POSITION { get; set; }
        [Required]
        [StringLength(100)]
        public string USR_DES_NAME { get; set; }
        [Required]
        [StringLength(60)]
        public string USR_DES_FIRST_NAME { get; set; }
        [StringLength(60)]
        public string USR_DES_LAST_NAME { get; set; }
        [Required]
        [StringLength(50)]
        public string USR_DES_PASSWORD { get; set; }
        [StringLength(20)]
        public string USR_DES_PHONE { get; set; }
        [Required]
        [StringLength(40)]
        public string USR_DES_EMAIL { get; set; }
        [Required]
        public DateTime USR_FH_CREATED { get; set; }
        public DateTime USR_LAST_LOGIN { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}