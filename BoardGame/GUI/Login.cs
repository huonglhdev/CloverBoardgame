using BoardGame.DAOS;
using BoardGame.GUI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace BoardGame
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        readonly UserDAO DAO = new UserDAO();

        public void ShowForm(tblUser user)
        {
            Show s = new Show(user);
            Application.Run(s);
        }

        public void ShowForm()
        {
            Show s = new Show(null);
            Application.Run(s);
        }

        public void ShowFormSignUp()
        {
            SignUp s = new SignUp();
            Application.Run(s);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            tblUser user = DAO.CheckLogin(txtUserName.Text, txtPass.Text);
            if (user!=null)
            {
                    this.Hide();
                    Thread t = new Thread(() => ShowForm(user));
                    t.Start();
                    this.Close();
            }
            else
            {
                MessageBox.Show("Login fail.");
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowFormSignUp));
            t.Start();
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowForm));
            t.Start();
            this.Close();
        }
    }
}
