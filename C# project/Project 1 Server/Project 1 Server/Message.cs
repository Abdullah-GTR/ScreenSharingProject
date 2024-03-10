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

namespace Project_1_Server
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }

        private void Message_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            TcpListener lis = new TcpListener(IPAddress.Loopback, 11000);
            lis.Start(10);
            lis.BeginAcceptTcpClient(new AsyncCallback(ClientConnect), lis);

        }
        Dictionary<string, TcpClient> ListCLient = new Dictionary<string, TcpClient>();
        byte[] b = new byte[1024];

        private void ClientConnect(IAsyncResult ar)
        {
            TcpListener lis = (TcpListener)ar.AsyncState;
            TcpClient cl = lis.EndAcceptTcpClient(ar);
            NetworkStream ns = cl.GetStream();
            object[] a = new object[2];
            a[0] = ns;
            a[1] = cl;
            ns.BeginRead(b, 0, b.Length, new AsyncCallback(ReadMsg), a);
            lis.BeginAcceptTcpClient(new AsyncCallback(ClientConnect), lis);
        }

        private void ReadMsg(IAsyncResult ar)
        {
            object[] a = (object[])ar.AsyncState;
            NetworkStream ns = (NetworkStream)a[0];
            TcpClient cl = (TcpClient)a[1];
            int count = ns.EndRead(ar);
            string msg = ASCIIEncoding.ASCII.GetString(b, 0, count);
            if (msg.Contains("@name@"))
            {
                string name = msg.Replace("@name@", "");
                ListCLient.Add(name, cl);
                lstBx.Items.Add(name);
            }
            else
            {
                txtDisplay.Text += msg + Environment.NewLine;
            }
            ns.BeginRead(b, 0, b.Length, new AsyncCallback(ReadMsg), a);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            TcpClient cl = (TcpClient)ListCLient[lstBx.SelectedItem.ToString()];
            NetworkStream ns = cl.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            string textToSend = "Server Says: " + txtMsg.Text;
            sw.WriteLine(textToSend);
            txtDisplay.Text += textToSend + Environment.NewLine;
            sw.Flush();

        }

        private void btnSndAll_Click(object sender, EventArgs e)
        {
            foreach (var item in ListCLient.Values)
            {
                NetworkStream ns = item.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine(txtMsg.Text);
                sw.Flush();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            Starter s1 = new Starter();
            s1.Show();
        }
    }
}
