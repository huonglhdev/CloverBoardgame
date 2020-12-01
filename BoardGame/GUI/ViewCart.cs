using BoardGame.DAO;
using BoardGame.DAOS;
using BoardGame.GUI;
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
    public partial class ViewCart : Form
    {
        public ShoppingCart cart;
        OrderDAO orderDAO = new OrderDAO();
        GameDAO gameDAO = new GameDAO();
        private tblUser user;
        private int total = 0;
        public ViewCart()
        {
            InitializeComponent();
        }
        public ViewCart(ShoppingCart cart, tblUser curUser) : this()
        {
            this.cart = cart;
            this.user = curUser;
            LoadData();
        }
        public void LoadData()
        {
            ProductDetail detail;
            if (cart.cart.Count > 0)
            {
                total = 0;
                lblTotal.Text = "Total: ";
                lblTotal.Show();
                btnSubmit.Show();
                lblNoti.Hide();
                panelDetails.Controls.Clear();
                foreach (int key in cart.cart.Keys)
                {
                    detail = new ProductDetail(cart.cart[key]);
                    detail.ButtonClick += new EventHandler(UserControl_Click);
                    detail.Margin = new Padding(5, 5, 5, 0);
                    panelDetails.Controls.Add(detail);
                    total += cart.cart[key].pricegame * cart.cart[key].numOfgame.Value;
                }
                lblTotal.Text = lblTotal.Text + total.ToString();
            }
            else
            {
                panelDetails.Controls.Clear();
                panelDetails.Controls.Add(lblNoti);
                lblTotal.Hide();
                btnSubmit.Hide();
                lblNoti.Show();
            }
        }

        private void UserControl_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            tblOrdergame detail;
            List<tblOrdergame> listOrdergames = new List<tblOrdergame>();
            tblOrder order = new tblOrder
            {
                orderAddress = user.userAddress,
                totalOrder = total,
                orderPhone = user.userPhone,
                orderDate = DateTime.Now,
                userName = user.userName,
                tblOrdergame = new List<tblOrdergame>()
            };
            foreach (int key in cart.cart.Keys)
            {
                detail = cart.cart[key];
                listOrdergames.Add(detail);
                order.tblOrdergame.Add(new tblOrdergame { gameID = detail.gameID, numOfgame = detail.numOfgame, pricegame = detail.pricegame });
            }
            if (orderDAO.addOrder(order)){
                gameDAO.UpdateListGame(listOrdergames);
                cart.cart.Clear();
                MessageBox.Show("Submit successfully!!!");
                toShowForm();
            }
        }

        private void toShowForm()
        {
            this.Hide();
            Show show = new Show(this.user, this.cart);
            show.ShowDialog();
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            toShowForm();
        }
    }
}
