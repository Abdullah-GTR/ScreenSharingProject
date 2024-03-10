using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1_Server
{
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            Starter s1 = new Starter();
            Visible = false;
            Message M1 = new Message();
            M1.Show();
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            Starter s1 = new Starter();
            Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
