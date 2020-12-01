using BoardGame.DAOS;
using BoardGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame.GUI
{
    public partial class TrackOrders : Form
    {
        private ShoppingCart cart;
        private tblUser user;
        OrderDAO dao = new OrderDAO();
        List<tblOrder> listOrders = new List<tblOrder>();
        static List<string> HEADERS = new List<string>
        {
            "OrderID", "Fullname", "Total", "Date"
        };

        public TrackOrders(tblUser curUser, ShoppingCart cart)
        {
            InitializeComponent();
            this.user = curUser;
            this.cart = cart;
        }

        private void TrackOrders_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            listOrders = dao.getOrders(user.userName);
            foreach (var header in HEADERS)
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = header;
                column.TextAlign = HorizontalAlignment.Left;
                column.Width = 155;
                lvOrders.Columns.Add(column);
            }
            foreach (tblOrder order in listOrders)
            {
                ListViewItem item = new ListViewItem(order.orderID.ToString());
                item.SubItems.Add(order.tblUser.userFullName);
                item.SubItems.Add(order.totalOrder.ToString());
                item.SubItems.Add(order.orderDate.ToString());
                lvOrders.Items.Add(item);
            }
        }

        private void lvOrders_DoubleClick(object sender, EventArgs e)
        {
            string orderID =lvOrders.SelectedItems[0].SubItems[0].Text;
            this.Hide();
            OrderDetails detailsForm = new OrderDetails(Int32.Parse(orderID), this.user, this.cart);
            detailsForm.ShowDialog();
            this.Close();
        }

        private void lvOrders_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvOrders.Columns[e.ColumnIndex].Width;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            toShowForm();
        }
        private void toShowForm()
        {
            this.Hide();
            Show show = new Show(this.user, this.cart);
            show.ShowDialog();
            this.Close();
        }
    }
}
