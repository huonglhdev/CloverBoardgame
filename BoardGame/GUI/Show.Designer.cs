namespace BoardGame
{
    partial class Show
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnSearch = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTrack = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flpCate = new System.Windows.Forms.FlowLayoutPanel();
            this.flpGame = new System.Windows.Forms.FlowLayoutPanel();
            this.customerPanel1 = new BoardGame.GUI.CustomerPanel();
            this.guestPanel1 = new BoardGame.GUI.GuestPanel();
            this.staffPanel1 = new BoardGame.GUI.StaffPanel();
            this.adminPanel1 = new BoardGame.GUI.AdminPanel();
            this.pnSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnSearch
            // 
            this.pnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(186)))), ((int)(((byte)(177)))));
            this.pnSearch.Controls.Add(this.pictureBox1);
            this.pnSearch.Controls.Add(this.btnTrack);
            this.pnSearch.Controls.Add(this.txtSearch);
            this.pnSearch.Location = new System.Drawing.Point(0, 55);
            this.pnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(1181, 54);
            this.pnSearch.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BoardGame.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(789, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnTrack
            // 
            this.btnTrack.FlatAppearance.BorderSize = 0;
            this.btnTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrack.ForeColor = System.Drawing.Color.White;
            this.btnTrack.Location = new System.Drawing.Point(976, 0);
            this.btnTrack.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrack.Name = "btnTrack";
            this.btnTrack.Size = new System.Drawing.Size(205, 54);
            this.btnTrack.TabIndex = 6;
            this.btnTrack.Text = "Track order";
            this.btnTrack.UseVisualStyleBackColor = true;
            this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Location = new System.Drawing.Point(386, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(397, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // flpCate
            // 
            this.flpCate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(186)))), ((int)(((byte)(177)))));
            this.flpCate.Location = new System.Drawing.Point(0, 109);
            this.flpCate.Margin = new System.Windows.Forms.Padding(0);
            this.flpCate.Name = "flpCate";
            this.flpCate.Size = new System.Drawing.Size(1181, 61);
            this.flpCate.TabIndex = 2;
            // 
            // flpGame
            // 
            this.flpGame.AutoScroll = true;
            this.flpGame.Location = new System.Drawing.Point(0, 170);
            this.flpGame.Margin = new System.Windows.Forms.Padding(0);
            this.flpGame.Name = "flpGame";
            this.flpGame.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.flpGame.Size = new System.Drawing.Size(1181, 681);
            this.flpGame.TabIndex = 3;
            // 
            // customerPanel1
            // 
            this.customerPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(186)))), ((int)(((byte)(177)))));
            this.customerPanel1.ForeColor = System.Drawing.Color.Coral;
            this.customerPanel1.Location = new System.Drawing.Point(0, 1);
            this.customerPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.customerPanel1.Name = "customerPanel1";
            this.customerPanel1.Size = new System.Drawing.Size(1181, 54);
            this.customerPanel1.TabIndex = 6;
            this.customerPanel1.Load += new System.EventHandler(this.customerPanel1_Load);
            // 
            // guestPanel1
            // 
            this.guestPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(186)))), ((int)(((byte)(177)))));
            this.guestPanel1.Location = new System.Drawing.Point(0, 1);
            this.guestPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.guestPanel1.Name = "guestPanel1";
            this.guestPanel1.Size = new System.Drawing.Size(1181, 54);
            this.guestPanel1.TabIndex = 4;
            // 
            // staffPanel1
            // 
            this.staffPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(186)))), ((int)(((byte)(177)))));
            this.staffPanel1.Location = new System.Drawing.Point(0, 1);
            this.staffPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.staffPanel1.Name = "staffPanel1";
            this.staffPanel1.Size = new System.Drawing.Size(1181, 54);
            this.staffPanel1.TabIndex = 5;
            this.staffPanel1.Load += new System.EventHandler(this.staffPanel1_Load);
            // 
            // adminPanel1
            // 
            this.adminPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(186)))), ((int)(((byte)(177)))));
            this.adminPanel1.Location = new System.Drawing.Point(0, 1);
            this.adminPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.adminPanel1.Name = "adminPanel1";
            this.adminPanel1.Size = new System.Drawing.Size(1181, 54);
            this.adminPanel1.TabIndex = 0;
            this.adminPanel1.Load += new System.EventHandler(this.adminPanel1_Load);
            // 
            // Show
            // 
            this.ClientSize = new System.Drawing.Size(1182, 853);
            this.Controls.Add(this.customerPanel1);
            this.Controls.Add(this.guestPanel1);
            this.Controls.Add(this.staffPanel1);
            this.Controls.Add(this.adminPanel1);
            this.Controls.Add(this.flpGame);
            this.Controls.Add(this.flpCate);
            this.Controls.Add(this.pnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Show";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Clover";
            this.Load += new System.EventHandler(this.Show_Load);
            this.pnSearch.ResumeLayout(false);
            this.pnSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.FlowLayoutPanel flpCate;
        private System.Windows.Forms.FlowLayoutPanel flpGame;
        private System.Windows.Forms.Button btnTrack;
        private GUI.AdminPanel adminPanel1;
        private GUI.GuestPanel guestPanel1;
        private GUI.StaffPanel staffPanel1;
        private GUI.CustomerPanel customerPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

