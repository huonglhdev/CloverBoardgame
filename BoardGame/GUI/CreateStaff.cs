using BoardGame.DAOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardGame.GUI
{
    public partial class CreateStaff : Form
    {
        public CreateStaff()
        {
            InitializeComponent();
        }

        public CreateStaff(tblUser user)
        {
            InitializeComponent();
            this.user = user;
        }

        tblUser user;
        UserDAO dao = new UserDAO();
        bool ValidationResult = true;

        
        public void ShowForm(tblUser user)
        {
            Show s = new Show(user);
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

        private void btnCreate_Click(object sender, EventArgs e)
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
                        userRole = "Staff"
                    };
                    if (dao.AddAccount(u))
                    {
                        MessageBox.Show("Create staff successfull!");
                        txtUsername.Text = "";
                        txtPass.Text = "";
                        txtConfirm.Text = "";
                        txtFullname.Text = "";
                        txtPhone.Text = "";
                        txtAddress.Text = "";
                        lblPhone.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter filed required!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                this.Hide();
                Thread t = new Thread(() => ShowForm(user));
                t.Start();
                this.Close();
            }
        }

        
    }
}
