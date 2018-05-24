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
                
        public bool Create(Area model)
        {
            if(model != null)
            {
                using(AuthenticationDB db = new AuthenticationDB())
                {
                    db.Areas.Add(model);
                    return (db.SaveChanges() > 0) ? true : false;
                }
            }
            return false;
        }

        public Area GetOne(string id)
        {
            if (id != null)
            {
                using (AuthenticationDB db = new AuthenticationDB())
                {
                    Area area = db.Areas.Find(id);
                    if (area != null)
                        return area;
                }
            }
            return null;

        }

        public Boolean Update(Area area)
        {
            if (area != null)
            {
                using (AuthenticationDB db = new AuthenticationDB())
                {
                    db.Areas.Attach(area);
                    db.Entry(area).Property(ob => ob.ARE_DES_NAME).IsModified = true;
                    return (db.SaveChanges() > 0) ? true : false;
                }
            }
            return false;
        }

        public Boolean Delete(string id)
        {
            if (id != null)
            {
                Area area = GetOne(id);
                if (area != null)
                {
                    using (AuthenticationDB db = new AuthenticationDB())
                    {
                        db.Areas.Attach(area);
                        db.Entry(area).State = System.Data.Entity.EntityState.Deleted;
                        return (db.SaveChanges() > 0) ? true : false; ;
                    }
                }
            }
            return false;
        }
    }
}