using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardGame.Models;
using BoardGame.DAO;

namespace BoardGame.GUI
{
    public partial class ProductDetail : UserControl
    {
        tblOrdergame detail;
        GameDAO dao = new GameDAO();
        public event EventHandler ButtonClick;
        public ProductDetail()
        {
            InitializeComponent();

        }

        public ProductDetail(tblOrdergame detail) : this()
        {
            this.detail = detail;
            picture.ImageLocation = @"..\..\..\images\" + detail.tblGame.gameImage;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            lblName.Text = detail.tblGame.gameName;
            lblQuanity.Text = detail.numOfgame.ToString();
        }

        private void btnReduce_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
            {
                var parent = this.Parent.Parent as ViewCart;
                if(parent.cart.cart[detail.gameID].numOfgame == 1) {
                    parent.cart.remove(detail.gameID);
                    this.ButtonClick(this, e);
                }
                else
                {
                    parent.cart.reduceQuantity(detail);
                    lblQuanity.Text = parent.cart.cart[detail.gameID].numOfgame.ToString();
                    this.ButtonClick(this, e);
                }
            }
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
            {
                var parent = this.Parent.Parent as ViewCart;
                tblGame game = dao.FindGame(detail.gameID);
                if (parent.cart.cart[detail.gameID].numOfgame < game.gameQuantity)
                {
                    parent.cart.addToCart(detail);
                    lblQuanity.Text = parent.cart.cart[detail.gameID].numOfgame.ToString();
                    this.ButtonClick(this, e);
                }
                else
                {
                    MessageBox.Show("Out of stock");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick != null)
            {
                var parent = this.Parent.Parent as ViewCart;
                parent.cart.remove(detail.gameID);
                this.ButtonClick(this, e);
            }
        }
    }
}
