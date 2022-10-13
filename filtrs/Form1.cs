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
using static System.Net.WebRequestMethods;

namespace filtrs
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создаем диалог для открытия файла
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files (*.*) | *.* "; //фильт открытия только изображений
                                                                                          // проверка выбора файла
            if (dialog.ShowDialog() == DialogResult.OK)
            { image = new Bitmap(dialog.FileName); }
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

      //  private void размытиеГаусаToolStripMenuItem_Click(object sender, EventArgs e)
        //{
          //  Filters filter = new GaussianFilter();
            //backgroundWorker1.RunWorkerAsync(filter);
        //}

        private void гаусианToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }



        private void чБToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new bright();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // ЭТО СОХРАНЯТЬ ФОТО НО ОНО ПОКА НЕ ОТКРЫВАЕТСЯ _________________________
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
          SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\xaugy\OneDrive\Рабочий стол\ФОТО ЛАБА\";
            sfd.RestoreDirectory = true;
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {

                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.button2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.button2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.button2.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new rezko();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Filters filter = new bright();
            Filters filter = new tisnenie();
            backgroundWorker1.RunWorkerAsync(filter);
            
            

        }

        private void переносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new perenos();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new povorot();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new volna();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волна2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new volna2();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкость2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new rezko2();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        
        private void фильтрыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       

        private void dilasionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DILATION dILATION = new DILATION();

            pictureBox1.Image = dILATION.doBinary(image);
            pictureBox1.Refresh();
        }

        private void eROSIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EROSION eROSION = new EROSION();

            pictureBox1.Image = eROSION.doBinary(image);
            pictureBox1.Refresh();
        }
    }


        // sfd.FileName = "фото фильтр.jpg";
        //sfd.DefaultExt = "jpg";
        //sfd.Filter = "JPeg Image|*.jpg";

        //     if (sfd.ShowDialog() == DialogResult.OK)
        //{
        //  Stream Image = sfd.OpenFile();
        //StreamWriter sw = new StreamWriter(Image);

  }
        //}
  //  }
//}
// ВОТ ДОСЮДА ___________________________________