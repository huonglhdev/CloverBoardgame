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
    public partial class AdminPanel : UserControl
    {

        public tblUser user;

        public AdminPanel()
        {
            InitializeComponent();
        }

        public void ShowForm()
        {
            Show frm = new Show(null);
            Application.Run(frm);
        }

        public void ShowFormCreateStaff(tblUser user)
        {
            CreateStaff frm = new CreateStaff(user);
            Application.Run(frm);
        }

        public void ShowFormUpdate()
        {
            Update frm = new Update(user);
            Application.Run(frm);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowFormUpdate));
            t.Start();
            this.Parent.Dispose();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(() => ShowFormCreateStaff(user));
            t.Start();
            this.Parent.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowForm));
            t.Start();
            this.Parent.Dispose();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            
        }
    }
}
