using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Assignment;

namespace Assignment.CustomUI
{
    public sealed class RoomUI : global::System.Windows.Forms.UserControl
    {
        private readonly PictureBox _photo;
        private readonly Label _nameLabel;
        private readonly Label _typeLabel;
        private readonly Label _statusLabel;
        private readonly Button _selectButton;
        private string _imageFileName = string.Empty;

        public event EventHandler? SelectClicked;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomName
        {
            get => _nameLabel.Text;
            set => _nameLabel.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomType
        {
            get => _typeLabel.Text;
            set => _typeLabel.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomStatus
        {
            get => _statusLabel.Text;
            set
            {
                _statusLabel.Text = value;
                bool available = string.Equals(value, "Available", StringComparison.OrdinalIgnoreCase);
                _statusLabel.BackColor = available ? Color.FromArgb(35, 92, 64) : Color.FromArgb(104, 62, 40);
                _statusLabel.ForeColor = available ? Color.FromArgb(155, 240, 185) : Color.FromArgb(255, 204, 155);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ImageFileName
        {
            get => _imageFileName;
            set
            {
                _imageFileName = value;
                LoadRoomPhoto();
            }
        }

        public RoomUI()
        {
            BackColor = Color.FromArgb(12, 12, 14);
            MinimumSize = new Size(190, 320);
            Size = new Size(220, 340);

            var card = new RoundedPanel
            {
                BorderRadius = 12,
                BackColor = Color.FromArgb(22, 22, 26),
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            Controls.Add(card);

            var layout = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                Dock = DockStyle.Fill,
                BackColor = card.BackColor
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            card.Controls.Add(layout);

            _photo = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(34, 34, 40),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            layout.Controls.Add(_photo, 0, 0);

            var details = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 4,
                Dock = DockStyle.Fill,
                BackColor = card.BackColor,
                Padding = new Padding(2, 8, 2, 0)
            };
            details.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            details.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            details.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            details.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            layout.Controls.Add(details, 0, 1);

            _nameLabel = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };
            details.Controls.Add(_nameLabel, 0, 0);

            _typeLabel = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(170, 170, 180),
                Font = new Font("Segoe UI", 9F),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };
            details.Controls.Add(_typeLabel, 0, 1);

            _statusLabel = new Label
            {
                AutoSize = true,
                Padding = new Padding(8, 3, 8, 3),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Anchor = AnchorStyles.Left,
                TextAlign = ContentAlignment.MiddleCenter
            };
            details.Controls.Add(_statusLabel, 0, 2);

            _selectButton = new Button
            {
                Text = "View room",
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.FromArgb(147, 51, 234),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            _selectButton.Click += (_, e) => SelectClicked?.Invoke(this, e);
            details.Controls.Add(_selectButton, 0, 3);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _photo.Image?.Dispose();
            base.Dispose(disposing);
        }

        internal void LoadRoomPhoto()
        {
            if (string.IsNullOrWhiteSpace(_imageFileName))
                return;

            string? imagePath = FindImagePath(_imageFileName);
            if (imagePath == null)
                return;

            using Image source = Image.FromFile(imagePath);
            Image? previous = _photo.Image;
            _photo.Image = new Bitmap(source);
            previous?.Dispose();
        }

        private static string? FindImagePath(string fileName)
        {
            for (DirectoryInfo? directory = new(AppContext.BaseDirectory); directory != null; directory = directory.Parent)
            {
                string path = Path.Combine(directory.FullName, "Pic", fileName);
                if (File.Exists(path))
                    return path;
            }

            return null;
        }
    }
}