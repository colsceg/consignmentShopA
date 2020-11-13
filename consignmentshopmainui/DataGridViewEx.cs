using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopMainUI
{
    class DataGridViewEx : DataGridView
    {
    public DataGridViewEx(): base()
        {
            VerticalScrollBar.Visible = true;
            VerticalScrollBar.VisibleChanged += new EventHandler(VerticalScrollBar_VisibleChanged);
        }

        void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            if (!VerticalScrollBar.Visible)
            {
                int width = VerticalScrollBar.Width;
                VerticalScrollBar.Location =
                  new Point(ClientRectangle.Width - width, 1);

                VerticalScrollBar.Size =
                  new Size(width, ClientRectangle.Height - 1 - this.HorizontalScrollBar.Height);
                VerticalScrollBar.Show();
            }

        }

    }
}
