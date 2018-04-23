using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectExpenseControl.Models
{
    public class AccountingAccount
    {
        [Key]
        [StringLength(6)]
        public string ACC_IDE_ACCOUNT { get; set; }
        [StringLength(70)]
        public string ACC_DES_ACCOUNT { get; set; }
        public DateTime ACC_FH_CREATED { get; set; }
    }
}