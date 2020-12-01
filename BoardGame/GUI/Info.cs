using BoardGame.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BoardGame.GUI
{
    public partial class Info : Form
    {
        CateDAO cDao = new CateDAO();
        GameDAO gDao = new GameDAO();
        tblGame curGame;
        tblUser staff;
        List<tblCategory> listCate;
        public Info(tblGame curGame,tblUser user)
        {
            InitializeComponent();
            if (curGame == null)
            {
                this.btnCreate.Show();
                this.btnUpdate.Hide();
                this.curGame = new tblGame();
            }
            else
            {
                this.btnCreate.Hide();
                this.btnUpdate.Show();
                this.curGame = curGame;  
            }
            this.staff = user;
            listCate = cDao.GetCate();
        }

        private void Info_Load(object sender, EventArgs e)
        {
            cbCate.DataSource = listCate;
            cbCate.DisplayMember = "categoryName";
            if (curGame.categoryID == null)
            {
                cbCate.SelectedIndex = listCate.Count - 1;
            }
            else
            {
                for (int i = 0; i < listCate.Count; i++)
                {
                    if(listCate.ElementAt(i).categoryID == curGame.categoryID)
                    {
                        cbCate.SelectedIndex = i;
                        break;
                    }
                }
            }
            txtName.Text = this.curGame.gameName;
            txtDescrip.Text = this.curGame.gameDescription;
            txtPrice.Text = this.curGame.gamePrice.ToString();
            txtQuantity.Text = this.curGame.gameQuantity.ToString();


            if(this.curGame.gameImage == null)
            {
                this.curGame.gameImage = "default.png";
            }
            pbImage.ImageLocation = @"..\..\..\images\" + this.curGame.gameImage;
        }
        #region Button Click
        private void btnImage_Click(object sender, EventArgs e)
        {
            Thread t = new Thread((ThreadStart)(() => {
                if (ofdImage.ShowDialog() == DialogResult.OK)
                {
                    pbImage.ImageLocation = ofdImage.FileName;
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
           
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            tblGame newGame = new tblGame
            {
                categoryID = listCate.ElementAt(cbCate.SelectedIndex).categoryID,
                gameName = txtName.Text.Trim(),
                gameDescription = txtDescrip.Text.Trim(),
                gamePrice = Int32.Parse(txtPrice.Text.Trim()),
                gameQuantity = Int32.Parse(txtQuantity.Text.Trim()),
                gameImage = pbImage.ImageLocation.Substring(pbImage.ImageLocation.LastIndexOf(@"\") +1),
                gameStatus = "Active",
            };
            try
            {
                gDao.Add(newGame);
                MessageBox.Show("Add succeessful");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot add\n" + ex.Message);
            }
            ToShowForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                tblGame updateGame = new tblGame();
                updateGame.gameID = this.curGame.gameID;
                updateGame.categoryID = listCate.ElementAt(cbCate.SelectedIndex).categoryID;
                updateGame.gameName = txtName.Text.Trim();
                updateGame.gameDescription = txtDescrip.Text.Trim();
                updateGame.gamePrice = Int32.Parse(txtPrice.Text.Trim());
                updateGame.gameQuantity = Int32.Parse(txtQuantity.Text.Trim());
                updateGame.gameImage = pbImage.ImageLocation.Substring(pbImage.ImageLocation.LastIndexOf(@"\")+1);

                gDao.Update(updateGame);
            }
            catch (Exception)
            {
                MessageBox.Show("Something's wrong!! Try again later");
            }
            MessageBox.Show("Update Successful");
            ToDetailForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ToShowForm();
        }
        #endregion

        #region Change Form
        private void ToShowForm()
        {
            this.Hide();
            new Show(this.staff).ShowDialog();
            this.Close();
        }
        private void ToDetailForm()
        {
            this.Hide();
            new Detail(this.curGame.gameID, this.staff).ShowDialog();
            this.Close();
        }
        #endregion

        #region Validating
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errpCheck.SetError(txtName, "Please enter name");
            }
            else
            {
                errpCheck.SetError(txtName, "");
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                errpCheck.SetError(txtPrice, "Please enter Quantity");
            }
            else
            {
                int checkNum;
                if (!Int32.TryParse(txtPrice.Text.Trim(), out checkNum))
                {
                    errpCheck.SetError(txtPrice, "Must be a positive integer");
                }
                else if (checkNum < 0)
                {
                    errpCheck.SetError(txtPrice, "Must be positive");
                }
                else
                {
                    errpCheck.SetError(txtPrice, "");
                }
            }
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                errpCheck.SetError(txtQuantity, "Please enter Quantity");
            }
            else
            {
                int checkNum;
                if(!Int32.TryParse(txtQuantity.Text.Trim(), out checkNum))
                {
                    errpCheck.SetError(txtQuantity, "Must be a positive integer");
                }else if(checkNum < 0)
                {
                    errpCheck.SetError(txtQuantity, "Must be positive");
                }
                else
                {
                    errpCheck.SetError(txtQuantity, "");
                }
            }
        }
#endregion

    }
}
