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

        //====================================================
        public List<Form> forms = new List<Form>();
        public int form_num = 0;
        Point relativePoint;
        //====================================================

        //====================================================
        public Form runningForm;
        //====================================================

        //====================================================
        private TextBox box = new TextBox();
        //====================================================

        public Form1()
        {
            InitializeComponent();
        }

        //====================================================

        private delegate void Application_Load(object sender, System.EventArgs e);
        private event Application_Load Application_Load_Event;

        //====================================================

        //===============================================================X
        #region Application 1
        private void Application_1(object sender, System.EventArgs e)
        {
            List<string> summary = new List<string>() { "Fullname: Gorbachev Kyrylo Denysovych", "Age: 16", "Programming experience: no experience", "Learning: C#,Python,Ethical hacking", "English level: A2-B1" };
            double char_quanity = 0;
            foreach (var item in summary)
            {
                char_quanity += item.Length;
                if(summary.IndexOf(item) != summary.Count - 1)
                {
                    MessageBox.Show(item, item.Split(':')[0], MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(item, (char_quanity / summary.Count).ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Application_Load_Event = null;
            buttons.Clear();
            Form1_Load(sender, e);
        }
        #endregion
        //===============================================================X
        #region Application 2
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
        #endregion
        //===============================================================X
        #region Application 3
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
        #endregion
        //===============================================================X
        #region Application 4
        struct Coord
        {
            public int X_Start;
            public int Y_Start;

            public int X_End;
            public int Y_End;
        }
        Coord coord = new Coord();
        private void Application_4(object sender, System.EventArgs e)
        {
            this.MouseDown += App4_MouseDown;
            this.MouseUp += App4_MouseUp;
        }

        public void App4_MouseDown(object sender, MouseEventArgs argv)
        {
            if (argv.Button == MouseButtons.Left)
            {
                relativePoint = this.PointToClient(Cursor.Position);

                coord.X_Start = relativePoint.X;
                coord.Y_Start = relativePoint.Y;

                this.Text = $"X = {coord.X_Start}, Y = {coord.Y_Start}";
            }
        }

        public void App4_MouseUp(object sender, MouseEventArgs argv)
        {
            if (argv.Button == MouseButtons.Left && ModifierKeys == Keys.Control)
            {
                this.MouseClick -= App4_MouseClick;
                this.MouseDoubleClick -= App4_MouseDoubleClick;
                this.MouseDown -= App4_MouseDown;
                Application_Load_Event = null;
                buttons.Clear();
                Form1_Load(sender, argv as EventArgs);
            }
            else if (argv.Button == MouseButtons.Left)
            {
                relativePoint = this.PointToClient(Cursor.Position);

                coord.X_End = relativePoint.X;
                coord.Y_End = relativePoint.Y;

                this.Text = $"X = {coord.X_End}, Y = {coord.Y_End}";

                if (coord.X_Start > coord.X_End)
                {
                    coord.X_End = coord.X_End + coord.X_Start - (coord.X_Start = coord.X_End);
                }

                if (coord.Y_Start > coord.Y_End)
                {
                    coord.Y_End = coord.Y_End + coord.Y_Start - (coord.Y_Start = coord.Y_End);
                }

                if (coord.X_End - coord.X_Start >= 10 && coord.Y_End - coord.Y_Start >= 10)
                {
                    forms.Add(new Form());
                    forms[form_num].StartPosition = FormStartPosition.Manual;
                    forms[form_num].BringToFront();
                    forms[form_num].Location = new Point(coord.X_Start + this.Location.X, coord.Y_Start + this.Location.Y);

                    forms[form_num].Size = new Size(coord.X_End - coord.X_Start, coord.Y_End - coord.Y_Start);

                    forms[form_num].FormBorderStyle = FormBorderStyle.FixedDialog;

                    forms[form_num].Show();
                    forms[form_num].MouseClick += App4_MouseClick;
                    forms[form_num].MouseDoubleClick += App4_MouseDoubleClick;
                    forms[form_num++].Text = form_num.ToString();

                    this.Text = form_num.ToString();
                }
                else
                {
                    MessageBox.Show("Статик не может быть меньше 10х10 пикселей!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void App4_MouseDoubleClick(object sender, MouseEventArgs argv)
        {
            if (argv.Button == MouseButtons.Left)
            {
                (sender as Form).Dispose();
            }
        }

        public void App4_MouseClick(object sender, MouseEventArgs argv)
        {
            if (argv.Button == MouseButtons.Right)
            {
                relativePoint = this.PointToClient((sender as Form).Location);

                (sender as Form).Text = $"X = {relativePoint.X}, Y = {relativePoint.Y}, Width = {(sender as Form).Size.Width}, Height = {(sender as Form).Size.Height}";
            }
        }
        #endregion
        //===============================================================X
        #region Application 5

        private void Application_5(object sender, System.EventArgs e)
        {
            this.Click += App5_Click;
            runningForm = new Form();
            runningForm.Location = new Point(this.Location.X + this.ClientSize.Width / 2, this.Location.Y + this.ClientSize.Height / 2);
            runningForm.BackColor = Color.MediumVioletRed;
            runningForm.FormBorderStyle = FormBorderStyle.None;
            runningForm.ClientSize = new Size(60, 50);

            runningForm.MouseMove += App5_Mouse_Move;
            runningForm.Show();
        }

        public void App5_Mouse_Move(object obj, EventArgs argv)
        {
            Point relativePoint = runningForm.PointToClient(Cursor.Position);
            Point windowPoint = this.PointToClient(runningForm.Location);
            if (relativePoint.X <= runningForm.Width / 2 && windowPoint.X <= this.ClientSize.Width - runningForm.Size.Width)
                runningForm.Location = new Point(runningForm.Location.X + 1, runningForm.Location.Y);
            else if (relativePoint.X > runningForm.Width / 2 && windowPoint.X > 0)
                runningForm.Location = new Point(runningForm.Location.X - 1, runningForm.Location.Y);

            if (relativePoint.Y <= runningForm.Height / 2 && windowPoint.Y <= this.ClientSize.Height - runningForm.Size.Height)
                runningForm.Location = new Point(runningForm.Location.X, runningForm.Location.Y + 1);
            else if (relativePoint.Y > runningForm.Height / 2 && windowPoint.Y > 0)
                runningForm.Location = new Point(runningForm.Location.X, runningForm.Location.Y - 1);
        }

        private void App5_Click(object sender, EventArgs e)
        {
            if ((e as MouseEventArgs).Button == MouseButtons.Left && ModifierKeys == Keys.Control)
            {
                this.Click -= App5_Click;
                runningForm.MouseMove -= App5_Mouse_Move;
                runningForm.Dispose();
                Application_Load_Event = null;
                buttons.Clear();
                Form1_Load(sender, e);
            }
        }
        #endregion
        //===============================================================X
        #region Application 6
        private void Application_6(object sender, System.EventArgs e)
        {
            this.box.Multiline = true;
            this.box.Size = this.Size;
            this.box.KeyDown += Box_KeyDown;
            this.Controls.Add(this.box);
            this.Click += App6_Click;
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DateTime dt;
                if (DateTime.TryParse((sender as TextBox).Text, out dt))
                {
                    switch (dt.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            {
                                MessageBox.Show($"День недели - понедельник.");
                                break;
                            }
                        case DayOfWeek.Tuesday:
                            {
                                MessageBox.Show($"День недели - вторник.");
                                break;
                            }
                        case DayOfWeek.Wednesday:
                            {
                                MessageBox.Show($"День недели - среда.");
                                break;
                            }
                        case DayOfWeek.Thursday:
                            {
                                MessageBox.Show($"День недели - четверг.");
                                break;
                            }
                        case DayOfWeek.Friday:
                            {
                                MessageBox.Show($"День недели - пятница.");
                                break;
                            }
                        case DayOfWeek.Saturday:
                            {
                                MessageBox.Show($"День недели - суббота.");
                                break;
                            }
                        case DayOfWeek.Sunday:
                            {
                                MessageBox.Show($"День недели - воскресенье.");
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show($"Некорректная дата!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void App6_Click(object sender, EventArgs e)
        {
            if ((e as MouseEventArgs).Button == MouseButtons.Left && ModifierKeys == Keys.Control)
            {
                this.Click -= App3_Click;
                this.MouseMove -= App3_MouseMove;
                Application_Load_Event = null;
                buttons.Clear();
                Form1_Load(sender, e);
            }
        }

        #endregion
        //===============================================================X
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
                Application_Load_Event += Application_4;
                Form1_Load(sender, e);
            }
            else if ((sender as Button).Name == "5")
            {
                Application_Load_Event += Application_5;
                Form1_Load(sender, e);
            }
            else if ((sender as Button).Name == "6")
            {
                Application_Load_Event += Application_6;
                Form1_Load(sender, e);
            }
            else if ((sender as Button).Name == "7")
            {

            }
            else if ((sender as Button).Name == "8")
            {

            }
        }

        //===============================================================X
    }
}
