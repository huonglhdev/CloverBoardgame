using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using BoardGame.Models;

namespace BoardGame.GUI
{
    public partial class CustomerPanel : UserControl
    {

        public tblUser user;
        public ShoppingCart cart;
        public CustomerPanel()
        {
            InitializeComponent(); 
        }

        public void ShowForm()
        {
            Show frm = new Show(null);
            Application.Run(frm);
        }

        public void ShowFormUpdate()
        {
            Update frm = new Update(user);
            Application.Run(frm);
        }

        public void ShowViewCart()
        {
            ViewCart viewCart = new ViewCart(cart, this.user);
            Application.Run(viewCart);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowForm));
            t.Start();
            this.Parent.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowViewCart));
            t.Start();
            this.Parent.Dispose();
        }

        private void CustomerPanel_Load(object sender, EventArgs e)
        {
            if (user != null)
            {
                btnName.Text = user.userName;
            }
        }

        private void btnName_VisibleChanged(object sender, EventArgs e)
        {
            if (user != null)
            {
                btnName.Text = user.userName;
            }
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowFormUpdate));
            t.Start();
            this.Parent.Dispose();
        }
    }
}
