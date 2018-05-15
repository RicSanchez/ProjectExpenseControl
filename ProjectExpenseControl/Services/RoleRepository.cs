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
    }
}