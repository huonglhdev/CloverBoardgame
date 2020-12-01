using BoardGame.DAO;
using BoardGame.GUI;
using BoardGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BoardGame
{
    public partial class Show : Form
    {
        GameDAO gDao = new GameDAO();
        CateDAO cDao = new CateDAO();

        tblUser curUser = null;
        List<tblGame> listGame = null;
        List<tblCategory> listCate = null;
        PictureBox pic = null;
        Label name = null;
        Button btnCate = null;

        ShoppingCart cart = null;
        public Show(tblUser curUser, ShoppingCart cart)
        {
            InitializeComponent();
            this.curUser = curUser;
            if (cart == null)
            {
                this.cart = new ShoppingCart();
            }
            else
            {
                this.cart = cart;
            }
        }
        public Show(tblUser user)
        {
            InitializeComponent();
            if (user != null)
            {
                this.curUser = user;
                this.cart = new ShoppingCart();
            }
        }

        #region Innitital
        private void Show_Load(object sender, EventArgs e)
        {
            GetCategory();
            GetData("", null);
            //guest
            if (this.curUser == null)
            {
                btnTrack.Hide();
                customerPanel1.Hide();
                adminPanel1.Hide();
                staffPanel1.Hide();
                guestPanel1.Visible = true;
            }
            //staff
            else if (this.curUser.userRole.Equals("Staff"))
            {
                btnTrack.Hide();
                customerPanel1.Hide();
                adminPanel1.Hide();
                guestPanel1.Hide();
                staffPanel1.Visible = true;
            }
            //admin
            else if (this.curUser.userRole.Equals("Admin"))
            {
                btnTrack.Hide();
                customerPanel1.Hide();
                guestPanel1.Hide();
                staffPanel1.Hide();
                adminPanel1.Visible = true;
            }
            //customer
            else
            {
                adminPanel1.Hide();
                guestPanel1.Hide();
                staffPanel1.Hide();
                customerPanel1.Visible = true;
                btnTrack.Show();
            } 
        }

        private void GetData(String search, List<tblGame> listGame)
        {
            flpGame.Controls.Clear();
            if (listGame == null)
            {
                this.listGame = gDao.GetGame(search);
                if (this.curUser != null)
                {
                    if (this.curUser.userRole.Equals("Staff"))
                    {
                        this.listGame = gDao.GetGameByStaff(search);
                    }
                }
                
                listGame = this.listGame;
            }
            
            foreach (tblGame item in listGame)
            {
                pic = new PictureBox
                {
                    Width = 220,
                    Height = 220,
                    ImageLocation = @"..\..\..\images\" + item.gameImage,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = item.gameID.ToString(),
                    Margin = new Padding(7, 10 ,0 ,0),
                };
                pic.Click += new EventHandler(Pic_Click);
                name = new Label
                {
                    Text = item.gameName,
                    BackColor = Color.FromArgb(13, 186, 177),
                    ForeColor = Color.White,
                    Font = btnTrack.Font,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Height = 40,
                    Dock = DockStyle.Bottom,
                };
                pic.Controls.Add(name);
                flpGame.Controls.Add(pic);
            }
        }

        private void GetCategory()
        {
            listCate = cDao.GetCate();
            int btnWidth = this.flpCate.Width / listCate.Count;
            foreach (tblCategory item in listCate)
            {
                btnCate = new Button
                {
                    Height = this.flpCate.Height,
                    Width = btnWidth,
                    Text = item.categoryName,
                    Tag = item.categoryID,
                    ForeColor = Color.White,
                    Font = btnTrack.Font,
                    Margin = new Padding(0, 0, 0, 0),
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 1, BorderColor = Color.White },
                };
                btnCate.Click += new EventHandler(Button_Click);
                flpCate.Padding = new Padding(3, 0, 0, 0);
                flpCate.Controls.Add(btnCate);
            }
        }

        private void Warning(object sender, EventArgs e)
        {
            MessageBox.Show("You must Login to use this Feature!");
        }
        #endregion

        #region Click
        private void Pic_Click(object sender, EventArgs e)
        {
            int gameId = Int32.Parse(((PictureBox)sender).Tag.ToString());
            this.Hide();
            new Detail(gameId, this.curUser, this.cart).ShowDialog();
            this.Close();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text.Equals("All"))
            {
                GetData(txtSearch.Text, null);
            }
            else
            {
                List<tblGame> newList = new List<tblGame>();
                foreach (tblGame item in this.listGame)
                {
                    if (item.categoryID.ToString().Equals(b.Tag.ToString()))
                    {
                        newList.Add(item);
                    }
                }
                GetData(txtSearch.Text, newList);
            }

        }
        
        private void btnViewCart_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCart viewCart = new ViewCart(cart, this.curUser);
            viewCart.ShowDialog();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.TextLength != 0)
            {
                GetData(txtSearch.Text, null);
            }
        }

        private void btnTrack_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrackOrders track = new TrackOrders(this.curUser, this.cart);
            track.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtSearch.TextLength != 0)
            {
                GetData(txtSearch.Text, null);
            }
        }
        #endregion

        #region Load Top Panel
        private void adminPanel1_Load(object sender, EventArgs e)
        {
            adminPanel1.user = curUser;
        }

        private void staffPanel1_Load(object sender, EventArgs e)
        {
            staffPanel1.user = curUser;
        }

        private void customerPanel1_Load(object sender, EventArgs e)
        {
            customerPanel1.cart = cart;
            customerPanel1.user = curUser;
        }
        #endregion

    }
}
