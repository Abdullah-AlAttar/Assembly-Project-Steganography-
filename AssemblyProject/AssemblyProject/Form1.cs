using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap image = null;
        String imagePixels = "";
        private void button1_Click(object sender, EventArgs e)
        {
          
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                
                if (CheckIfText(OpenedFilePath))
                {
                    MessageBox.Show(OpenedFilePath);
                    ReadFromFile(OpenedFilePath);
                    CreatImageFromTxt();
                  
                }
                else
                {
                    image = new Bitmap(OpenedFilePath);
                    WriteToFile();
                }
            }
            pictureBox1.Image = image;
        }

        private void CreatImageFromTxt()
        {
            string tmp = "";
            int idx = 0, height, width;

            // this loop for height;
            while(imagePixels[idx]!='\n')
            {
                tmp += imagePixels[idx];
                ++idx;
            }
            ++idx;
            int.TryParse(tmp,out height);
            tmp = "";
            // this loop for width;
            while (imagePixels[idx] != '\n')
            {
                tmp += imagePixels[idx];
                ++idx;
            }
            ++idx;
            int.TryParse(tmp, out width);
            image = new Bitmap(width, height);
            for(int i=0;i<height;++i)
            {

                for(int j=0;j<width;++j)
                {
                   
                    int red=0, green=0, blue=0;
                    for (int k = 0; k < 3; ++k)
                    {
                        tmp = "";
                        while (imagePixels[idx] != '\n')
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
                    image.SetPixel(j, i, Color.FromArgb(255, red, green, blue));
                }
            }
           
        }

        private bool CheckIfText(string openedFilePath)
        {
            int size = openedFilePath.Length;
            string tmp = "";
            tmp += openedFilePath[size - 3].ToString() + openedFilePath[size - 2].ToString() + openedFilePath[size - 1].ToString();
            return tmp == "txt";
        }

        private void WriteToFile()
        {

            using (StreamWriter writetext = new StreamWriter("write.txt"))
            {
                string imagePixels = "";
                imagePixels += image.Height.ToString() + "\n" + image.Width.ToString() + "\n";

                for (int i = 0; i < image.Height; ++i)
                {
                    for (int j = 0; j < image.Width; ++j)
                    {
                        imagePixels += image.GetPixel(j, i).R.ToString() + "\n";
                        imagePixels += image.GetPixel(j, i).G.ToString() + "\n";
                        imagePixels += image.GetPixel(j, i).B.ToString() + "\n";
                    }
                }
                writetext.WriteLine(imagePixels);
            }
        }
        private void ReadFromFile(string path)
        {
                imagePixels = File.ReadAllText(path);
        }
    }
}
