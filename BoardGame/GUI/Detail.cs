using BoardGame.DAO;
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
    public partial class Detail : Form
    {
        GameDAO gDao = new GameDAO();
        tblGame curGame;
        tblUser curUser;
        ShoppingCart cart;
        public Detail(int gameId, tblUser user, ShoppingCart cart)
        {
            InitializeComponent();
            curGame = gDao.FindById(gameId);
            this.curUser = user;
            this.cart = cart;
        }
        public Detail(int gameId, tblUser user)
        {
            InitializeComponent();
            curGame = gDao.FindById(gameId);
            this.curUser = user;
        }
        private void Warning(object sender, EventArgs e)
        {
            MessageBox.Show("You must Login to use this Feature!");
        }
        private void ToShowForm()
        {
            this.Hide();
            new Show(this.curUser, this.cart).ShowDialog();
            this.Close();
        }
        private void Detail_Load(object sender, EventArgs e)
        {
            lblName.Text = curGame.gameName;
            lblPrice.Text = curGame.gamePrice + " vnd";
            txtDesciption.Text = "Description: "+ curGame.gameDescription;
            pBImage.ImageLocation = @"..\..\..\images\" + curGame.gameImage;
            pBImage.BackgroundImageLayout = ImageLayout.Stretch;
            pBImage.BorderStyle = BorderStyle.FixedSingle;

            if (this.curUser == null)
            {
                btnAdd.Click -= btnAdd_Click;
                btnAdd.Click += new EventHandler(Warning);
            }
            else if (this.curUser.userRole.Equals("Staff"))
            {
                btnAdd.Hide();
                flpStaff.Show();
            }
            else if (this.curUser.userRole.Equals("Admin"))
            {
                btnAdd.Hide();
                flpStaff.Hide();
            }
            else
            {
                btnAdd.Show();
                flpStaff.Hide();
            }

        }
        #region Button Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                         "Confirm Delete!!",
                         MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                if (gDao.Delete(this.curGame.gameID) == false)
                {
                    MessageBox.Show("Cannot found or delete fail!!");
                }
                else
                {
                    MessageBox.Show("Delete successfully");
                }
            }
            ToShowForm();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Info(this.curGame, curUser).ShowDialog();
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (curGame.gameQuantity > 0)
            {
                if (!cart.cart.ContainsKey(curGame.gameID))
                {
                    tblOrdergame detail = new tblOrdergame { gameID = curGame.gameID, numOfgame = 1, tblGame = curGame, pricegame = curGame.gamePrice };
                    MessageBox.Show("Added Successfully!!");
                    cart.addToCart(detail);
                }
                else
                {
                    if(cart.cart[curGame.gameID].numOfgame < curGame.gameQuantity)
                    {
                        tblOrdergame detail = new tblOrdergame { gameID = curGame.gameID, numOfgame = 1, tblGame = curGame, pricegame = curGame.gamePrice };
                        cart.addToCart(detail);
                        MessageBox.Show("Added Successfully!!");
                    }
                    else
                    {
                        MessageBox.Show("Out of stock");
                    }
                }
            }
            else
            {
                MessageBox.Show("Out of stock");
            }
        }
        private void btnViewCart_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCart viewCart = new ViewCart(cart, this.curUser);
            viewCart.ShowDialog();
            this.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ToShowForm();
        }
        #endregion
    }
}
