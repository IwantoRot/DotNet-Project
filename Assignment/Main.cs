using System.ComponentModel;

namespace Assignment
{
    partial class SideBarWithContent : Form
    {
        private IContainer components = null!;

        // Panels
        private Panel leftSidebar = null!;
        private Panel headerPanel = null!;
        private Panel contentPanel = null!;

        // Branding
        private PictureBox logoBox = null!;
        private Label titleLabel = null!;

        // Nav buttons
        private NavButton navDashboard = null!;
        private NavButton navRoom = null!;
        private NavButton navReservation = null!;
        private NavButton navMembership = null!;
        private NavButton navEmployees = null!;
        private NavButton navAccountDetails = null!;

        // Header items
        private Label headerTitle = null!;
        private PictureBox userAvatar = null!;
        private PictureBox btnSettings = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            // Form
            this.SuspendLayout();
            this.ClientSize = new Size(1200, 720);
            this.Text = "Admin - Dashboard";
            this.BackColor = Color.FromArgb(18, 18, 20);

            // Left sidebar
            leftSidebar = new Panel()
            {
                Dock = DockStyle.Left,
                Width = 220,
                BackColor = Color.FromArgb(24, 24, 28),
                Padding = new Padding(16)
            };

            // Logo area
            logoBox = new PictureBox()
            {
                Size = new Size(160, 36),
                Location = new Point(16, 8),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            // Resource assignment moved to runtime to avoid designer-time issues

            titleLabel = new Label()
            {
                Text = "KARTEVE'S",
                ForeColor = Color.FromArgb(255, 130, 195),
                Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(16, 52),
                AutoSize = true
            };

            // Navigation buttons (stacked)
            navDashboard = CreateNav("Dashboard", 0);
            navRoom = CreateNav("Room", 1);
            navReservation = CreateNav("Reservation", 2);
            navMembership = CreateNav("Membership", 3);
            navEmployees = CreateNav("Employees", 4);
            navAccountDetails = CreateNav("Account details", 5);

            // Position nav buttons vertically
            int y = 110;
            foreach (Control c in new Control[] { navDashboard, navRoom, navReservation, navMembership, navEmployees, navAccountDetails })
            {
                c.Location = new Point(8, y);
                c.Width = leftSidebar.Width - 32;
                c.Height = 44;
                y += c.Height + 10;
                leftSidebar.Controls.Add(c);
            }

            leftSidebar.Controls.Add(logoBox);
            leftSidebar.Controls.Add(titleLabel);

            // Header panel
            headerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 72,
                BackColor = Color.FromArgb(16, 16, 18)
            };

            headerTitle = new Label()
            {
                Text = "KARTEVE'S Management System",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(leftSidebar.Width + 24, 18),
                AutoSize = true
            };

            // Header icons (right side)
            var assetsBase = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");

            PictureBox notificationIcon = new PictureBox()
            {
                Size = new Size(36, 36),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(this.ClientSize.Width - 200, 18),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            userAvatar = new PictureBox()
            {
                Size = new Size(40, 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(this.ClientSize.Width - 150, 14),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(40, 40, 44)
            };

            btnSettings = new PictureBox()
            {
                Size = new Size(36, 36),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(this.ClientSize.Width - 96, 18),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            // Image loading is performed at runtime by ApplyAssets()

            headerPanel.Controls.Add(headerTitle);
            headerPanel.Controls.Add(notificationIcon);
            headerPanel.Controls.Add(userAvatar);
            headerPanel.Controls.Add(btnSettings);

            // Content panel
            contentPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(12, 12, 14),
                Padding = new Padding(24)
            };

            contentPanel.Controls.Add(new DashboardUC { Dock = DockStyle.Fill });

            // Add everything to form
            this.Controls.Add(contentPanel);
            this.Controls.Add(headerPanel);
            this.Controls.Add(leftSidebar);

            // Basic events for demo
            navDashboard.Click += (s, e) => SetActive(navDashboard);
            navRoom.Click += (s, e) => SetActive(navRoom);
            navReservation.Click += (s, e) => SetActive(navReservation);
            navMembership.Click += (s, e) => SetActive(navMembership);
            navEmployees.Click += (s, e) => SetActive(navEmployees);
            navAccountDetails.Click += (s, e) => SetActive(navAccountDetails);

            // Start with dashboard active
            SetActive(navDashboard);

            this.ResumeLayout(false);
        }

        // Constructor - call InitializeComponent and then apply runtime-only assets
        public SideBarWithContent()
        {
            InitializeComponent();
            // Don't attempt to load runtime assets while the designer is instantiating this form
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                ApplyAssets();
            }
        }

        private void ApplyAssets()
        {
            var assetsBase = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");

            try
            {
                var logoPath = System.IO.Path.Combine(assetsBase, "logo.png");
                if (System.IO.File.Exists(logoPath)) logoBox.BackgroundImage = Image.FromFile(logoPath);
            }
            catch { }

            try
            {
                var bellPath = System.IO.Path.Combine(assetsBase, "bell.png");
                if (System.IO.File.Exists(bellPath))
                {
                    var pb = headerPanel.Controls[1] as PictureBox; // notificationIcon
                    if (pb != null) pb.BackgroundImage = Image.FromFile(bellPath);
                }
            }
            catch { }

            try
            {
                var userPath = System.IO.Path.Combine(assetsBase, "user.png");
                if (System.IO.File.Exists(userPath))
                {
                    var pb = headerPanel.Controls[2] as PictureBox; // userAvatar
                    if (pb != null) pb.BackgroundImage = Image.FromFile(userPath);
                }
            }
            catch { }

            try
            {
                var gearPath = System.IO.Path.Combine(assetsBase, "gear.png");
                if (System.IO.File.Exists(gearPath))
                {
                    var pb = headerPanel.Controls[3] as PictureBox; // btnSettings
                    if (pb != null) pb.BackgroundImage = Image.FromFile(gearPath);
                }
            }
            catch { }

            // Fallback to strongly-typed resources if the Assets files were not provided
            try { if (logoBox.BackgroundImage == null) logoBox.BackgroundImage = SideBarWithContentResources.pictureBox1_BackgroundImage; } catch { }
            try { var notif = headerPanel.Controls[1] as PictureBox; if (notif != null && notif.BackgroundImage == null) notif.BackgroundImage = SideBarWithContentResources.pictureBox1_BackgroundImage; } catch { }
            try { var avatar = headerPanel.Controls[2] as PictureBox; if (avatar != null && avatar.BackgroundImage == null) avatar.BackgroundImage = SideBarWithContentResources.pictureBox2_BackgroundImage; } catch { }
            try { var gear = headerPanel.Controls[3] as PictureBox; if (gear != null && gear.BackgroundImage == null) gear.BackgroundImage = SideBarWithContentResources.pictureBox3_BackgroundImage; } catch { }
        }

        private NavButton CreateNav(string text, int index)
        {
            var b = new NavButton()
            {
                Text = text,
                GradientStart = Color.FromArgb(147, 51, 234),
                GradientEnd = Color.FromArgb(239, 68, 68),
                InactiveColor = Color.FromArgb(32, 33, 44),
                InactiveTextColor = Color.FromArgb(160, 160, 175),
                BorderRadius = 12,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.White
            };
            return b;
        }

        private void SetActive(NavButton active)
        {
            foreach (Control c in leftSidebar.Controls)
            {
                if (c is NavButton nb)
                    nb.IsActive = nb == active;
            }
        }
    }
}
