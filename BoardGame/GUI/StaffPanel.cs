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
    public partial class StaffPanel : UserControl
    {

        public tblUser user;

        public StaffPanel()
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
        
        public void ShowFormCreate()
        {
            Info info = new Info(null, user);
            Application.Run(info);
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowFormCreate));
            t.Start();
            this.Parent.Dispose();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowFormUpdate));
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
    }
}
