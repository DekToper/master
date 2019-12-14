using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetPanels();
        }

        string first = "white";
        string second = "Black";
        bool drag = false;
        Panel[,] panels = new Panel[8,8];
        Panel to;
        Panel win_to;
        int Bp_ = 0;
        int Wp_ = 0;

        

        void LeftButtonMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            { 
                DoDragDrop((sender as Panel).BackgroundImage, DragDropEffects.Copy);
                Logic(sender);
                if (drag == true)
                {
                    if (win_to == to)
                    {
                        to.BackgroundImage = (sender as Panel).BackgroundImage;
                    }
                    else
                    {
                        to.BackgroundImage = null;
                        win_to.BackgroundImage = (sender as Panel).BackgroundImage;
                    }
                    (sender as Panel).BackgroundImage = null;
                    drag = false;
                }
            }
            if(Wp_ == 12 || Bp_ == 12)
            {
                MessageBox.Show("Виграв гравець фішок - " + first + "!\n З рахунком - " + Wp_ + "/" + Bp_, "End", MessageBoxButtons.OK);
            }
        }

        void TextBoxDragDrop(object sender, DragEventArgs e)
        {         
            Text = "Iamge";
            to = sender as Panel;
        }


        void GetPanels()
        {
            int k = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Controls[k].Name.Contains("panel"))
                    {
                        try
                        {
                            panels[i, j] = Controls[k] as Panel;
                        }
                        catch {}
                    }
                    else
                    {
                        j--;
                    }

                    k++;
                    }
            }
            for (int kl = 0; kl < 8; kl++)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        int Y = panels[i, j].Location.Y;
                        int X = panels[i, j].Location.X / 100;
                        Y = (Y - (Y / 100) * 100) - 12;
                        if (i != X || j != Y)
                        {
                            Panel p = panels[i, j];
                            panels[i, j] = panels[X, Y];
                            panels[X, Y] = p;
                        }
                    }
                }
            }
        }

        void swap(object a,object b)
        {
            object buffer;
            buffer = a;
            a = b;
            b = buffer;
            
        }


        void Logic(object sender)
        {
            int i_from = 0;
            int j_from = 0;

            int i_to = 0;
            int j_to = 0;

            win_to = to;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (panels[j, i].Location == to.Location)
                    {
                        i_to = j;
                        j_to = i;
                        
                    }

                    if (panels[j, i].Location == (sender as Panel).Location)
                    {
                        i_from = j;
                        j_from = i;
                        
                    }

                }
            }
           if(first == (sender as Panel).Tag.ToString())
           {
                if (panels[i_from,j_from].Location.X + 150 > panels[i_to,j_to].Location.X && panels[i_from, j_from].Location.X - 150 < panels[i_to, j_to].Location.X)
                {
                    if (panels[i_from, j_from].Location.Y + 101 == panels[i_to, j_to].Location.Y)
                    {
                        if (panels[i_from, j_from].Tag == "Black")
                        {
                            
                        }
                        else
                        {
                            if (panels[i_from, j_from].Tag == "white" && first == "white")
                            {
                                if(panels[i_to, j_to].Tag == "Black")
                                {
                                    if (panels[i_to, j_to].Location.X >= 705 || panels[i_to, j_to].Location.X <= 13 || panels[i_to, j_to].Location.Y == 709 || panels[i_to, j_to].Location.Y == 12)
                                    {
                                        drag = false;
                                    }
                                    else
                                    {
                                        if (panels[i_from, j_from].Location.X + 150 > panels[i_to, j_to].Location.X && panels[i_from, j_from].Location.X + 50 < panels[i_to, j_to].Location.X)
                                        {
                                            if(panels[i_to + 1,j_to + 1].Tag != "Black" && panels[i_to + 1, j_to + 1].Tag != "white")
                                            {
                                                win_to = panels[i_to + 1, j_to + 1];
                                                drag = true;
                                            }
                                        }
                                        else
                                        {
                                            if (panels[i_to - 1, j_to + 1].Tag != "Black" && panels[i_to - 1, j_to + 1].Tag != "white")
                                            {
                                                win_to = panels[i_to - 1, j_to + 1];
                                                drag = true;
                                            }
                                        }
                                        Wp_ += 1;
                                        Wp.Text = Convert.ToString(Wp_);
                                    }
                                }
                                else if (panels[i_to, j_to].Tag == "white")
                                {
                                    drag = false;
                                }
                                else
                                {
                                    drag = true;
                                }

                            }
                        }
                    }
                    else if (panels[i_from, j_from].Location.Y - 101 == panels[i_to, j_to].Location.Y)
                    {
                        if (panels[i_from, j_from].Tag == "white")
                        {

                        }
                        else
                        {
                            if (panels[i_from, j_from].Tag == "Black" && first == "Black")
                            {
                                if (panels[i_to, j_to].Tag == "white")
                                {
                                    if (panels[i_to, j_to].Location.X >= 705 || panels[i_to, j_to].Location.X <= 13 || panels[i_to, j_to].Location.Y == 709 || panels[i_to, j_to].Location.Y == 12)
                                    {
                                        drag = false;
                                    }
                                    else
                                    {
                                        if (panels[i_from, j_from].Location.X + 150 > panels[i_to, j_to].Location.X && panels[i_from, j_from].Location.X + 50 < panels[i_to, j_to].Location.X)
                                        {
                                            if (panels[i_to + 1, j_to - 1].Tag != "Black" && panels[i_to + 1, j_to - 1].Tag != "white")
                                            {
                                                win_to = panels[i_to + 1, j_to - 1];
                                                drag = true;
                                            }
                                        }
                                        else
                                        {
                                            if (panels[i_to - 1, j_to - 1].Tag != "Black" && panels[i_to - 1, j_to - 1].Tag != "white")
                                            {
                                                win_to = panels[i_to - 1, j_to - 1];
                                                drag = true;
                                            }
                                        }
                                        Bp_ += 1;
                                        Bp.Text = Convert.ToString(Bp_);
                                    }
                                }
                                else if (panels[i_to, j_to].Tag == "black")
                                {
                                    drag = false;
                                }
                                else
                                {
                                    drag = true;
                                }

                            }
                        }
                    }


                }
                if(drag == true)
                {
                    string buffer = first;
                    Image img;

                    panels[i_from,j_from].Tag = " ";
                    if(win_to == to)
                    {                   
                        panels[i_to, j_to].Tag = buffer;
                        first = second;
                        second = buffer;
                        
                    }
                    else
                    {
                        panels[i_to, j_to].Tag = " ";
                        win_to.Tag = buffer;                      
                    }
                    if (first == "white")
                        img = Bitmap.FromFile(@"../../Resources/imgonline-com-ua-Transparent-backgr-be1xfHEFov6n2xDT.bmp");
                    else
                        img = Bitmap.FromFile(@"..\..\Resources\imgonline-com-ua-Transparent-backgr-dhVHs4mewy.bmp");

                    picture.BackgroundImage = img;
                }
           }
        }


        void TextBoxDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel53_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel62_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel63_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel55_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel47_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel50_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel58_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel64_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ви точно хочете закінчити свій хід?", "Закінчити Хід", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string buffer = first;
                first = second;
                second = buffer;
                Image img;

                if (first == "white")
                    img = Bitmap.FromFile(@"../../Resources/imgonline-com-ua-Transparent-backgr-be1xfHEFov6n2xDT.bmp");
                else
                    img = Bitmap.FromFile(@"..\..\Resources\imgonline-com-ua-Transparent-backgr-dhVHs4mewy.bmp");

                picture.BackgroundImage = img;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ви точно хочете здатися?", "Здатися", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Ви здалися!\nВиграв гравець фішок - " + second + "!", "End", MessageBoxButtons.OK);
                this.DestroyHandle();
            }
        }
    }
}
