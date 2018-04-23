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
                return db.Area.ToList();
            }
        }
                
        public List<SelectListItem> GetAll2()
        {
            using (AuthenticationDB db = new AuthenticationDB())
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();
                foreach (Area area in db.Area.ToList())
                {
                    selectListItems.Add(new SelectListItem()
                    {
                        Text = area.ARE_DES_NAME,
                        Value = area.ARE_IDE_AREA
                    });
                }
                return selectListItems;
            }
        }

        public void Create(Area model)
        {
            using(AuthenticationDB db = new AuthenticationDB())
            {
                db.Area.Add(model);
                db.SaveChanges();
            }
        }
    }
}