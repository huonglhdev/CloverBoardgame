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
    public partial class OrderDetails : Form
    {
        private tblUser user;
        private ShoppingCart cart;
        static List<string> HEADERS = new List<string>
        {
            "GameID", "Game Name", "Quantity", "Price"
        };
        int orderID;
        OrderDAO dao = new OrderDAO();

        public OrderDetails()
        {
            InitializeComponent();
        }
        public OrderDetails(int orderID, tblUser curUser, ShoppingCart cart) : this()
        {
            this.orderID = orderID; 
            this.user = curUser;
            this.cart = cart;
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            tblOrder order = dao.getOrder(orderID);
            lblID.Text = lblID.Text + order.orderID;
            lblAddress.Text = lblAddress.Text + order.orderAddress;
            lblName.Text = lblName.Text + order.tblUser.userFullName;
            lblPhone.Text = lblPhone.Text + order.orderPhone;
            lblDate.Text = lblDate.Text + order.orderDate.ToString();
            lblTotal.Text = lblTotal.Text + order.totalOrder;
            List<tblOrdergame> details = order.tblOrdergame.ToList();
            foreach (var header in HEADERS)
            {
                ColumnHeader column = new ColumnHeader();
                column.Text = header;
                column.TextAlign = HorizontalAlignment.Left;
                column.Width = 193;
                lvOrderGame.Columns.Add(column);
            }
            foreach (tblOrdergame game in details)
            {
                ListViewItem item = new ListViewItem(game.gameID.ToString());
                item.SubItems.Add(game.tblGame.gameName);
                item.SubItems.Add(game.numOfgame.ToString());
                item.SubItems.Add(game.pricegame.ToString());
                lvOrderGame.Items.Add(item);
            }
        }

        private void lvOrderGame_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvOrderGame.Columns[e.ColumnIndex].Width;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            toTrackOrderForm();
        }

        private void toTrackOrderForm()
        {
            this.Hide();
            TrackOrders trackOrders = new TrackOrders(this.user, this.cart);
            trackOrders.ShowDialog();
            this.Close();
        }
    }
}
