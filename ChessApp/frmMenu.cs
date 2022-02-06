using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessApp
{
    public partial class frmMenu : Form
    {

        public Chess previous;


        public frmMenu(Chess prev)
        {
            previous = prev;
            InitializeComponent();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            previous.showBack();
            this.Controls.Clear();
            frmRules myFrmRules = new frmRules() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            myFrmRules.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(myFrmRules);
            myFrmRules.Show();
            
          
        }

        private void btnChess_Click(object sender, EventArgs e)
        {
            previous.showBack();
            this.Controls.Clear();
            frmGame myFrmGame = new frmGame("chess") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            myFrmGame.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(myFrmGame);
            myFrmGame.Show();
        }
    }
}
