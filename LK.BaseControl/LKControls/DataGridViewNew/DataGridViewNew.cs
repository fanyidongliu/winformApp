using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LK.App
{
   public class DataGridViewNew : DataGridView
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
            }
            catch
            {

                Invalidate();
            }
        }

    }
}
