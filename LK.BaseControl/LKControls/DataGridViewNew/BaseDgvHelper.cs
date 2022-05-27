using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LK.App.LKControls;

namespace LK.App
{
    public static class DgvExt
    {
        // 刷新集合
        public static void ReLoad<T>(this DataGridViewNew dgv, List<T> users) where T : BaseDgvDto, new()
        {
            Action act = () =>
            {
                dgv.Rows.Clear();
                foreach (var user in users)
                {
                    int index = dgv.Rows.Add();
                    user.rowIndex = index;
                    var row = dgv.Rows[index];

                    var props = user.GetType().GetProperties();
                    foreach (var item in props)
                    {
                        var attrs = item.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                        if (attrs != null && attrs.Count() > 0) continue;
                        dgv.Rows[index].Cells[item.Name].Value = item.GetValue(user, null);
                    }
                }
            };
            dgv.BeginInvoke(act);
        }
        public static void Add<T>(this DataGridViewNew dgv, T user) where T : BaseDgvDto, new()
        {
            Action act = () =>
            {
                int index = dgv.Rows.Add();
                user.rowIndex = index;
                var row = dgv.Rows[index];

                var props = user.GetType().GetProperties();
                foreach (var item in props)
                {
                    var attrs = item.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    if (attrs != null && attrs.Count() > 0) continue;
                    dgv.Rows[index].Cells[item.Name].Value = item.GetValue(user, null);
                }
            };
            dgv.BeginInvoke(act);
        }
        public static void Update<T>(this DataGridViewNew dgv, T user) where T : BaseDgvDto, new()
        {
            Action act = () =>
            {
                var row = dgv.Rows[user.rowIndex];
                var props = user.GetType().GetProperties();
                foreach (var item in props)
                {
                    var attrs = item.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    if (attrs != null && attrs.Count() > 0) continue;
                    dgv.Rows[user.rowIndex].Cells[item.Name].Value = item.GetValue(user, null);
                }
            };
            dgv.BeginInvoke(act);
        }
        public static void Delete<T>(this DataGridViewNew dgv, T user) where T : BaseDgvDto, new()
        {
            Action act = () => dgv.Rows.RemoveAt(user.rowIndex);
            dgv.BeginInvoke(act);
        }
    }   
}
