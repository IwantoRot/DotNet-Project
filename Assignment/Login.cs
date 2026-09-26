using System;
using System.Drawing;
using System.Windows.Forms;

namespace Assignment
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            txtEmail.Enter += RemovePlaceholder;
            txtEmail.Leave += SetPlaceholder;
            txtPassword.Enter += RemovePlaceholder;
            txtPassword.Leave += SetPlaceholder;
            this.Load += Login_LayoutControls;
            this.Resize += Login_LayoutControls;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == "Staff email" || txt.Text == "Password")
            {
                txt.Text = "";
                txt.ForeColor = Color.White;
                if (txt.Name == "txtPassword")
                    txt.UseSystemPasswordChar = true;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.ForeColor = Color.Gray;
                if (txt.Name == "txtEmail")
                    txt.Text = "Staff email";
                else if (txt.Name == "txtPassword")
                {
                    txt.UseSystemPasswordChar = false;
                    txt.Text = "Password";
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_LayoutControls(object sender, EventArgs e)
        {
            panelMain.Left = (this.ClientSize.Width - panelMain.Width) / 2;
            panelMain.Top = (this.ClientSize.Height - panelMain.Height) / 2 + 30;

            if (lblKarteveTitle != null)
            {
                lblKarteveTitle.Width = 400;
                lblKarteveTitle.Height = 50;
                lblKarteveTitle.Left = (this.ClientSize.Width - lblKarteveTitle.Width) / 2;
                lblKarteveTitle.Top = panelMain.Top - 65;
            }
        }
    }
}