using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.DAOS
{
    public partial class UserDAO
    {
        readonly BOARDGAMEDB db = new BOARDGAMEDB();

        public BOARDGAMEDB Db => db;

        public tblUser CheckLogin(string Username,string Password)
        {
            var user = (from u in Db.tblUser
                        where u.userName == Username && u.userPass==Password
                        select u).SingleOrDefault();
            return user;
        }

        public bool AddAccount(tblUser U)
        {
            db.tblUser.Add(U);
            return db.SaveChanges()>0;
        }

        public tblUser FindByUserName(string username)
        {
            var user = db.tblUser.SingleOrDefault(tbl => tbl.userName == username);
            return user;
        }

        public bool UpdateAccount(tblUser u)
        {
            var user = db.tblUser.SingleOrDefault(tbl => tbl.userName == u.userName);
            if (user != null)
            {
                user.userPass = u.userPass;
                user.userPhone = u.userPhone;
                user.userAddress = u.userAddress;
                user.userFullName = u.userFullName;
            }
            return db.SaveChanges() > 0;
        }
    }
}
