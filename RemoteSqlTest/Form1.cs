using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Windows.Forms;

namespace RemoteSqlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Test1();

        }

        private void Test1()
        {
            ChannelServices.RegisterChannel(new TcpClientChannel(), true);
            RemoteObject.RemoteTest obj = (RemoteObject.RemoteTest)Activator.GetObject(typeof(RemoteObject.RemoteTest), "tcp://127.0.0.1:9999/heyu");
            var v1 = obj.Value1;
            this.dataGridView1.DataSource = obj.datable();
        }
    }
}
