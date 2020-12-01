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
    public partial class Update : Form
    {

        tblUser user;
        readonly UserDAO DAO = new UserDAO();
        bool checkUpdate = false;//true thi update, false thi mo enable
        bool ValidationResult = true;

        public Update()
        {
            InitializeComponent();
        }

        public Update(tblUser user)
        {
            InitializeComponent();
            this.user = user;
        }

        public void ShowForm(tblUser user)
        {
            Show s = new Show(user);
            Application.Run(s);
        }

        //validate
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

        private void Update_Load(object sender, EventArgs e)
        {
            lblUsername.Text = "Hello, "+user.userName;
            txtFullname.Text = user.userFullName;
            txtPhone.Text = user.userPhone;
            txtAddress.Text = user.userAddress;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!checkUpdate)
            {
                setEnableAll(true);
                checkUpdate = true;
            }
            else
            {
                if (ValidationResult == true)
                {
                    try
                    {
                        tblUser u = new tblUser
                        {
                            userName = user.userName,
                            userFullName = txtFullname.Text,
                            userPass = txtPass.Text,
                            userAddress = txtAddress.Text,
                            userPhone = txtPhone.Text,
                            userRole = user.userRole
                        };
                        if (DAO.UpdateAccount(u))
                        {
                            MessageBox.Show("Update successfull!");
                            user = u;
                            setEnableAll(false);
                            checkUpdate = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Enter field required!");
                }
            }
        }

        private void setEnableAll(bool Setup)
        {
            txtPass.Enabled = Setup;
            txtConfirm.Enabled = Setup;
            txtFullname.Enabled = Setup;
            txtPhone.Enabled = Setup;
            txtAddress.Enabled = Setup;
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
