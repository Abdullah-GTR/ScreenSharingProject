using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1
{
    public partial class MsgClient : Form
    {
        public MsgClient()
        {
            InitializeComponent();
        }

        byte[] b = new byte[1024];
        TcpClient cl = new TcpClient();

        private void btnCon_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            cl.Connect(IPAddress.Loopback, 11000);
            NetworkStream ns = cl.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine("@name@" + txtCon.Text);
            sw.Flush();
            ns.BeginRead(b, 0, b.Length, ReadMsg, ns);

        }
        private void ReadMsg(IAsyncResult ar)
        {
            NetworkStream ns = (NetworkStream)ar.AsyncState;
            int count = ns.EndRead(ar);
            txtDisplay.Text += ASCIIEncoding.ASCII.GetString(b, 0, count);
            ns.BeginRead(b, 0, b.Length, ReadMsg, ns);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream ns = cl.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            
            sw.WriteLine(txtCon.Text + " Says: " + txtMsg.Text);
            sw.Flush();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            Start s1 = new Start();
            s1.Show();
        }
    }
}
