using System;
using System.Drawing;
using System.Windows.Forms;

namespace IBANYR
{
    class DgvColumnPanel : Panel
    {
        readonly DataGridView dgv;
        public DgvColumnPanel(DataGridView dgv) : base()
        {
            this.dgv = dgv;
            var relativePoint = dgv.Parent.PointToClient(Cursor.Position);
            foreach (Control item in dgv.Parent.Controls)
            {
                if (item is DgvColumnPanel)
                {
                    item.Dispose();
                }
            }
            this.Parent = dgv.Parent;
            this.Top = relativePoint.Y;
            this.Left = relativePoint.X;
            this.AutoSize = true;
            this.AutoScroll = true;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Name = "columnPanel";
            this.Click += DgvColumnPanel_Click;
            int top = 0;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                CheckBox chb = new CheckBox()
                {
                    Parent = this,
                    Text = dgv.Columns[i].HeaderText,
                    Name = dgv.Columns[i].Name,
                    CheckAlign = ContentAlignment.MiddleLeft,
                    Checked = dgv.Columns[i].Visible,
                    Top = top + 5,
                    Left = 5,
                    AutoSize = true
                };
                chb.CheckedChanged += ColumnPanelItem_Event;
                top = chb.Bottom;
            }
            Label close = new Label()
            {
                Parent = this,
                Top = 0,
                Text = "×",
                AutoSize = true,
                Cursor = Cursors.Hand,
                Name = "close",
                Margin = new Padding(0,0,20,0)
            };
            close.Left = this.Width - 10;
            close.Click += ColumnPanelItem_Event;
            if (this.Width + this.Left > this.Parent.Width)
            {
                this.Left = this.Parent.Width - this.Width - 10;
            }
            this.MaximumSize = new Size(Parent.Width - Left, Parent.Height - Top);
            this.Show();
            this.BringToFront();
        }

        private void DgvColumnPanel_Click(object sender, EventArgs e)
        {
            if (sender is DgvColumnPanel)
            {
                this.Dispose();
            }
        }

        private void ColumnPanelItem_Event(object sender, EventArgs e)
        {
            if (sender is CheckBox chb)
            {
                this.dgv.Columns[chb.Name].Visible = chb.Checked;
            }
            else if (sender is Label lbl)
            {
                lbl.Parent.Dispose();
            }
        }
    }
}
