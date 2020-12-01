using BoardGame.DAOS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace BoardGame.GUI
{
    

    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }


        UserDAO dao = new UserDAO();
        bool ValidationResult = true;

        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }

        public void ShowFormLogin()
        {
            Login frm = new Login();
            Application.Run(frm);
        }

        public void ShowForm()
        {
            Show s = new Show(null);
            Application.Run(s);
        }

        //validation
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text.Equals(""))
            {
                lblUsername.Text = "Field required!";
                lblUsername.ForeColor = Color.Red;
                ValidationResult = false;
            }
            else
            {
                lblUsername.Text = "";
                ValidationResult = true;
            }
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (txtPass.Text.Equals(""))
            {
                lblPass.Text = "Field required!";
                lblPass.ForeColor = Color.Red;
                ValidationResult = false;
            }
            else
            {
                lblPass.Text = "";
                ValidationResult = true;
            }
        }

        private void txtConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (!txtConfirm.Text.Equals(txtPass.Text))
            {
                lblConfirm.Text = "Must compare to Password";
                lblConfirm.ForeColor = Color.Red;
                ValidationResult = false;
            }
            else
            {
                lblConfirm.Text = "";
                ValidationResult = true;
            }
        }

        private void txtFullname_Validating(object sender, CancelEventArgs e)
        {
            if (txtFullname.Text.Equals(""))
            {
                lblFullName.Text = "Field required!";
                lblFullName.ForeColor = Color.Red;
                ValidationResult = false;
            }
            else
            {
                lblFullName.Text = "";
                ValidationResult = true;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPhone.Text, out int v))
            {
                lblPhone.Text = "Wrong format phone";
                lblPhone.ForeColor = Color.Red;
                ValidationResult = false;
            }
            else if (txtPhone.Text.Length != 10)
            {
                lblPhone.Text = "Wrong format phone";
                lblPhone.ForeColor = Color.Red;
                ValidationResult = false;
            }
            else
            {
                lblPhone.Text = "";
                ValidationResult = true;
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhone.Text.Equals(""))
            {
                lblPhone.Text = "Field required!";
                lblPhone.ForeColor = Color.Red;
                ValidationResult = false;
            }
            else
            {
                lblPhone.Text = "";
                ValidationResult = true;
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (txtAddress.Text.Equals(""))
            {
                lblAddress.Text = "Field required!";
                lblAddress.ForeColor = Color.Red;
                ValidationResult = false;
            }
            else
            {
                lblAddress.Text = "";
                ValidationResult = true;
            }
        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            if (ValidationResult == true)
            {
                
                if (dao.FindByUserName(txtUsername.Text) != null)
                {
                   MessageBox.Show("This username has already existed");
                     }
                else { 
                    tblUser u = new tblUser
                    {
                        userName = txtUsername.Text,
                        userFullName = txtFullname.Text,
                        userPass = txtPass.Text,
                        userAddress = txtAddress.Text,
                        userPhone = txtPhone.Text,
                        userRole = "Customer"
                    };
                    if (dao.AddAccount(u))
                    {
                        MessageBox.Show("Sign up successfull!");
                        btnBack_Click(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter field required!");
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowFormLogin));
            t.Start();
            this.Close();
        }

        private void btnMainPage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread t = new Thread(new ThreadStart(ShowForm));
            t.Start();
            this.Close();
        }

       
    }
}

