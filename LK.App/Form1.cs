using LK.Application.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LK.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DataViewer.Form1_dataGridView1 = this.dataGridView1;
        }

        List<User> users = new List<User>();
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                User u = new User();
                u.Id = Guid.NewGuid().ToString();
                u.CreateTime = DateTime.Now.AddMinutes(new Random().Next(0, 5000));
                u.age = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);
                u.name = "小明 " + i;
                users.Add(u);
            }
            this.dataGridView1.ReLoad(users);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                await Task.Run(() =>
                {
                    int index = new Random((Guid.NewGuid().GetHashCode())).Next(0, users.Count);
                    var user = users.Where(c => c.rowIndex == index).FirstOrDefault();
                    user.name = Guid.NewGuid().ToString();
                    this.dataGridView1.Update(user);
                });
            }


        }
    }
}
