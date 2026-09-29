using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Assignment.CustomUI;

namespace Assignment
{
    public partial class DashboardUC : System.Windows.Forms.UserControl
    {
        private readonly DashboardUI _dashboardUI;

        public event EventHandler? PeriodChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RevenueValue
        {
            get => _dashboardUI.RevenueValue;
            set => _dashboardUI.RevenueValue = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RevenueDetail
        {
            get => _dashboardUI.RevenueDetail;
            set => _dashboardUI.RevenueDetail = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OccupancyValue
        {
            get => _dashboardUI.OccupancyValue;
            set => _dashboardUI.OccupancyValue = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string OccupancyDetail
        {
            get => _dashboardUI.OccupancyDetail;
            set => _dashboardUI.OccupancyDetail = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomsValue
        {
            get => _dashboardUI.RoomsValue;
            set => _dashboardUI.RoomsValue = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomsDetail
        {
            get => _dashboardUI.RoomsDetail;
            set => _dashboardUI.RoomsDetail = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedPeriod
        {
            get => _dashboardUI.PeriodSelector.SelectedItem?.ToString() ?? string.Empty;
            set
            {
                int index = _dashboardUI.PeriodSelector.Items.IndexOf(value);
                if (index >= 0)
                    _dashboardUI.PeriodSelector.SelectedIndex = index;
            }
        }

        public DashboardUC()
        {
            InitializeComponent();
            _dashboardUI = new DashboardUI();
            Controls.Add(_dashboardUI);
            _dashboardUI.ChartSurface.Paint += DrawRevenueChart;
            _dashboardUI.PeriodSelector.SelectedIndexChanged += (_, _) =>
            {
                _dashboardUI.ChartSurface.Invalidate();
                PeriodChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        private void DrawRevenueChart(object? sender, PaintEventArgs e)
        {
            Panel surface = (Panel)sender!;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle plot = new(48, 12, Math.Max(1, surface.ClientSize.Width - 60), Math.Max(1, surface.ClientSize.Height - 40));
            using var gridPen = new Pen(Color.FromArgb(48, 48, 54));
            using var textBrush = new SolidBrush(Color.FromArgb(150, 150, 160));
            using var textFont = new Font("Segoe UI", 8F);

            for (int i = 0; i <= 4; i++)
            {
                int y = plot.Top + plot.Height * i / 4;
                e.Graphics.DrawLine(gridPen, plot.Left, y, plot.Right, y);
                string label = $"${160 - i * 40}k";
                e.Graphics.DrawString(label, textFont, textBrush, 0, y - 8);
            }

            float[] values = _dashboardUI.PeriodSelector.SelectedIndex == 0
                ? [38, 48, 42, 60, 54, 70, 62, 76, 68, 88, 80, 96]
                : [45, 52, 48, 68, 58, 82, 74];
            string[] labels = _dashboardUI.PeriodSelector.SelectedIndex == 0
                ? ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
                : ["1", "5", "10", "15", "20", "25", "30"];
            PointF[] points = new PointF[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                float x = plot.Left + (float)i * plot.Width / (values.Length - 1);
                float y = plot.Bottom - values[i] * plot.Height / 100F;
                points[i] = new PointF(x, y);
                e.Graphics.DrawString(labels[i], textFont, textBrush, x - 10, plot.Bottom + 8);
            }

            using var path = new GraphicsPath();
            path.AddLines(points);
            path.AddLine(points[^1], new PointF(points[^1].X, plot.Bottom));
            path.AddLine(points[^1].X, plot.Bottom, points[0].X, plot.Bottom);
            path.CloseFigure();
            using var fill = new LinearGradientBrush(plot, Color.FromArgb(72, 147, 51, 234), Color.FromArgb(4, 147, 51, 234), LinearGradientMode.Vertical);
            e.Graphics.FillPath(fill, path);
            using var line = new Pen(Color.FromArgb(177, 110, 243), 2.5F);
            e.Graphics.DrawLines(line, points);
        }

        private void DashboardUC_Load(object? sender, EventArgs e)
        {
        }
    }
}