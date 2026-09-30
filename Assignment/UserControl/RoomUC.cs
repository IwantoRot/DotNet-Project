using System.ComponentModel;
using Assignment.CustomUI;

namespace Assignment.UserControl
{
    public partial class RoomUC : global::System.Windows.Forms.UserControl
    {
        private RoomUI[] _roomCards = Array.Empty<RoomUI>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? SelectedRoom { get; private set; }

        public event EventHandler? RoomSelected;

        public RoomUC()
        {
            InitializeComponent();

            _roomCards = [roomCard1, roomCard2, roomCard3, roomCard4, roomCard5, roomCard6, roomCard7, roomCard8];
            foreach (RoomUI room in _roomCards)
                room.SelectClicked += Room_SelectClicked;

            searchTextBox.TextChanged += Filters_Changed;
            statusComboBox.SelectedIndexChanged += Filters_Changed;
            roomFlowPanel.SizeChanged += RoomFlowPanel_SizeChanged;
            ResizeRoomCards();
            ApplyFilters();
        }

        private void Filters_Changed(object? sender, EventArgs e) => ApplyFilters();

        private void ApplyFilters()
        {
            string search = searchTextBox.Text.Trim();
            string status = statusComboBox.SelectedItem?.ToString() ?? "All rooms";
            int visibleCount = 0;

            foreach (RoomUI room in _roomCards)
            {
                bool matchesSearch = room.RoomName.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || room.RoomType.Contains(search, StringComparison.OrdinalIgnoreCase);
                bool matchesStatus = status == "All rooms"
                    || string.Equals(room.RoomStatus, status, StringComparison.OrdinalIgnoreCase);
                room.Visible = matchesSearch && matchesStatus;
                if (room.Visible)
                    visibleCount++;
            }

            roomCountLabel.Text = $"{status} ({visibleCount})";
            emptyStateLabel.Visible = visibleCount == 0;
        }

        private void RoomFlowPanel_SizeChanged(object? sender, EventArgs e) => ResizeRoomCards();

        private void ResizeRoomCards()
        {
            const int minimumCardWidth = 190;
            const int horizontalMargin = 12;
            int availableWidth = roomFlowPanel.ClientSize.Width - roomFlowPanel.Padding.Horizontal;
            int columns = Math.Clamp(availableWidth / (minimumCardWidth + horizontalMargin), 1, 4);
            int cardWidth = Math.Max(minimumCardWidth, (availableWidth / columns) - horizontalMargin);

            foreach (RoomUI room in _roomCards)
                room.Width = cardWidth;
        }

        private void Room_SelectClicked(object? sender, EventArgs e)
        {
            if (sender is not RoomUI room)
                return;

            SelectedRoom = room.RoomName;
            RoomSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
