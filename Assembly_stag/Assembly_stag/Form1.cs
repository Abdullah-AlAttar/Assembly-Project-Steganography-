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
using System.Drawing.Imaging;



namespace Assembly_stag
{
           

    public partial class Form1 : Form
    {

        private Bitmap bmp = null;
        char[] delimiterChars = { ',' };

        int c = 2;

        bool Image_opened = false;
        bool message_entered = false;
        bool encrypted = false;
        [DllImport("Project.dll")]
        private static extern void Decrypt([In, Out]char[] arr2);
        [DllImport("Project.dll")]
        private static extern void ReadMessage();
        [DllImport("Project.dll")]
        private static extern void ReadPixels();
        [DllImport("Project.dll")]
        private static extern void ENCRYPT();
        [DllImport("Project.dll")]
        private static extern void SaveChanges();
        [DllImport("Project.dll")]
        private static extern void Encrypt_funs();
 
        public Form1()
        {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Image_opened == false)
                MessageBox.Show("You should open an image first ");
            else
            {
                Pop_out frm2 = new Pop_out();
                frm2.Show();
                message_entered = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (Image_opened==true)
            {
                SaveAsText();
                char[] outt = new char[10000];
                //assembly functions
                ReadPixels();
                Decrypt(outt);
                //----------
                MessageBox.Show("The message is : \n" + new string(outt));
            }
            else
            {
                string s="";
                if(Image_opened==false)
                    s += "You should open an image first\n";
                if (encrypted == true)
                    s += "NOT ALLOWED \n Save the encrypted image then open it to do decryption\n";
                MessageBox.Show(s);

            }
        }
        private void openImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";
            
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                bmp= new Bitmap(open_dialog.FileName);
                imagePictureBox.Image = bmp;
                Image_opened = true;
            }
        }
        public void SaveAsImage()
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Png Image|*.png|Bitmap Image|*.bmp";
            
            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                switch (save_dialog.FilterIndex)
                {
                    case 0:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Png);
                        }
                        break;
                    case 1:
                        {
                            bmp.Save(save_dialog.FileName, ImageFormat.Bmp);
                        }
                        break;
                }

            }
        }
        public void SaveAsTextToPath()
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Text File|*.txt";
            if (save_dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs_image = new FileStream(save_dialog.FileName, FileMode.Create);  // create if not found ,overwrite if found
                StreamWriter sw_image = new StreamWriter(fs_image);
                int h = bmp.Height;
                int w = bmp.Width;
                sw_image.Write(h);
                sw_image.Write(",");
                sw_image.Write(w);
                sw_image.Write(",");
                // traverse the photo row by row
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        Color pixel = bmp.GetPixel(j, i);// get current pixel at bitmap http://www.yevol.com/illustrations/rectangle3.gif

                        sw_image.Write(pixel.R); sw_image.Write(",");
                        sw_image.Write(pixel.G); sw_image.Write(",");
                        sw_image.Write(pixel.B); sw_image.Write(",");
                    }
                }
                sw_image.WriteLine();
                sw_image.Close();
                fs_image.Close();
            }
        }
        public void SaveAsText()
        {
            FileStream fs_image = new FileStream("text_of_image.txt", FileMode.Create);  // create if not found ,overwrite if found
            StreamWriter sw_image = new StreamWriter(fs_image);

            int h = bmp.Height;
            int w = bmp.Width;

            sw_image.Write(h);sw_image.Write(",");
            sw_image.Write(w);sw_image.Write(",");
            // traverse the photo row by row
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);// get current pixel at bitmap http://www.yevol.com/illustrations/rectangle3.gif
                    sw_image.Write(pixel.R);sw_image.Write(",");
                    sw_image.Write(pixel.G);sw_image.Write(",");
                    sw_image.Write(pixel.B);sw_image.Write(",");

                }
            }
            sw_image.WriteLine();
            sw_image.Close();
            fs_image.Close();
        }

        private void saveCurentImageAsAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Image_opened == false)
            {
                MessageBox.Show("You should open an image first ");
            }
            else
            {
                SaveAsTextToPath();
            }

        }

        private void openTxtImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Text Files|*.txt";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                string imagePixels = File.ReadAllText(open_dialog.FileName);
                string tmp = "";
                int idx = 0, height, width;

                // this loop for height;
                while (imagePixels[idx] != ',')
                {
                    tmp += imagePixels[idx];
                    ++idx;
                }
                ++idx;
                int.TryParse(tmp, out height);
                tmp = "";
                // this loop for width;
                while (imagePixels[idx] != ',')
                {
                    tmp += imagePixels[idx];
                    ++idx;
                }
                ++idx;
                int.TryParse(tmp, out width);
                bmp = new Bitmap(width, height);
                for (int i = 0; i < height; ++i)
                {

                    for (int j = 0; j < width; ++j)
                    {

                        int red = 0, green = 0, blue = 0;
                        for (int k = 0; k < 3; ++k)
                        {
                            tmp = "";
                            while (imagePixels[idx] != ',')
                            {
                                tmp += imagePixels[idx];
                                ++idx;
                            }
                            ++idx;
                            if (k == 0)
                                int.TryParse(tmp, out red);
                            else if (k == 1)
                                int.TryParse(tmp, out green);
                            else
                                int.TryParse(tmp, out blue);
                        }
                        bmp.SetPixel(j, i, Color.FromArgb( red, green, blue));
                        Image_opened = true;
                        this.imagePictureBox.Image = bmp;
                    }
                }
            }
            SaveAsText();
        }

        //encrypt button
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (Image_opened==true && message_entered==true)
            {
                SaveAsText();
                //assembly functions
                ReadMessage();
                ReadPixels();
                ENCRYPT();
                SaveChanges();
                //-------
                MessageBox.Show("You message has been succesfully encrypted");
                MessageBox.Show("You should save the new encrypted image from down button");
                encrypted = true;
            }
            else
            {
                string s = "";
                if (Image_opened == false)
                    s += "You should open an image first\n";
                if (message_entered == false)
                    s += "You should enter a message\n";
                MessageBox.Show(s);
            }
        }

        
        private void saveCurentImageAsItToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Image_opened == true)
            {
                SaveAsImage();
            }
            else
            {
                MessageBox.Show("You should open an image first ");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

            if (Image_opened==true && encrypted==true)
            {
                FileStream fss_image = new FileStream("text_of_image.txt", FileMode.Open);
                StreamReader sw_image = new StreamReader(fss_image);
                string s = sw_image.ReadToEnd();
                string[] words = s.Split(delimiterChars);
                int h = int.Parse(words[0]);
                int w = int.Parse(words[1]);
                bmp = new Bitmap(w, h);
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        bmp.SetPixel(j, i, Color.FromArgb(int.Parse(words[c]), int.Parse(words[c + 1]), int.Parse(words[c + 2])));
                        c += 3;
                    }
                }
        
                Image_opened = true;
                SaveAsImage();
                sw_image.Close();
                fss_image.Close();
            }
            else
            {
                string s = "";
                if (Image_opened == false)
                    s += "You should open an image first\n";
                if (encrypted == false)
                    s += "You should encrypt a message\n";
                MessageBox.Show(s);

            }
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
