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

namespace BoardGame.GUI
{
    public partial class GuestPanel : UserControl
    {
        public GuestPanel()
        {
            InitializeComponent();
        }

        public void showFormLogin()
        {
            Login frm = new Login();
            Application.Run(frm);
        }

        public void showFormSignUp()
        {
            SignUp s = new SignUp();
            Application.Run(s);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(showFormLogin));
            t.Start();
            this.Parent.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(showFormSignUp));
            t.Start();
            this.Parent.Dispose();
        }
    }
}
