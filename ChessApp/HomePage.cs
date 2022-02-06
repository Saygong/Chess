namespace ChessApp
{
    public partial class Chess : Form
    {
        public Chess()
        {
            InitializeComponent();

            this.pnlLoader.Controls.Clear();
            frmMenu myFrmMenu = new frmMenu(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            myFrmMenu.FormBorderStyle = FormBorderStyle.None;
            this.pnlLoader.Controls.Add(myFrmMenu);
            myFrmMenu.Show();
            this.btnBack.Hide();
            

        }

        public void showBack()
        {
            this.btnBack.Show();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            this.pnlLoader.Controls.Clear();
            frmMenu myFrmMenu = new frmMenu(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            myFrmMenu.FormBorderStyle = FormBorderStyle.None;
            this.pnlLoader.Controls.Add(myFrmMenu);
            myFrmMenu.Show();
            this.btnBack.Hide();

        }
    }
}