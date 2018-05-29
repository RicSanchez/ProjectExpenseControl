using ProjectExpenseControl.DataAccess;
using ProjectExpenseControl.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectExpenseControl.Services
{
    public class UserRepository
    {
        public List<User> GetAll()
        {
            using (AuthenticationDB db = new AuthenticationDB())
            {
                return db.Users.ToList();
            }
        }

        public bool Create(User model)
        {
            if(model != null)
            {
                using (AuthenticationDB db = new AuthenticationDB())
                {
                    //db.Users.Add(model);
                    //return (db.SaveChanges() > 0) ? true : false;
                  

                    var rows = db.Database.ExecuteSqlCommand(ResourceSQL.SP_InsertUserAddRoleDefault,
                        new SqlParameter("@USR_IDE_AREA", model.USR_IDE_AREA),
                        new SqlParameter("@USR_DES_POSITION", model.USR_DES_POSITION),
                        new SqlParameter("@USR_DES_NAME", model.USR_DES_NAME),
                        new SqlParameter("@USR_DES_FIRST_NAME", model.USR_DES_FIRST_NAME),
                        new SqlParameter("@USR_DES_LAST_NAME", model.USR_DES_LAST_NAME),
                        new SqlParameter("@USR_DES_PASSWORD", model.USR_DES_PASSWORD),
                        new SqlParameter("@USR_DES_PHONE", model.USR_DES_PHONE),
                        new SqlParameter("@USR_DES_EMAIL", model.USR_DES_EMAIL),
                        new SqlParameter("@USR_FH_CREATED", model.USR_FH_CREATED)
                    );
                    

                    return (rows > 0) ? true : false;
                }
            }
            return false;
        }

        public User GetOne(int? id)
        {
            if (id != null)
            {
                using (AuthenticationDB db = new AuthenticationDB())
                {
                    User user = db.Users.Find(id);
                    if (user != null)
                        return user;
                }
            }
            return null;

        }

        public Boolean Update(User User)
        {
            if (User != null)
            {
                using (AuthenticationDB db = new AuthenticationDB())
                {
                    db.Users.Attach(User);
                    db.Entry(User).Property(ob => ob.USR_IDE_AREA).IsModified = true;
                    db.Entry(User).Property(ob => ob.USR_DES_POSITION).IsModified = true;
                    db.Entry(User).Property(ob => ob.USR_DES_NAME).IsModified = true;
                    db.Entry(User).Property(ob => ob.USR_DES_FIRST_NAME).IsModified = true;
                    db.Entry(User).Property(ob => ob.USR_DES_LAST_NAME).IsModified = true;
                    db.Entry(User).Property(ob => ob.USR_DES_PASSWORD).IsModified = true;
                    db.Entry(User).Property(ob => ob.USR_DES_PHONE).IsModified = true;
                    db.Entry(User).Property(ob => ob.USR_DES_EMAIL).IsModified = true;
                    return (db.SaveChanges() > 0) ? true : false;
                }
            }
            return false;
        }

        public Boolean Delete(int? id)
        {
            if (id != null)
            {
                User User = GetOne(id);
                if (User != null)
                {
                    using (AuthenticationDB db = new AuthenticationDB())
                    {
                        //db.Users.Attach(User);
                        //db.Entry(User).State = System.Data.Entity.EntityState.Deleted;
                        //return (db.SaveChanges() > 0) ? true : false; ;
                        var rows = db.Database.ExecuteSqlCommand(ResourceSQL.SP_DeleteUserRemoveRole,new SqlParameter("@USR_IDE_USER", id));

                        return (rows > 0) ? true : false;
                    }
                }
            }
            return false;
        }

        public UserRole GetUserRoles()
        {
            return null;
        }
    }
}