using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            Start s1 = new Start();
            Visible = false;
            MsgClient M1 = new MsgClient();
            M1.Show();
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            Start s1 = new Start();
            Visible = false;
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
