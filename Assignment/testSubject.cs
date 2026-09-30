using Assignment.CustomUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment.Testing
{
    public partial class TestDashboardForm : Form
    {
        public TestDashboardForm()
        {
            InitializeComponent();
        }

        void changePanel(UserControl user)
        {
            user.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            changePanel(new DashboardUC());
        }

        private void panel1_Paint(object? sender, PaintEventArgs e)
        {
        }
    }
}
