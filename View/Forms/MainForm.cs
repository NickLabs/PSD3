using System;
using View.ViewInterfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Forms
{
    public partial class MainForm : Form, IView
    {
        public string Min { get { return LeftBorder.Text; } }
        public string Max { get { return RightBorder.Text; } }
        public string A { get { return ParamA.Text; } }
        public event EventHandler ButtonClick;
        public event EventHandler HelpButton;
        public void SetChart(List<double> X, List<Double> Y)
        {
            chart.Series[0].Points.Clear();
            for (int i = 0; i < X.Count; i++)
            {
                chart.Series[0].Points.AddXY(X[i], Y[i]);
            }
        }
        public void SetDotsList(List<double> X, List<Double> Y)
        {
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < X.Count; i++)
            {
                dataGridView1.Rows.Add(X[i],Y[i]);               
            }
            dataGridView1.Show();
        }
        public void WrongDataBox()
        {
            string message = "Должны быть введены числа. Повторите ввод";
            string caption = "Неверный формат числа";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
        public void WrongInterval()
        {
            string message = "Левая граница должна быть меньше правой";
            string caption = "Неверный интервал";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
        public void Greetings()
        {
            string message = "Программа была разработана студентом 465 группы\n" +
                "Винокуровым Никитой Александровичем\n" +
                "Данная программа строит графк функции Y = A^3/(A^2+X^2)\n и выводит координаты точек, по которым был построен график" +
                "Пользователь вводит параметр А, а также левую и правую границы отображения графика";
            string caption = "Приветствие";
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public new void Show()
        {
            Application.Run(this);
        }


        public void Start()
        {
            this.Show();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpButton?.Invoke(this, null);
        }
    }     
}
