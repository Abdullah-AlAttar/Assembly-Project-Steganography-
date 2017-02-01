using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Assembly_stag
{
    public partial class Pop_out : Form
    {
        FileStream fs_message;
        StreamWriter sw_message;
        public Pop_out()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (message.Text == "")
                MessageBox.Show("Please type your message ");
            else if(message.Text.Length>9900)
            {
                MessageBox.Show("The message your entered is too large");

            }
            else
            {
                MessageBox.Show("Are you sure ?");
                fs_message = new FileStream("text_of_message.txt", FileMode.Create);  // create if not found ,overwrite if found
                sw_message = new StreamWriter(fs_message);
                sw_message.Write(message.Text);
                sw_message.Close();
                fs_message.Close();
                this.Close();
            }
        }

        private void message_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
