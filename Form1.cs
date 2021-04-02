using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        //====================================================
        List<RadioButton> radio = new List<RadioButton>();
        Label label;
        TextBox textbox;
        //====================================================
        #region Первая группа элементов - "Автозаправка"
        GroupBox group_station;
        ComboBox station_combo_fuel;
        Label station_label_fuel_text;
        Label station_label_fuelprice;
        Label station_label_fuelprice_text;

        Panel station_panel_radio;
        RadioButton station_radio_amount;
        RadioButton station_radio_sum;

        TextBox station_textbox_amount;
        Label station_label_amount_text;
        TextBox station_textbox_sum;
        Label station_label_sum_text;

        GroupBox station_group_payment;
        Label station_label_payment;
        Label station_label_payment_text;
        #endregion

        #region Вторая группа элементов - "Кафе"
        GroupBox group_cafe;

        List<CheckBox> cafe_check_food = new List<CheckBox>(new CheckBox[4] { new CheckBox(), new CheckBox(), new CheckBox(), new CheckBox() });

        List<TextBox> cafe_textbox_price = new List<TextBox>(new TextBox[4] { new TextBox(), new TextBox(), new TextBox(), new TextBox() });
        Label cafe_label_price_text;

        List<TextBox> cafe_textbox_amount = new List<TextBox>(new TextBox[4] { new TextBox(), new TextBox(), new TextBox(), new TextBox() });
        Label cafe_label_amount_text;

        GroupBox cafe_group_payment;
        Label cafe_label_payment;
        Label cafe_label_payment_text;
        #endregion

        #region Третья группа элементов - "Оплата"
        GroupBox group_pay;

        PictureBox pay_picture;

        Button pay_button;

        Label pay_label_payment;
        Label pay_label_payment_text;
        #endregion

        double total_sum = 0;
        System.Windows.Forms.Timer timer;
        public struct Loc
        {
            public int X;
            public int Y;
        }
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
                if (summary.IndexOf(item) != summary.Count - 1)
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
                MessageBox.Show($"Size of Window: {this.Width},{this.Height};\n Cursor position: {MousePosition.X}, {MousePosition.Y}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #region Application 7
        struct RadioLoc
        {
            public int pos_X;
            public int pos_Y;
        }

        public void Application_7(object sender, EventArgs argv)
        {
            this.Click += App7_Click;
            for (int i = 0; i < 5; i++)
            {
                radio.Add(new RadioButton());
            }

            radio[0].Text = "Годы";
            radio[0].Checked = true;
            radio[1].Text = "Месяцы";
            radio[2].Text = "Дни";
            radio[3].Text = "Минуты";
            radio[4].Text = "Секунды";


            RadioLoc loc;
            loc.pos_X = this.ClientSize.Width / 16;
            loc.pos_Y = 0;


            foreach (var item in radio)
            {
                item.Location = new Point(loc.pos_X, loc.pos_Y += 30);
            }

            textbox = new TextBox();
            textbox.Location = new Point(this.ClientSize.Width / 3, loc.pos_Y);

            textbox.KeyDown += App7_Textbox_KeyDown;

            label = new Label();
            label.Text = "ГГГГ-ММ-ДД";
            label.BackColor = Color.ForestGreen;
            label.Location = new Point(textbox.Location.X, textbox.Location.Y - label.Size.Height - 5);

            radio.ForEach(i => this.Controls.Add(i));
            this.Controls.Add(textbox);
            this.Controls.Add(label);
        }

        public void App7_Textbox_KeyDown(object sender, KeyEventArgs e)
        {
            DateTime dt;
            if (e.KeyCode == Keys.Enter)
            {
                if (DateTime.TryParse((sender as TextBox).Text, out dt))
                {
                    string text = (from i in radio where i.Checked == true select i.Text).FirstOrDefault();
                    switch (text)
                    {
                        //Math.Abs() - это модуль. Он нужен, если будет введена дата, предшествующая текущей. В таком случае DateTime.Subtract возвращает отрицательное число, где и нужен модуль.
                        //В первых двух случаях нужно объявлять переменную, хранящую дни, ведь DateTime не предусматривает подсчёт в месяцах или годах.
                        case "Годы":
                            {
                                int days = dt.Subtract(DateTime.Now).Days;
                                MessageBox.Show($"Разница - {Math.Abs(days / 365.0)} лет.");

                                break;
                            }
                        case "Месяцы":
                            {
                                int days = dt.Subtract(DateTime.Now).Days;
                                MessageBox.Show($"Разница - {Math.Abs(days / 30.0)} месяцев.");

                                break;
                            }
                        case "Дни":
                            {
                                MessageBox.Show($"Разница - {(int)Math.Abs(dt.Subtract(DateTime.Now).TotalDays)} дней.");

                                break;
                            }
                        case "Минуты":
                            {
                                MessageBox.Show($"Разница - {(int)Math.Abs(dt.Subtract(DateTime.Now).TotalMinutes)} минут.");

                                break;
                            }
                        case "Секунды":
                            {
                                MessageBox.Show($"Разница - {(int)Math.Abs(dt.Subtract(DateTime.Now).TotalSeconds)} секунд.");

                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Некорректный ввод!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void App7_Click(object sender, EventArgs e)
        {
            if ((e as MouseEventArgs).Button == MouseButtons.Left && ModifierKeys == Keys.Control)
            {
                this.Click -= App7_Click;
                Application_Load_Event = null;
                buttons.Clear();
                Form1_Load(sender, e);
            }
        }
        #endregion
        //===============================================================X
        #region Application 8

        public void FirstGroup_Init()
        {
            #region Работа с элементами первой группы
            station_group_payment.Controls.AddRange(new Control[] {station_label_payment,
                                                                   station_label_payment_text});
            station_panel_radio.Controls.AddRange(new Control[] {station_radio_amount,
                                                                 station_radio_sum});
            group_station.Controls.AddRange(new Control[] {station_group_payment,
                                                           station_panel_radio});

            group_station.Controls.AddRange(new Control[] {station_combo_fuel,
                                                           station_label_fuel_text,
                                                           station_label_fuelprice,
                                                           station_label_fuelprice_text,
                                                           station_textbox_amount,
                                                           station_textbox_sum});

            group_station.Size = new Size(250, 300);
            group_station.Location = new Point(20, 20);
            group_station.Text = "Автозаправка";

            station_group_payment.Location = new Point(5, group_station.Size.Height - station_group_payment.Size.Height - 5);
            station_group_payment.Size = new Size(group_station.Size.Width - 10, station_group_payment.Height);
            station_group_payment.Text = "К оплате";

            station_combo_fuel.Location = new Point(80, 20);
            station_combo_fuel.Items.AddRange(new string[] { "A-95", "A-92", "Дизель" });
            station_combo_fuel.SelectedIndexChanged += Combo_SelectedIndexChanged;
            station_combo_fuel.SelectedIndex = 0;

            station_label_fuel_text.Location = new Point(10, 20);
            station_label_fuel_text.Text = "Бензин";

            station_label_fuelprice.Location = new Point(80, 60);
            station_label_fuelprice.Size = station_combo_fuel.Size;

            station_label_fuelprice_text.Location = new Point(10, 60);
            station_label_fuelprice_text.Text = "Цена (грн)";

            station_panel_radio.Location = new Point(10, group_station.Size.Height / 2 - 50);
            station_panel_radio.Size = new Size(group_station.Size.Width / 2 - 20, 80);
            station_panel_radio.BorderStyle = BorderStyle.Fixed3D;

            station_radio_amount.Location = new Point(5, station_panel_radio.Size.Height / 8);
            station_radio_amount.Text = "Количество (л)";
            station_radio_amount.Tag = 0;
            station_radio_amount.Checked = true;
            station_radio_amount.CheckedChanged += Radio_CheckedChanged;

            station_textbox_amount.Location = new Point(station_radio_amount.Location.X + station_textbox_amount.Size.Width + 30, 110);
            station_textbox_amount.Tag = 0;
            station_textbox_amount.Name = "0";
            station_textbox_amount.TextChanged += Station_TextBox_TextChanged;
            station_textbox_amount.EnabledChanged += Station_TextBox_EnabledChanged;
            station_textbox_amount.Text = "0";

            station_radio_sum.Location = new Point(5, station_panel_radio.Size.Height - station_panel_radio.Size.Height / 8 - station_radio_sum.Size.Height);
            station_radio_sum.Text = "Сумма (грн.)";
            station_radio_sum.Tag = 1;

            station_textbox_sum.Location = new Point(station_radio_sum.Location.X + station_textbox_sum.Size.Width + 30, 150);
            station_textbox_sum.Enabled = false;
            station_textbox_sum.Tag = 1;
            station_textbox_sum.Name = "0";
            station_textbox_sum.TextChanged += Station_TextBox_TextChanged;
            station_textbox_sum.TextChanged += Station_TextBox_EnabledChanged;
            station_textbox_sum.Text = "0";

            station_label_payment.Location = new Point(20, 20);
            station_label_payment.Size = new Size(station_group_payment.Size.Width - 60, station_group_payment.Size.Height - 40);
            station_label_payment.Font = new Font(FontFamily.GenericSansSerif, 30);
            station_label_payment.TextAlign = ContentAlignment.MiddleRight;
            station_label_payment.Text = "0,00";

            station_label_payment_text.Size = new Size(30, 20);
            station_label_payment_text.Location = new Point(station_label_payment.Size.Width + 20, station_label_payment.Location.Y);
            station_label_payment_text.Text = "грн.";

            this.Controls.Add(group_station);
            #endregion
        }

        public void SecondGroup_Init()
        {
            #region Работа с элементами второй группы
            cafe_group_payment.Controls.AddRange(new Control[] {cafe_label_payment,
                                                                cafe_label_payment_text});
            group_cafe.Controls.Add(cafe_group_payment);

            cafe_check_food.ForEach(i => group_cafe.Controls.Add(i));

            cafe_textbox_price.ForEach(i => group_cafe.Controls.Add(i));
            cafe_textbox_amount.ForEach(i => group_cafe.Controls.Add(i));
            group_cafe.Controls.AddRange(new Control[] {cafe_label_price_text,
                                                        cafe_label_amount_text});

            group_cafe.Size = new Size(250, 300);
            group_cafe.Location = new Point(this.ClientSize.Width - group_cafe.Size.Width - 20, 20);
            group_cafe.Text = "Мини-Кафе";

            cafe_group_payment.Location = new Point(5, group_cafe.Size.Height - cafe_group_payment.Size.Height - 5);
            cafe_group_payment.Size = new Size(group_cafe.Size.Width - 10, cafe_group_payment.Height);
            cafe_group_payment.Text = "К оплате";

            cafe_label_payment.Location = new Point(20, 20);
            cafe_label_payment.Size = new Size(cafe_group_payment.Size.Width - 60, cafe_group_payment.Size.Height - 40);
            cafe_label_payment.Font = new Font(FontFamily.GenericSansSerif, 30);
            cafe_label_payment.TextAlign = ContentAlignment.MiddleRight;
            cafe_label_payment.Text = "0,00";

            cafe_label_payment_text.Size = new Size(30, 20);
            cafe_label_payment_text.Location = new Point(cafe_label_payment.Size.Width + 20, cafe_label_payment.Location.Y);
            cafe_label_payment_text.Text = "грн.";

            Loc loc;
            loc.X = 5;
            loc.Y = 30;

            cafe_check_food[0].Text = "Хот-дог";
            cafe_check_food[1].Text = "Гамбургер";
            cafe_check_food[2].Text = "Картошка-фри";
            cafe_check_food[3].Text = "Кока-кола";

            cafe_check_food.ForEach(i => i.Location = new Point(loc.X, loc.Y += 30));
            cafe_check_food.ForEach(i => i.CheckedChanged += CheckBox_CheckedChanged);

            cafe_check_food[0].Tag = 0;
            cafe_check_food[1].Tag = 1;
            cafe_check_food[2].Tag = 2;
            cafe_check_food[3].Tag = 3;

            loc.X = group_cafe.Size.Width / 2;
            loc.Y = 30;

            cafe_textbox_price.ForEach(i => i.Location = new Point(loc.X, loc.Y += 30));
            cafe_textbox_price.ForEach(i => i.Size = new Size(50, i.Size.Height));
            cafe_textbox_price.ForEach(i => i.Enabled = false);
            cafe_textbox_price[0].Text = "4,00";
            cafe_textbox_price[1].Text = "5,40";
            cafe_textbox_price[2].Text = "7,20";
            cafe_textbox_price[3].Text = "4,40";

            cafe_label_price_text.Location = new Point(cafe_textbox_price[0].Location.X, cafe_textbox_price[0].Location.Y - 30);
            cafe_label_price_text.Text = "Цена";
            cafe_label_price_text.Size = new Size(40, cafe_label_price_text.Size.Height);

            loc.X = group_cafe.Size.Width / 2 + cafe_textbox_price[0].Size.Width + 10;
            loc.Y = 30;

            cafe_textbox_amount.ForEach(i => i.Location = new Point(loc.X, loc.Y += 30));
            cafe_textbox_amount.ForEach(i => i.Size = new Size(50, i.Size.Height));
            cafe_textbox_amount.ForEach(i => i.Text = "0");
            cafe_textbox_amount.ForEach(i => i.Enabled = false);
            cafe_textbox_amount.ForEach(i => i.TextChanged += Cafe_TextBox_TextChanged);
            cafe_textbox_amount.ForEach(i => i.EnabledChanged += Cafe_TextBox_EnabledChanged);
            cafe_textbox_amount.ForEach(i => i.Name = "0");

            cafe_textbox_amount[0].Tag = 0;
            cafe_textbox_amount[1].Tag = 1;
            cafe_textbox_amount[2].Tag = 2;
            cafe_textbox_amount[3].Tag = 3;

            cafe_label_amount_text.Location = new Point(cafe_textbox_amount[0].Location.X, cafe_textbox_amount[0].Location.Y - 30);
            cafe_label_amount_text.Text = "Кол.";
            cafe_label_amount_text.Size = new Size(40, cafe_label_amount_text.Size.Height);

            this.Controls.Add(group_cafe);

            #endregion
        }

        public void ThirdGroup_Init()
        {
            #region Работа с элементами третьей группы
            group_pay.Controls.AddRange(new Control[] {pay_picture,
                                                       pay_button,
                                                       pay_label_payment,
                                                       pay_label_payment_text});

            group_pay.Size = new Size(this.ClientSize.Width - 40, 90);
            group_pay.Location = new Point(group_station.Location.X, group_station.Location.Y + group_station.Size.Height + 20);
            group_pay.Text = "Всего к оплате";

            pay_picture.Image = Image.FromFile(@"C:\Users\Илья\source\repos\WinForms_Homework\(8)BestOil\dollar.png");
            pay_picture.SizeMode = PictureBoxSizeMode.StretchImage;
            pay_picture.Size = new Size(40, 40);
            pay_picture.Location = new Point(20, 20);

            pay_button.Size = new Size(100, 50);
            pay_button.Text = "Рассчитать";
            pay_button.Location = new Point(150, 20);
            Thread.Sleep(2000);
            pay_button.Click += App8_Button_Click;

            pay_label_payment.Size = new Size(180, 60);
            pay_label_payment.Location = new Point(group_pay.Size.Width - pay_label_payment.Size.Width - 50, 20);
            pay_label_payment.Font = new Font(FontFamily.GenericSansSerif, 30);
            pay_label_payment.TextAlign = ContentAlignment.MiddleRight;
            pay_label_payment.Text = "0,00";

            pay_label_payment_text.Size = new Size(30, 20);
            pay_label_payment_text.Location = new Point(group_pay.Size.Width - 50, 20);
            pay_label_payment_text.Text = "грн.";

            this.Controls.Add(group_pay);
            #endregion
        }

        public void Application_8(object sender, EventArgs argv)
        {
            #region Инициализация элементов первой группы
            group_station = new GroupBox();
            station_combo_fuel = new ComboBox();
            station_label_fuel_text = new Label();
            station_label_fuelprice = new Label();
            station_label_fuelprice_text = new Label();

            station_panel_radio = new Panel();
            station_radio_amount = new RadioButton();
            station_radio_sum = new RadioButton();

            station_textbox_amount = new TextBox();
            station_label_amount_text = new Label();
            station_textbox_sum = new TextBox();
            station_label_sum_text = new Label();

            station_group_payment = new GroupBox();
            station_label_payment = new Label();
            station_label_payment_text = new Label();
            #endregion

            #region Инициализация элементов второй группы
            group_cafe = new GroupBox();

            //cafe_check_food.ForEach(i => i = new CheckBox());

            //cafe_textbox_price.ForEach(i => i = new TextBox());
            cafe_label_price_text = new Label();

            //cafe_textbox_amount.ForEach(i => i = new TextBox());
            cafe_label_amount_text = new Label();

            cafe_group_payment = new GroupBox();
            cafe_label_payment = new Label();
            cafe_label_payment_text = new Label();
            #endregion

            #region Инициализация элементов третьей группы
            group_pay = new GroupBox();

            pay_picture = new PictureBox();

            pay_button = new Button();

            pay_label_payment = new Label();
            pay_label_payment_text = new Label();
            #endregion

            FirstGroup_Init();
            SecondGroup_Init();
            ThirdGroup_Init();

            //Выделение памяти таймеру, установка интервала(10 сек) для возврата формы в изначальное положение и подписка на событие
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            //Остановка таймера
            timer.Stop();

            //Если пользователь отказался вернуть форму в изначальное положение, то через 10 секунд программа предложит ему вернуть форму ещё раз
            if (MessageBox.Show("Вернуть форму в изначальное положение?", "Приложение", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                timer.Enabled = true;
            }
            else
            {
                //Вызывается метод для возврата элементов формы в изначальное значение
                Init();
            }
        }

        //Метод для возврата элементов формы к изначальным значениям
        public void Init()
        {
            station_combo_fuel.SelectedIndex = 0;
            station_label_payment.Text = "0,00";
            cafe_textbox_amount.ForEach(i => i.Text = "0");
            cafe_check_food.ForEach(i => i.Checked = false);
            cafe_label_payment.Text = "0,00";
            pay_label_payment.Text = "0,00";
            station_textbox_sum.Text = "0";
            station_textbox_amount.Text = "0";
            station_label_payment.Text = "0,00";
        }

        //Событие при закрытии формы
        public void Form_Closing(object sender, FormClosingEventArgs argv)
        {
            //При закрытии формы выводится сообщение с дневной выручкой
            MessageBox.Show($"Дневная выручка за сегодня: {total_sum} грн.", "Закрытие", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Событие изменения состояния чекбокса
        public void CheckBox_CheckedChanged(object sender, EventArgs argv)
        {
            //if ((sender as CheckBox).Text == "Хот-дог" && cafe_textbox_amount[0].Enabled == false)
            //{
            //    cafe_textbox_amount[0].Enabled = true;
            //}
            //else if ((sender as CheckBox).Text == "Хот-дог") 
            //{
            //    cafe_textbox_amount[0].Enabled = false;
            //}

            //if ((sender as CheckBox).Text == "Гамбургер" && cafe_textbox_amount[1].Enabled == false)
            //{
            //    cafe_textbox_amount[1].Enabled = true;
            //}
            //else if ((sender as CheckBox).Text == "Гамбургер")
            //{
            //    cafe_textbox_amount[1].Enabled = false;
            //}

            //if ((sender as CheckBox).Text == "Картошка-фри" && cafe_textbox_amount[2].Enabled == false)
            //{
            //    cafe_textbox_amount[2].Enabled = true;
            //}
            //else if ((sender as CheckBox).Text == "Картошка-фри")
            //{
            //    cafe_textbox_amount[2].Enabled = false;
            //}

            //if ((sender as CheckBox).Text == "Кока-кола" && cafe_textbox_amount[3].Enabled == false)
            //{
            //    cafe_textbox_amount[3].Enabled = true;
            //}
            //else if ((sender as CheckBox).Text == "Кока-кола")
            //{
            //    cafe_textbox_amount[3].Enabled = false;
            //}

            //Списки текстбоксов и чекбоксов имеют в тегах свой индекс списка, что позволяет им взаимодействовать друг с другом.
            //Если текстбокс, тег которого совпадает с соответствующим ему чекбоксом, выключен, то текстбокс включается.
            if (cafe_textbox_amount[(int)(sender as CheckBox).Tag].Enabled == false)
            {
                cafe_textbox_amount[(int)(sender as CheckBox).Tag].Enabled = true;
            }
            else
            {
                cafe_textbox_amount[(int)(sender as CheckBox).Tag].Enabled = false;
            }
        }

        //Событие изменения текста в текстбоксах группы кафе
        public void Cafe_TextBox_TextChanged(object sender, EventArgs argv)
        {
            //Переменная для хранения значения денег с лейбла оплаты кафе
            double result = double.Parse(cafe_label_payment.Text);

            //Если текстбокс вклюён
            if ((sender as TextBox).Enabled == true)
            {
                //Блок try catch для предотвращения исключения при неудачном парсе
                try
                {
                    //В имени текстбокса хранится предыдущее значение, которое было там написано. Сделано это для того, чтобы можно было
                    //корректно взаимодействовать с лейблом оплаты (отнимать, к примеру)

                    //При изменении текста от результата отнимается его предыдущее значение
                    //Цена предмета берётся с неизменяемого текстбокса с совпадающим тегом (тег - индекс массива)
                    result -= double.Parse((sender as TextBox).Name) * double.Parse(cafe_textbox_price[(int)(sender as TextBox).Tag].Text);
                    //и прибавляется текущее
                    result += double.Parse((sender as TextBox).Text) * double.Parse(cafe_textbox_price[(int)(sender as TextBox).Tag].Text);

                    (sender as TextBox).Name = (sender as TextBox).Text;
                }
                catch (System.FormatException e)
                {
                    //Если парс не удался, то имя устанавливается нулём. Позволяет не уходить в отрицательную цену
                    (sender as TextBox).Name = "0";
                }

                //После всех операций новая цена записывается в лейбл оплаты
                cafe_label_payment.Text = result.ToString();
            }
        }

        //Событие изменения включённости текстбокса
        public void Cafe_TextBox_EnabledChanged(object sender, EventArgs argv)
        {
            double result = double.Parse(cafe_label_payment.Text);

            //Если текстбокс был выключен (достигается посредством откликивания соответсвующего чекбокса), то его значение отнимается от 
            //общей цены и наоборот.
            try
            {
                if ((sender as TextBox).Enabled == false)
                {
                    result -= double.Parse((sender as TextBox).Text) * double.Parse(cafe_textbox_price[(int)(sender as TextBox).Tag].Text);
                }
                else if ((sender as TextBox).Enabled == true)
                {
                    result += double.Parse((sender as TextBox).Text) * double.Parse(cafe_textbox_price[(int)(sender as TextBox).Tag].Text);
                }

                cafe_label_payment.Text = result.ToString();
            }
            catch (System.FormatException e)
            {
                (sender as TextBox).Text = "0";
            }
        }

        //Событие изменения типа топлива в комбобоксе
        public void Combo_SelectedIndexChanged(object sender, EventArgs argv)
        {
            //Все значения с текстбоксов заправки для удобства обнуляются
            station_textbox_sum.Text = "0";
            station_textbox_amount.Text = "0";
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    {
                        station_label_fuelprice.Text = "28,22";
                        break;
                    }
                case 1:
                    {
                        station_label_fuelprice.Text = "27,21";
                        break;
                    }
                case 2:
                    {
                        station_label_fuelprice.Text = "27,63";
                        break;
                    }
            }
        }

        //Событие изменения выбора радиокнопки
        public void Radio_CheckedChanged(object sender, EventArgs argv)
        {
            //Поскольку кнопок только две, то условия можно строить с учётом только одной кнопки.
            //Если первая кнопка отжата, это значит, что покупатель будет заправляться по деньгам, а не по литрам.
            //Соответствующие текстбоксы будут выключаться и включаться.
            if ((int)(sender as RadioButton).Tag == 0 && (sender as RadioButton).Checked == false)
            {
                station_group_payment.Text = "К выдаче";
                station_label_payment_text.Text = "л.";

                station_textbox_amount.Enabled = false;
                station_textbox_sum.Enabled = true;
            }
            else if ((int)(sender as RadioButton).Tag == 0 && (sender as RadioButton).Checked == true)
            {
                station_group_payment.Text = "К оплате";
                station_label_payment_text.Text = "грн.";

                station_textbox_amount.Enabled = true;
                station_textbox_sum.Enabled = false;
            }
        }

        //Событие изменения текста текстбоксов группы заправки
        public void Station_TextBox_TextChanged(object sender, EventArgs argv)
        {
            //Используется тип данных decimal вместо double, потому что это - 
            //0,3... - 0,3... = -2,...
            //double result = double.Parse(station_label_payment.Text);
            decimal result = decimal.Parse(station_label_payment.Text);

            //Первый текстбокс отвечает за количество топлива в литрах, второй - за литры в деньгах.
            if ((int)(sender as TextBox).Tag == 0)
            {
                try
                {
                    result -= decimal.Parse((sender as TextBox).Name) * decimal.Parse(station_label_fuelprice.Text);
                    result += decimal.Parse((sender as TextBox).Text) * decimal.Parse(station_label_fuelprice.Text);

                    (sender as TextBox).Name = (sender as TextBox).Text;
                }
                catch (System.FormatException e)
                {
                    (sender as TextBox).Name = "0";
                }
            }
            else if ((int)(sender as TextBox).Tag == 1)
            {
                try
                {
                    result -= decimal.Parse((sender as TextBox).Name) / decimal.Parse(station_label_fuelprice.Text);
                    result += decimal.Parse((sender as TextBox).Text) / decimal.Parse(station_label_fuelprice.Text);

                    (sender as TextBox).Name = (sender as TextBox).Text;
                }
                catch (System.FormatException e)
                {
                    (sender as TextBox).Name = "0";
                }
            }
            station_label_payment.Text = result.ToString();
        }

        //Событие изменения включённости текстбокса группы заправки
        public void Station_TextBox_EnabledChanged(object sender, EventArgs argv)
        {
            double result = double.Parse(station_label_payment.Text);

            //В зависимости от состояния первого текстбокса обнуляются два текстбокса заправки для удобства
            if ((int)(sender as TextBox).Tag == 0)
            {
                if ((sender as TextBox).Enabled == false)
                {
                    station_textbox_amount.Text = "0";
                }
                else if ((sender as TextBox).Enabled == true)
                {
                    station_textbox_sum.Text = "0";
                }

                result = 0;
                station_label_payment.Text = result.ToString();
            }
        }

        //Событие клика по кнопке расчёта
        public void App8_Button_Click(object sender, EventArgs argv)
        {
            //Если текстбокс для оплаты топлива по литрам включён, то
            if (station_textbox_amount.Enabled == true)
            {
                //сумму можно посчитать с лейблов оплаты кафе и заправки.
                pay_label_payment.Text = (double.Parse(station_label_payment.Text) + double.Parse(cafe_label_payment.Text)).ToString();
            }
            else
            {
                //сумму нужно считать с текстбокса суммы заправки (потому что лейбл оплаты заправки сейчас отображает литры) и лейбла оплаты кафе.
                pay_label_payment.Text = (double.Parse(station_textbox_sum.Text) + double.Parse(cafe_label_payment.Text)).ToString();
            }

            //Сумма дневной выручки увеличивается
            total_sum += double.Parse(pay_label_payment.Text);

            //Запускается таймер (для предложения вернуть форму в изначальное положение)
            timer.Start();
        }

        #endregion
        //===============================================================X
        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (Application_Load_Event == null)
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
                    button.Click += App8_Button_Click;
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
                Application_Load_Event(sender, e);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name == "1")
            {
                Application_Load_Event += Application_1;
                Form1_Load(sender, e);
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
                Application_Load_Event += Application_7;
                Form1_Load(sender, e);
            }
            else if ((sender as Button).Name == "8")
            {
                Application_Load_Event += Application_8;
                Form1_Load(sender, e);
            }
        }

        //===============================================================X
    }
}
