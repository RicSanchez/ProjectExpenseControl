using ProjectExpenseControl.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectExpenseControl.Services
{
    public class RoleRepository
    {
        public List<Role> GetAll()
        {
            using (AuthenticationDB db = new AuthenticationDB())
            {
                return db.Roles.ToList();
            }
        }

        public bool Create(Role model)
        {
            if (model != null)
            {
                using (AuthenticationDB db = new AuthenticationDB())
                {
                    db.Roles.Add(model);
                    return (db.SaveChanges() > 0) ? true : false;
                }
            }
            return false;
        }

        public Role GetOne(int? id)
        {
            if (id != null)
            {
                using (AuthenticationDB db = new AuthenticationDB())
                {
                    Role Role = db.Roles.Find(id);
                    if (Role != null)
                        return Role;
                }
            }
            return null;

        }

        public Boolean Update(Role Role)
        {
            if (Role != null)
            {
                using (AuthenticationDB db = new AuthenticationDB())
                {
                    db.Roles.Attach(Role);
                    db.Entry(Role).Property(ob => ob.TUSR_DES_TYPE).IsModified = true;
                    return (db.SaveChanges() > 0) ? true : false;
                }
            }
            return false;
        }

        public Boolean Delete(int? id)
        {
            if (id != null)
            {
                Role Role = GetOne(id);
                if (Role != null)
                {
                    using (AuthenticationDB db = new AuthenticationDB())
                    {
                        db.Roles.Attach(Role);
                        db.Entry(Role).State = System.Data.Entity.EntityState.Deleted;
                        return (db.SaveChanges() > 0) ? true : false; ;
                    }
                }
            }
            return false;
        }
    }
}