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
    public partial class Form2 : Form
    {
        private readonly int port;
        private TcpClient client;
        private TcpListener server;
        private NetworkStream ns;

        private readonly Thread listening;
        private readonly Thread getImage;

        public Form2(int Port)
        {
            port = Port;
            client = new TcpClient();
            listening = new Thread(StartListenning);
            getImage = new Thread(receiveImage);
            InitializeComponent();
        }

        public void StartListenning()
        {
            while(!client.Connected)
            {
                server.Start();
                client = server.AcceptTcpClient();
            }
            getImage.Start();

        }
        public void StopListenning()
        {
            server.Stop();
            client = null;
            if (listening.IsAlive)
                listening.Abort();
            if (getImage.IsAlive)
                getImage.Abort();

        }
        private void receiveImage()
        {
            BinaryFormatter binMatter = new BinaryFormatter();
            while(client.Connected)
            {
                ns = client.GetStream();
                pictureBox1.Image = (Image)binMatter.Deserialize(ns);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            server = new TcpListener(IPAddress.Any, port);
            listening.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopListenning();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
