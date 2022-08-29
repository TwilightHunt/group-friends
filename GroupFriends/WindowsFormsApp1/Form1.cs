using System;
using System.Windows.Forms;
using TwilightHunt.Shared.Emitter;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BridgeEmitter bridge = Storage.Get<BridgeEmitter>();
            bridge.Subscribe("Message", (args) => { textBox1.Text = args; });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
