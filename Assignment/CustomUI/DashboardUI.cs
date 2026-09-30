using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Assignment;

namespace Assignment.CustomUI
{
    internal sealed class DashboardUI : System.Windows.Forms.UserControl
    {
        private static readonly Color CardColor = Color.FromArgb(22, 22, 26);
        private static readonly Color MutedText = Color.FromArgb(160, 160, 170);
        private static readonly Color Accent = Color.FromArgb(147, 51, 234);

        private readonly MetricCard _revenueCard;
        private readonly MetricCard _occupancyCard;
        private readonly MetricCard _roomsCard;

        internal Panel ChartSurface { get; }
        internal ComboBox PeriodSelector { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string RevenueValue { get => _revenueCard.Value; set => _revenueCard.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string RevenueDetail { get => _revenueCard.Detail; set => _revenueCard.Detail = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string OccupancyValue { get => _occupancyCard.Value; set => _occupancyCard.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string OccupancyDetail { get => _occupancyCard.Detail; set => _occupancyCard.Detail = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string RoomsValue { get => _roomsCard.Value; set => _roomsCard.Value = value; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string RoomsDetail { get => _roomsCard.Detail; set => _roomsCard.Detail = value; }

        internal DashboardUI()
        {
            BackColor = Color.FromArgb(12, 12, 14);
            Dock = DockStyle.Fill;
            AutoScroll = true;

            var content = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Dock = DockStyle.Top,
                Height = 720,
                Padding = new Padding(4)
            };
            content.SizeChanged += (_, _) => ResizeSections(content);
            Controls.Add(content);

            var metrics = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 1,
                Height = 138,
                Margin = new Padding(0, 0, 0, 12),
                BackColor = BackColor,
                GrowStyle = TableLayoutPanelGrowStyle.FixedSize
            };
            metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333F));
            metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333F));
            metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.334F));
            _revenueCard = new MetricCard("Total Revenue (Monthly)", "$142,586.00", "+42.8% from last month");
            _occupancyCard = new MetricCard("Average Usage Rate", "100.0%", "24 of 24 rooms utilized this month");
            _roomsCard = new MetricCard("Rooms Occupied", "24", "of 24 rooms this month");
            metrics.Controls.Add(_revenueCard, 0, 0);
            metrics.Controls.Add(_occupancyCard, 1, 0);
            metrics.Controls.Add(_roomsCard, 2, 0);
            content.Controls.Add(metrics);

            var middle = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 1,
                Height = 310,
                Margin = new Padding(0, 0, 0, 12),
                BackColor = BackColor
            };
            middle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.666F));
            middle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.334F));

            var chartCard = new RoundedPanel
            {
                BorderRadius = 12,
                BackColor = CardColor,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 6, 0),
                Padding = new Padding(16)
            };
            var chartHeader = new Panel { Dock = DockStyle.Top, Height = 38, BackColor = CardColor };
            chartHeader.Controls.Add(new Label
            {
                Text = "Revenue Overview",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(0, 4)
            });
            PeriodSelector = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 105,
                Height = 28,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = Color.FromArgb(32, 32, 36),
                ForeColor = Color.White
            };
            PeriodSelector.Items.AddRange(new object[] { "This year", "This month" });
            PeriodSelector.SelectedIndex = 0;
            chartHeader.Controls.Add(PeriodSelector);
            chartHeader.Resize += (_, _) => PeriodSelector.Location = new Point(chartHeader.ClientSize.Width - PeriodSelector.Width, 0);
            chartCard.Controls.Add(chartHeader);
            ChartSurface = new Panel { Dock = DockStyle.Fill, BackColor = CardColor };
            chartCard.Controls.Add(ChartSurface);
            middle.Controls.Add(chartCard, 0, 0);

            var rightColumn = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                Dock = DockStyle.Fill,
                BackColor = BackColor,
                Margin = new Padding(6, 0, 0, 0)
            };
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            rightColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            rightColumn.Controls.Add(CreateRoomStatus(), 0, 0);
            rightColumn.Controls.Add(CreateSection("Upcoming Reservations", "No upcoming reservations", new Padding(0, 6, 0, 0)), 0, 1);
            middle.Controls.Add(rightColumn, 1, 0);
            content.Controls.Add(middle);

            content.Controls.Add(CreateReservationsSection());
            ResizeSections(content);
        }

        private void ResizeSections(FlowLayoutPanel content)
        {
            int sectionWidth = Math.Max(0, content.ClientSize.Width - content.Padding.Horizontal);
            foreach (Control control in content.Controls)
                control.Width = sectionWidth;
        }

        private static RoundedPanel CreateRoomStatus()
        {
            var card = CreateSection("Room Status", null, new Padding(0, 0, 0, 6));
            var body = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = CardColor,
                Padding = new Padding(16, 4, 16, 14)
            };
            body.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            body.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            body.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            body.Controls.Add(new Label
            {
                Text = "24 of 24 rooms occupied",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            }, 0, 0);
            body.Controls.Add(new ProgressBar
            {
                Value = 100,
                Style = ProgressBarStyle.Continuous,
                Dock = DockStyle.Fill,
                ForeColor = Accent
            }, 0, 1);
            body.Controls.Add(new Label
            {
                Text = "Occupancy is at full capacity",
                ForeColor = MutedText,
                Font = new Font("Segoe UI", 9F),
                TextAlign = ContentAlignment.TopLeft,
                Dock = DockStyle.Fill
            }, 0, 2);
            card.Controls.Add(body);
            return card;
        }

        private static RoundedPanel CreateSection(string title, string? message, Padding margin)
        {
            var card = new RoundedPanel
            {
                BorderRadius = 12,
                BackColor = CardColor,
                Dock = DockStyle.Fill,
                Margin = margin,
                Padding = new Padding(16)
            };
            var heading = new Label
            {
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 34,
                TextAlign = ContentAlignment.MiddleLeft
            };
            card.Controls.Add(heading);
            if (message != null)
            {
                card.Controls.Add(new Label
                {
                    Text = message,
                    ForeColor = MutedText,
                    Font = new Font("Segoe UI", 9F),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                });
            }
            return card;
        }

        private static RoundedPanel CreateReservationsSection()
        {
            var card = CreateSection("Recent Reservations", null, new Padding(0));
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 2,
                BackColor = CardColor,
                Padding = new Padding(0, 6, 0, 0)
            };
            for (int i = 0; i < 4; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            string[] headings = { "Guest", "Room", "Check-in", "Status" };
            for (int i = 0; i < headings.Length; i++)
            {
                table.Controls.Add(new Label
                {
                    Text = headings[i],
                    ForeColor = MutedText,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                }, i, 0);
            }
            table.Controls.Add(new Label
            {
                Text = "No reservation data available",
                ForeColor = MutedText,
                Font = new Font("Segoe UI", 9F),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            }, 0, 1);
            table.SetColumnSpan(table.GetControlFromPosition(0, 1)!, 4);
            card.Controls.Add(table);
            return card;
        }

        private sealed class MetricCard : RoundedPanel
        {
            private readonly Label _value;
            private readonly Label _detail;

            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal string Value { get => _value.Text; set => _value.Text = value; }
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal string Detail { get => _detail.Text; set => _detail.Text = value; }

            internal MetricCard(string title, string value, string detail)
            {
                BorderRadius = 12;
                BackColor = CardColor;
                Dock = DockStyle.Fill;
                Margin = new Padding(0, 0, 12, 0);
                Padding = new Padding(16, 12, 16, 12);
                var layout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 3,
                    BackColor = CardColor
                };
                layout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
                layout.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
                layout.RowStyles.Add(new RowStyle(SizeType.Percent, 28F));
                layout.Controls.Add(new Label
                {
                    Text = title,
                    ForeColor = MutedText,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                }, 0, 0);
                _value = new Label
                {
                    Text = value,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoEllipsis = true
                };
                layout.Controls.Add(_value, 0, 1);
                _detail = new Label
                {
                    Text = detail,
                    ForeColor = Color.FromArgb(94, 220, 140),
                    Font = new Font("Segoe UI", 8.5F),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoEllipsis = true
                };
                layout.Controls.Add(_detail, 0, 2);
                Controls.Add(layout);
            }
        }
    }
}
