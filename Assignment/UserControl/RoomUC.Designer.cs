namespace Assignment.UserControl
{
    partial class RoomUC
    {
        private System.ComponentModel.IContainer components = null!;
        private TableLayoutPanel mainLayout = null!;
        private Panel headingPanel = null!;
        private Label headingLabel = null!;
        private Label subtitleLabel = null!;
        private Panel toolbarPanel = null!;
        private Label roomCountLabel = null!;
        private TextBox searchTextBox = null!;
        private ComboBox statusComboBox = null!;
        private Panel roomsPanel = null!;
        private FlowLayoutPanel roomFlowPanel = null!;
        private Label emptyStateLabel = null!;
        private global::Assignment.CustomUI.RoomUI roomCard1 = null!;
        private global::Assignment.CustomUI.RoomUI roomCard2 = null!;
        private global::Assignment.CustomUI.RoomUI roomCard3 = null!;
        private global::Assignment.CustomUI.RoomUI roomCard4 = null!;
        private global::Assignment.CustomUI.RoomUI roomCard5 = null!;
        private global::Assignment.CustomUI.RoomUI roomCard6 = null!;
        private global::Assignment.CustomUI.RoomUI roomCard7 = null!;
        private global::Assignment.CustomUI.RoomUI roomCard8 = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            mainLayout = new TableLayoutPanel();
            headingPanel = new Panel();
            headingLabel = new Label();
            subtitleLabel = new Label();
            toolbarPanel = new Panel();
            roomCountLabel = new Label();
            searchTextBox = new TextBox();
            statusComboBox = new ComboBox();
            roomsPanel = new Panel();
            roomFlowPanel = new FlowLayoutPanel();
            emptyStateLabel = new Label();
            roomCard1 = new global::Assignment.CustomUI.RoomUI();
            roomCard2 = new global::Assignment.CustomUI.RoomUI();
            roomCard3 = new global::Assignment.CustomUI.RoomUI();
            roomCard4 = new global::Assignment.CustomUI.RoomUI();
            roomCard5 = new global::Assignment.CustomUI.RoomUI();
            roomCard6 = new global::Assignment.CustomUI.RoomUI();
            roomCard7 = new global::Assignment.CustomUI.RoomUI();
            roomCard8 = new global::Assignment.CustomUI.RoomUI();
            mainLayout.SuspendLayout();
            headingPanel.SuspendLayout();
            toolbarPanel.SuspendLayout();
            roomsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.BackColor = Color.FromArgb(12, 12, 14);
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(headingPanel, 0, 0);
            mainLayout.Controls.Add(toolbarPanel, 0, 1);
            mainLayout.Controls.Add(roomsPanel, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Padding = new Padding(16, 12, 16, 12);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            // 
            // headingPanel
            // 
            headingPanel.BackColor = Color.FromArgb(12, 12, 14);
            headingPanel.Controls.Add(subtitleLabel);
            headingPanel.Controls.Add(headingLabel);
            headingPanel.Dock = DockStyle.Fill;
            // 
            // headingLabel
            // 
            headingLabel.AutoSize = true;
            headingLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            headingLabel.ForeColor = Color.White;
            headingLabel.Location = new Point(0, 0);
            headingLabel.Name = "headingLabel";
            headingLabel.Size = new Size(170, 37);
            headingLabel.Text = "Room Management";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 9F);
            subtitleLabel.ForeColor = Color.FromArgb(160, 160, 170);
            subtitleLabel.Location = new Point(2, 40);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(240, 15);
            subtitleLabel.Text = "Manage room details and availability";
            // 
            // toolbarPanel
            // 
            toolbarPanel.BackColor = Color.FromArgb(12, 12, 14);
            toolbarPanel.Controls.Add(roomCountLabel);
            toolbarPanel.Controls.Add(searchTextBox);
            toolbarPanel.Controls.Add(statusComboBox);
            toolbarPanel.Dock = DockStyle.Fill;
            // 
            // roomCountLabel
            // 
            roomCountLabel.AutoSize = true;
            roomCountLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            roomCountLabel.ForeColor = Color.White;
            roomCountLabel.Location = new Point(0, 12);
            roomCountLabel.Name = "roomCountLabel";
            roomCountLabel.Size = new Size(112, 20);
            roomCountLabel.Text = "All Rooms (8)";
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchTextBox.BackColor = Color.FromArgb(32, 32, 38);
            searchTextBox.BorderStyle = BorderStyle.FixedSingle;
            searchTextBox.ForeColor = Color.White;
            searchTextBox.Location = new Point(410, 8);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Search rooms";
            searchTextBox.Size = new Size(220, 23);
            // 
            // statusComboBox
            // 
            statusComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusComboBox.BackColor = Color.FromArgb(32, 32, 38);
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.ForeColor = Color.White;
            statusComboBox.Items.AddRange(new object[] { "All rooms", "Available", "Occupied" });
            statusComboBox.Location = new Point(646, 8);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(150, 23);
            statusComboBox.SelectedIndex = 0;
            // 
            // roomsPanel
            // 
            roomsPanel.BackColor = Color.FromArgb(12, 12, 14);
            roomsPanel.Controls.Add(roomFlowPanel);
            roomsPanel.Controls.Add(emptyStateLabel);
            roomsPanel.Dock = DockStyle.Fill;
            // 
            // roomFlowPanel
            // 
            roomFlowPanel.AutoScroll = true;
            roomFlowPanel.BackColor = Color.FromArgb(12, 12, 14);
            roomFlowPanel.Dock = DockStyle.Fill;
            roomFlowPanel.FlowDirection = FlowDirection.LeftToRight;
            roomFlowPanel.Padding = new Padding(4);
            roomFlowPanel.WrapContents = true;
            roomFlowPanel.Controls.AddRange(new Control[]
            {
                roomCard1, roomCard2, roomCard3, roomCard4,
                roomCard5, roomCard6, roomCard7, roomCard8
            });
            // 
            // emptyStateLabel
            // 
            emptyStateLabel.Dock = DockStyle.Fill;
            emptyStateLabel.Font = new Font("Segoe UI", 10F);
            emptyStateLabel.ForeColor = Color.FromArgb(160, 160, 170);
            emptyStateLabel.Text = "No rooms match your search.";
            emptyStateLabel.TextAlign = ContentAlignment.MiddleCenter;
            emptyStateLabel.Visible = false;
            // 
            // room cards
            // 
            ConfigureRoom(roomCard1, "Room 01", "VIP Karaoke Room", "Available", "ktv_room_1.jpg");
            ConfigureRoom(roomCard2, "Room 02", "Deluxe Karaoke Room", "Occupied", "ktv_room_2.jpg");
            ConfigureRoom(roomCard3, "Room 03", "VIP Karaoke Room", "Available", "ktv_room_1.jpg");
            ConfigureRoom(roomCard4, "Room 04", "Deluxe Karaoke Room", "Occupied", "ktv_room_2.jpg");
            ConfigureRoom(roomCard5, "Room 05", "VIP Karaoke Room", "Available", "ktv_room_1.jpg");
            ConfigureRoom(roomCard6, "Room 06", "Deluxe Karaoke Room", "Available", "ktv_room_2.jpg");
            ConfigureRoom(roomCard7, "Room 07", "VIP Karaoke Room", "Occupied", "ktv_room_1.jpg");
            ConfigureRoom(roomCard8, "Room 08", "Deluxe Karaoke Room", "Available", "ktv_room_2.jpg");
            // 
            // RoomUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 12, 14);
            Controls.Add(mainLayout);
            Name = "RoomUC";
            Size = new Size(920, 640);
            mainLayout.ResumeLayout(false);
            headingPanel.ResumeLayout(false);
            headingPanel.PerformLayout();
            toolbarPanel.ResumeLayout(false);
            toolbarPanel.PerformLayout();
            roomsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void ConfigureRoom(global::Assignment.CustomUI.RoomUI room, string name, string type, string status, string image)
        {
            room.RoomName = name;
            room.RoomType = type;
            room.RoomStatus = status;
            room.ImageFileName = image;
            room.Margin = new Padding(6);
            room.Size = new Size(200, 330);
        }
    }
}