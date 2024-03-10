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
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project_1
{
    public partial class Form1 : Form
    {
        private readonly TcpClient client = new TcpClient();
        private NetworkStream ns;
        private int portNumber;

        private static Image grabDesktop()
        {
            Rectangle bound = Screen.PrimaryScreen.Bounds;
            Bitmap screenShot = new Bitmap(bound.Width, bound.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenShot);
            graphics.CopyFromScreen(bound.X, bound.Y, 0, 0, bound.Size, CopyPixelOperation.SourceCopy);

            return screenShot;
        }

        private void sendImage()
        {
            BinaryFormatter binMatter = new BinaryFormatter();
            ns = client.GetStream();
            binMatter.Serialize(ns, grabDesktop());
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnShare.Enabled = false;
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            portNumber = int.Parse(txtPort.Text);
            try
            {
                client.Connect(txtIP.Text, portNumber);
                btnCon.Text = "Connect";
                MessageBox.Show("Connect");
                btnCon.Enabled = false;
                btnShare.Enabled = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to Connect");
                btnCon.Text = "Not Connected";
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if(btnShare.Text.StartsWith("Share"))
            {
                timer1.Start();
                btnShare.Text = "Stop Sharing";
            }
            else
            {
                timer1.Stop();
                btnShare.Text = "Share My Screen";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sendImage(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            Start s1 = new Start();
            s1.Show();
        }
    }
}
