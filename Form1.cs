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
        //====================================================
        private Label title;
        private Label subtitle;
        private List<Button> buttons = new List<Button>();
        //====================================================

        //====================================================
        private int start_num = 1;
        private int end_num = 2000;
        private int num;
        //====================================================

        public Form1()
        {
            InitializeComponent();
        }

        private delegate void Application_Load(object sender, System.EventArgs e);
        private event Application_Load Application_Load_Event;

        private void Application_1(object sender, System.EventArgs e)
        {
            List<string> summary = new List<string>() { "Fullname: Gorbachev Kyrylo Denysovych", "Age: 16", "Programming experience: no experience", "Learning: C#,Python,Ethical hacking", "English level: A2-B1" };
            foreach (var item in summary)
            {
                MessageBox.Show(item, item.Split(':')[0],MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            Application_Load_Event = null;
            buttons.Clear();
            Form1_Load(sender, e);
        }

        private void Application_2(object sender, System.EventArgs e)
        {
            bool is_playing = true;
            while (is_playing)
            {
                System.Threading.Thread.Sleep(12);
                Random random = new Random();
                this.num = random.Next(start_num, end_num);
                DialogResult result = MessageBox.Show($"Your number is {num}?", "Is it your number?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"So ez.", "I WON!!!");
                    is_playing = false;
                }
                else if (result == DialogResult.No)
                {
                    DialogResult bigger_or_smaller = MessageBox.Show("Your number bigger thant my?", "Your number bigger thant my?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (bigger_or_smaller == DialogResult.Yes)
                    {
                        if (num < 2000)
                        {
                            this.start_num = this.num;
                        }
                        else
                        {
                            MessageBox.Show("It is lie!");
                            this.end_num = this.num;
                        }
                    }
                    else if (bigger_or_smaller == DialogResult.No)
                    {
                        if (num > 1)
                        {
                            this.end_num = this.num;
                        }
                        else
                        {
                            MessageBox.Show("It is lie!");
                            this.start_num = this.num;
                        }
                    }
                }
            }
            Application_Load_Event = null;
            buttons.Clear();
            Form1_Load(sender, e);
        }

        private void Application_3(object sender, System.EventArgs e)
        {
            this.Click += App3_Click;
            this.MouseMove += App3_MouseMove;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void App3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = this.Width + " " + this.Height + " " + MousePosition.ToString();
        }

        private void App3_Click(object sender, EventArgs e)
        {
            if ((e as MouseEventArgs).Button == MouseButtons.Left && ModifierKeys == Keys.Control)
            {
                this.Click -= App3_Click;
                this.MouseMove -= App3_MouseMove;
                Application_Load_Event = null;
                buttons.Clear();
                Form1_Load(sender, e);
            }
            else if ((e as MouseEventArgs).Button == MouseButtons.Left)
            {
                if (this.PointToClient(MousePosition).X > 10 && this.PointToClient(MousePosition).Y > 10 && this.PointToClient(MousePosition).X < this.Width - 10 && this.PointToClient(MousePosition).Y < this.Height - 10)
                {
                    MessageBox.Show("Point in square.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (this.PointToClient(MousePosition).X == 10 || this.PointToClient(MousePosition).Y == 10 || this.PointToClient(MousePosition).X == this.Width - 10 || this.PointToClient(MousePosition).Y == this.Height - 10)
                {
                    MessageBox.Show("Point on the edge of square.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Point out of square.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if ((e as MouseEventArgs).Button == MouseButtons.Right)
            {
                MessageBox.Show($"Size of Window: {this.Width},{this.Height};\n Cursor position: {MousePosition.X}, {MousePosition.Y}.", "Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            if(Application_Load_Event == null)
            {
                //====================================================
                this.Text = "EPC";
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
                this.title.Location = new Point(this.Width / 2 - this.title.Width / 2, 20);

                this.subtitle = new Label();
                this.subtitle.Text = "Encelad`s Projects Collection";
                this.subtitle.Font = new Font("Arial", 8, FontStyle.Italic);
                this.subtitle.Width = 200;
                this.subtitle.Location = new Point(this.Width / 2 - this.subtitle.Width / 2, 30 + this.title.Height);

                this.Controls.AddRange(new[] { this.title, this.subtitle });
                //====================================================
                for (int i = 0; i < 8; i++)
                {
                    Button button = new Button();
                    button.Width = 200;
                    button.Height = 25;
                    button.Text = $"Application {i + 1}";
                    button.Name = $"{i + 1}";
                    button.Click += Button_Click;
                    if (buttons.Count == 0)
                    {
                        button.Location = new Point(this.Width / 2 - button.Width / 2 - 20, 60 + this.subtitle.Height);
                    }
                    else
                    {
                        button.Location = new Point(this.Width / 2 - button.Width / 2 - 20, buttons[i - 1].Location.Y + 50);
                    }
                    this.buttons.Add(button);
                    this.Controls.Add(button);
                }
                //====================================================
            }
            else
            {
                this.Controls.Clear();
                Application_Load_Event(sender,e);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if((sender as Button).Name == "1")
            {
                Application_Load_Event += Application_1;
                Form1_Load(sender,e);
            }
            else if ((sender as Button).Name == "2")
            {
                Application_Load_Event += Application_2;
                Form1_Load(sender, e);
            }
            else if ((sender as Button).Name == "3")
            {
                Application_Load_Event += Application_3;
                Form1_Load(sender, e);
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
