using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Properties;

namespace WirelessPOS
{
    public partial class PatternView : Form
    {


        PictureBox[] picBoxes;


        char[] patterns;
        public string ResultPattern { get; set; }
        Queue<Image> imageQueue ;
        public PatternView(char[] pattern) : this()
        {
            patterns = pattern;
            for (int i = 0; i < patterns.Length; i++)
            {
                int picboxPos = int.Parse(patterns[i].ToString());
                Select(picboxPos);
                
            }
           
        }

        private void Select(int picboxPosition)
        {
            picBoxes[picboxPosition-1].Image = imageQueue.Dequeue();
            ResultPattern += picboxPosition;
        }


        public PatternView()
        {

            InitializeComponent();

            picBoxes = new PictureBox[] {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4,
                pictureBox5,
                pictureBox6,
                pictureBox7,
                pictureBox8,
                pictureBox9
            };

            Location = MousePosition;
            ResetForm();
          
        }

        private void ResetForm()
        {
            ResultPattern = string.Empty;

            foreach (var pic in picBoxes)
            {
                pic.Image = null;
            }

            var images = new Image[] {
             Resources.icons8_1_c_20px,
             Resources.icons8_2_c_20px,
             Resources.icons8_3_c_20px,
             Resources.icons8_4_c_20px,
             Resources.icons8_5_c_20px,
             Resources.icons8_6_c_20px,
             Resources.icons8_7_c_20px_1,
             Resources.icons8_8_c_20px,
             Resources.icons8_9_c_20px,
        };
            imageQueue = new Queue<Image>();
            foreach (var img in images)
            {
                imageQueue.Enqueue(img);
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            if (pb.Image == null)
            {

               var index = picBoxes.ToList().FindIndex(x=>x==pb);
                ResultPattern += index + 1;
                pb.Image = imageQueue.Dequeue();

            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void PatternView_Shown(object sender, EventArgs e)
        {
           
        }

        private void PatternView_Load(object sender, EventArgs e)
        {
           
        }
    }
}
