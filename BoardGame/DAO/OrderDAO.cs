using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame.DAOS
{
    public class OrderDAO
    {
        BOARDGAMEDB db = new BOARDGAMEDB();

        public List<tblOrder> getOrders(string username)
        {
            var query = (from o in db.tblOrder where o.userName == username 
                         select new { orderID = o.orderID, tblUser = o.tblUser, totalOrder = o.totalOrder, orderDate = o.orderDate }).ToList();

            var result = query.Select(o => new tblOrder { orderID = o.orderID, tblUser = o.tblUser, totalOrder = o.totalOrder, orderDate = o.orderDate });
            return result.ToList();
        }

        public tblOrder getOrder(int orderID)
        {
            var query = (from o in db.tblOrder where o.orderID == orderID select o);
            return query.SingleOrDefault();
        }

        public bool addOrder(tblOrder order)
        {
            db.tblOrder.Add(order);
            return db.SaveChanges() > 0;
        }
    }
}
