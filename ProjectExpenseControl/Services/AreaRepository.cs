using ProjectExpenseControl.Models;
using ProjectExpenseControl.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace ProjectExpenseControl.Services
{
    public class AreaRepository
    {
        public List<Area> GetAll()
        {
            using (AuthenticationDB db = new AuthenticationDB())
            {
                return db.Areas.ToList();
            }
        }
                
        public void Create(Area model)
        {
            using(AuthenticationDB db = new AuthenticationDB())
            {
                db.Areas.Add(model);
                db.SaveChanges();
            }
        }
    }
}