namespace Assignment
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMain = new RoundedPanel();
            lblFooter = new Label();
            chkTerms = new CheckBox();
            btnLogin = new GradientButton();
            chkRemember = new CheckBox();
            panelPassword = new RoundedPanel();
            txtPassword = new TextBox();
            panelEmail = new RoundedPanel();
            txtEmail = new TextBox();
            lblSubtitle = new Label();
            lblSignIn = new Label();
            lblKarteveTitle = new GradientLabel();
            panelMain.SuspendLayout();
            panelPassword.SuspendLayout();
            panelEmail.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.None;
            panelMain.BackColor = Color.FromArgb(22, 22, 26);
            panelMain.Controls.Add(lblFooter);
            panelMain.Controls.Add(chkTerms);
            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(chkRemember);
            panelMain.Controls.Add(panelPassword);
            panelMain.Controls.Add(panelEmail);
            panelMain.Controls.Add(lblSubtitle);
            panelMain.Controls.Add(lblSignIn);
            panelMain.Location = new Point(406, 140);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(450, 500);
            panelMain.TabIndex = 1;
            // 
            // lblFooter
            // 
            lblFooter.Font = new Font("Segoe UI", 8.5F);
            lblFooter.ForeColor = Color.DimGray;
            lblFooter.Location = new Point(40, 445);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(370, 45);
            lblFooter.TabIndex = 7;
            lblFooter.Text = "Sign in account to KARTEVE'S, you have to agree to our Terms and have acknowledge our Global Privacy Statement.";
            lblFooter.TextAlign = ContentAlignment.TopCenter;
            // 
            // chkTerms
            // 
            chkTerms.AutoSize = true;
            chkTerms.Font = new Font("Segoe UI", 9F);
            chkTerms.ForeColor = Color.DarkGray;
            chkTerms.Location = new Point(45, 410);
            chkTerms.Name = "chkTerms";
            chkTerms.Size = new Size(207, 24);
            chkTerms.TabIndex = 6;
            chkTerms.Text = "Accept to all Terms & Policy.";
            chkTerms.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(40, 340);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(370, 50);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Font = new Font("Segoe UI", 9.5F);
            chkRemember.ForeColor = Color.LightGray;
            chkRemember.Location = new Point(45, 290);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(135, 25);
            chkRemember.TabIndex = 4;
            chkRemember.Text = "Remember me";
            chkRemember.UseVisualStyleBackColor = true;
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.FromArgb(34, 34, 42);
            panelPassword.Controls.Add(txtPassword);
            panelPassword.Location = new Point(40, 220);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(370, 50);
            panelPassword.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(34, 34, 42);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(15, 13);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(340, 25);
            txtPassword.TabIndex = 0;
            txtPassword.Text = "Password";
            // 
            // panelEmail
            // 
            panelEmail.BackColor = Color.FromArgb(34, 34, 42);
            panelEmail.Controls.Add(txtEmail);
            panelEmail.Location = new Point(40, 150);
            panelEmail.Name = "panelEmail";
            panelEmail.Size = new Size(370, 50);
            panelEmail.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(34, 34, 42);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Location = new Point(15, 13);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(340, 25);
            txtEmail.TabIndex = 0;
            txtEmail.Text = "Staff email";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DarkGray;
            lblSubtitle.Location = new Point(0, 95);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(450, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Use your credential to sign in KARTEVE'S.";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSignIn
            // 
            lblSignIn.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblSignIn.ForeColor = Color.White;
            lblSignIn.Location = new Point(0, 40);
            lblSignIn.Name = "lblSignIn";
            lblSignIn.Size = new Size(450, 50);
            lblSignIn.TabIndex = 0;
            lblSignIn.Text = "Sign In";
            lblSignIn.TextAlign = ContentAlignment.MiddleCenter;
            //lblSignIn.Click += lblSignIn_Click;
            // 
            // lblKarteveTitle
            // 
            lblKarteveTitle.BackColor = Color.Transparent;
            lblKarteveTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblKarteveTitle.Location = new Point(0, 0);
            lblKarteveTitle.Name = "lblKarteveTitle";
            lblKarteveTitle.Size = new Size(400, 50);
            lblKarteveTitle.TabIndex = 0;
            lblKarteveTitle.Text = "KARTEVE'S";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 19);
            ClientSize = new Size(1263, 742);
            Controls.Add(lblKarteveTitle);
            Controls.Add(panelMain);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KARTEVE'S Login";
            Load += Login_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            panelEmail.ResumeLayout(false);
            panelEmail.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Assignment.RoundedPanel panelMain;
        private System.Windows.Forms.Label lblSignIn;
        private System.Windows.Forms.Label lblSubtitle;
        private Assignment.RoundedPanel panelEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private Assignment.RoundedPanel panelPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkRemember;
        private Assignment.GradientButton btnLogin;
        private System.Windows.Forms.CheckBox chkTerms;
        private System.Windows.Forms.Label lblFooter;
        private Assignment.GradientLabel lblKarteveTitle;
    }
}