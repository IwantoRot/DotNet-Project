using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Assignment
{
    public class GradientLabel : Label
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GradientStart { get; set; } = Color.FromArgb(147, 51, 234);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GradientEnd { get; set; } = Color.FromArgb(239, 68, 68);

        public GradientLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            BackColor = Color.Transparent;
            AutoSize = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, GradientStart, GradientEnd, 0f))
            {
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(Text, Font, brush, ClientRectangle, sf);
                }
            }
        }
    }

    public class NavButton : Button
    {
        private bool _isActive = false;

        [DefaultValue(12)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderRadius { get; set; } = 12;

        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GradientStart { get; set; } = Color.FromArgb(147, 51, 234);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GradientEnd { get; set; } = Color.FromArgb(239, 68, 68);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color InactiveColor { get; set; } = Color.FromArgb(32, 33, 44);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color InactiveTextColor { get; set; } = Color.FromArgb(160, 160, 175);

        public NavButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Cursor = Cursors.Hand;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0) return;
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = Math.Min(BorderRadius * 2, Math.Min(Width, Height));
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(Width - d, 0, d, d, 270, 90);
                path.AddArc(Width - d, Height - d, d, d, 0, 90);
                path.AddArc(0, Height - d, d, d, 90, 90);
                path.CloseFigure();
                (this.Region as System.IDisposable)?.Dispose();
                this.Region = new System.Drawing.Region(path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (IsActive)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, GradientStart, GradientEnd, 0f))
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
                TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(InactiveColor))
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
                TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, InactiveTextColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }

    public class GradientButton : Button
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GradientStart { get; set; } = Color.FromArgb(147, 51, 234);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color GradientEnd { get; set; } = Color.FromArgb(239, 68, 68);

        public GradientButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Cursor = Cursors.Hand;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, GradientStart, GradientEnd, 0f))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }

    public class RoundedPanel : Panel
    {
        [DefaultValue(12)]
        public int BorderRadius { get; set; } = 12;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (Width <= 0 || Height <= 0) return;
            using (GraphicsPath path = new GraphicsPath())
            {
                int d = Math.Min(BorderRadius * 2, Math.Min(Width, Height));
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(Width - d, 0, d, d, 270, 90);
                path.AddArc(Width - d, Height - d, d, d, 0, 90);
                path.AddArc(0, Height - d, d, d, 90, 90);
                path.CloseFigure();
                (this.Region as System.IDisposable)?.Dispose();
                this.Region = new System.Drawing.Region(path);
            }
        }
    }

    public class DarkMenuRenderer : ToolStripProfessionalRenderer
    {
        public DarkMenuRenderer() : base(new DarkColorTable()) { }
    }

    public class DarkColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => Color.FromArgb(28, 29, 38);
        public override Color MenuStripGradientEnd => Color.FromArgb(28, 29, 38);
        public override Color ToolStripDropDownBackground => Color.FromArgb(28, 29, 38);
        public override Color MenuItemSelected => Color.FromArgb(48, 50, 64);
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(48, 50, 64);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(48, 50, 64);
        public override Color SeparatorDark => Color.FromArgb(50, 52, 65);
    }
}