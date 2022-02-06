namespace ChessApp
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.btnChess = new System.Windows.Forms.Button();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.pctChecker = new System.Windows.Forms.PictureBox();
            this.pctChess = new System.Windows.Forms.PictureBox();
            this.btnCheckers = new System.Windows.Forms.Button();
            this.lblSelectGame = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRules = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctChecker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctChess)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChess
            // 
            this.btnChess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.btnChess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChess.BackgroundImage")));
            this.btnChess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChess.FlatAppearance.BorderSize = 0;
            this.btnChess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChess.Location = new System.Drawing.Point(12, 9);
            this.btnChess.Name = "btnChess";
            this.btnChess.Size = new System.Drawing.Size(183, 167);
            this.btnChess.TabIndex = 0;
            this.btnChess.UseVisualStyleBackColor = false;
            this.btnChess.Click += new System.EventHandler(this.btnChess_Click);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.pctChecker);
            this.pnlOptions.Controls.Add(this.pctChess);
            this.pnlOptions.Controls.Add(this.btnCheckers);
            this.pnlOptions.Controls.Add(this.btnChess);
            this.pnlOptions.Location = new System.Drawing.Point(54, 213);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(411, 334);
            this.pnlOptions.TabIndex = 9;
            // 
            // pctChecker
            // 
            this.pctChecker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctChecker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.pctChecker.Image = ((System.Drawing.Image)(resources.GetObject("pctChecker.Image")));
            this.pctChecker.Location = new System.Drawing.Point(237, 193);
            this.pctChecker.Name = "pctChecker";
            this.pctChecker.Size = new System.Drawing.Size(147, 58);
            this.pctChecker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctChecker.TabIndex = 11;
            this.pctChecker.TabStop = false;
            // 
            // pctChess
            // 
            this.pctChess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctChess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.pctChess.Image = ((System.Drawing.Image)(resources.GetObject("pctChess.Image")));
            this.pctChess.Location = new System.Drawing.Point(29, 193);
            this.pctChess.Name = "pctChess";
            this.pctChess.Size = new System.Drawing.Size(144, 58);
            this.pctChess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctChess.TabIndex = 9;
            this.pctChess.TabStop = false;
            // 
            // btnCheckers
            // 
            this.btnCheckers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.btnCheckers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheckers.BackgroundImage")));
            this.btnCheckers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCheckers.FlatAppearance.BorderSize = 0;
            this.btnCheckers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckers.Location = new System.Drawing.Point(216, 9);
            this.btnCheckers.Name = "btnCheckers";
            this.btnCheckers.Size = new System.Drawing.Size(192, 167);
            this.btnCheckers.TabIndex = 1;
            this.btnCheckers.UseVisualStyleBackColor = false;
            // 
            // lblSelectGame
            // 
            this.lblSelectGame.AutoSize = true;
            this.lblSelectGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelectGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblSelectGame.Location = new System.Drawing.Point(179, 168);
            this.lblSelectGame.Name = "lblSelectGame";
            this.lblSelectGame.Size = new System.Drawing.Size(167, 29);
            this.lblSelectGame.TabIndex = 11;
            this.lblSelectGame.Text = "Select a game";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(573, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Learn the rules";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRules);
            this.panel1.Location = new System.Drawing.Point(526, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 188);
            this.panel1.TabIndex = 13;
            // 
            // btnRules
            // 
            this.btnRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.btnRules.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRules.BackgroundImage")));
            this.btnRules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRules.FlatAppearance.BorderSize = 0;
            this.btnRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRules.Location = new System.Drawing.Point(45, 9);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(174, 167);
            this.btnRules.TabIndex = 1;
            this.btnRules.UseVisualStyleBackColor = false;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.lblTitle.Location = new System.Drawing.Point(395, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 25);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Menù";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(875, 690);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelectGame);
            this.Controls.Add(this.pnlOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.pnlOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctChecker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctChess)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnChess;
        private Panel pnlOptions;
        private Button btnCheckers;
        private PictureBox pctChecker;
        private PictureBox pctChess;
        private Label lblSelectGame;
        private Label label1;
        private Panel panel1;
        private Button btnRules;
        private Label lblTitle;
    }
}