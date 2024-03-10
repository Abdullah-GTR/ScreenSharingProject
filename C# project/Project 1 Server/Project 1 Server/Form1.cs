using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project_1_Server
{
    public partial class Form1 : Form
    {
        



        public Form1()
        {
            InitializeComponent();
        }

        private void btnlisten_Click(object sender, EventArgs e)
        {
            new Form2(int.Parse(txtListen.Text)).Show();
            btnlisten.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
