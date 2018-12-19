using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalDesign
{
    public class MiscTools
    {
        public static void remove_row(TableLayoutPanel panel, int row_index_to_remove)
        {
            if (row_index_to_remove >= panel.RowCount)
            {
                return;
            }

            // delete all controls of row that we want to delete
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                var control = panel.GetControlFromPosition(i, row_index_to_remove);
                panel.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = row_index_to_remove + 1; i < panel.RowCount; i++)
            {
                for (int j = 0; j < panel.ColumnCount; j++)
                {
                    var control = panel.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        panel.SetRow(control, i - 1);
                    }
                }
            }

            // remove last row
            panel.RowStyles.RemoveAt(panel.RowCount - 1);
            panel.RowCount--;
        }
        public static void  BuildHpHeader(TableLayoutPanel x)
        {
            x.ColumnStyles.Clear();
            x.ColumnCount = 8;
            for(int i = 0; i < 8; i++ )
            { x.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); }

            x.RowCount = 1;
            x.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
            x.Controls.Add(new Label() { Text = "HPTYPE", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 0, 0);
            x.Controls.Add(new Label() { Text = "     Weapon Name    ", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 1, 0);
            x.Controls.Add(new Label() { Text = "ACC", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 2, 0);
            x.Controls.Add(new Label() { Text = "DMG", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 3, 0);
            x.Controls.Add(new Label() { Text = "ROF", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 4, 0);
            x.Controls.Add(new Label() { Text = "AMMO", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 5, 0);
            x.Controls.Add(new Label() { Text = " RANGE ", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 6, 0);
            x.Controls.Add(new Label() { Text = "    Special    ", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 7, 0);
        }
    }
}
