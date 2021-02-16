using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPC_Encelad_s_Projects_Collection__1
{
    public partial class Form1 : Form
    {
        private Label title;
        private Label subtitle;
        private List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //====================================================
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(600, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //====================================================

            //====================================================
            this.title = new Label();
            this.title.Text = "Welcome to EPC!";
            this.title.Font = new Font("Arial", 14);
            this.title.Width = 200;
            this.title.Location = new Point(this.Width / 2 - this.title.Width/2, 20);

            this.subtitle = new Label();
            this.subtitle.Text = "Encelad`s Projects Collection";
            this.subtitle.Font = new Font("Arial", 8, FontStyle.Italic);
            this.subtitle.Width = 200;
            this.subtitle.Location = new Point(this.Width / 2 - this.subtitle.Width/2, 30+this.title.Height);

            this.Controls.AddRange(new[] { this.title, this.subtitle });
            //====================================================
            for (int i = 0; i < 8; i++)
            {
                Button button = new Button();
                button.Width = 200;
                button.Height = 25;
                button.Text = $"Appilication {i + 1}";
                button.Name = $"{i+1}";
                button.Click += Button_Click;
                if(buttons.Count == 0)
                {
                    button.Location = new Point(this.Width / 2 - button.Width/2-20, 60 + this.subtitle.Height);
                }
                else
                {
                    button.Location = new Point(this.Width / 2 - button.Width/2-20, buttons[i-1].Location.Y+50);
                }
                this.buttons.Add(button);
                this.Controls.Add(button);
            }
            //====================================================
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if((sender as Button).Name == "1")
            {

            }
            else if ((sender as Button).Name == "2")
            {

            }
            else if ((sender as Button).Name == "3")
            {

            }
            else if ((sender as Button).Name == "4")
            {

            }
            else if ((sender as Button).Name == "5")
            {

            }
            else if ((sender as Button).Name == "6")
            {

            }
            else if ((sender as Button).Name == "7")
            {

            }
            else if ((sender as Button).Name == "8")
            {

            }
        }
    }
}
