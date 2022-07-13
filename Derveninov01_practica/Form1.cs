using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Derveninov01_practica
{
    // Главная форма
    public partial class Form1 : Form
    {
        private Graphics graphics;
        Field field;
        Virus virus;
        private bool FirstStart = true;
        private int rows;
        private int columns;
        private int resolution = 20;
        // Конструктор
        public Form1()
        {
            InitializeComponent();
            field = new Field();
            virus = new Virus();
        }
        // Метод отрисовки поля
        private void DrawField() {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (field.HumanList[i][j].Vector)
                    {
                        graphics.FillRectangle(Brushes.OrangeRed, i * resolution, j * resolution, resolution - 1, resolution - 1);
                    }
                    else if (field.HumanList[i][j].Ill)
                    {
                        graphics.FillRectangle(Brushes.DarkRed, i * resolution, j * resolution, resolution - 1, resolution - 1);
                    }
                    else if (field.HumanList[i][j].Risk == 0)
                        graphics.FillRectangle(Brushes.AntiqueWhite, i * resolution, j * resolution, resolution - 1, resolution - 1);
                    else if (field.HumanList[i][j].Recovered)
                        graphics.FillRectangle(Brushes.LimeGreen, i * resolution, j * resolution, resolution - 1, resolution - 1);
                    else if (field.HumanList[i][j].Dead)
                        graphics.FillRectangle(Brushes.Black, i * resolution, j * resolution, resolution - 1, resolution - 1);
                    else
                        graphics.FillRectangle(Brushes.Gray, i * resolution, j * resolution, resolution - 1, resolution - 1);

                }
            }
            field.ClearGotIllnes();
        }
        // Следующий шаг
        private void NextStep()
        {
            if (field.EpidemicEnded)
            {
                timer1.Stop();
                List<int> resultEpidemic;
                resultEpidemic = field.EpidemicResult();
                field.EpidemicResult();
                MessageBox.Show(
                    $"Количество молодых: {resultEpidemic[0]}\n" +
                    $"Молодых погибло: {resultEpidemic[1]}\n" +
                    $"Молодых выздоровело: {resultEpidemic[0] - resultEpidemic[1]}\n\n" +
                    $"Количество взрослых: {resultEpidemic[2]}\n" +
                    $"Взрослых погибло: {resultEpidemic[3]}\n" +
                    $"Взрослых выздоровело: {resultEpidemic[2] - resultEpidemic[3]}\n\n" +
                    $"Количество пожилых: {resultEpidemic[4]}\n" +
                    $"Пожилых погибло: {resultEpidemic[5]}\n" +
                    $"Пожилых выздоровело: {resultEpidemic[4] - resultEpidemic[5]}\n\n" +
                    $"Не подвержено риску: {resultEpidemic[6]}" 
                    );
                return;
            }
            field.NextGeneration();
            graphics.Clear(Color.Transparent);
            DrawField();
            pictureBox1.Refresh();
            int days_int = Int32.Parse(labelDays.Text);
            days_int++;
            labelDays.Text = days_int.ToString();
        }
        // Тик таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            NextStep();
        }
        // Сброс поля
        private void ResetField() 
        {
            timer1.Stop();
            labelDays.Text = 0.ToString();
            if (!FirstStart)
                field.DeleteHumanList();
            FirstStart = false;
            rows = pictureBox1.Height / resolution;
            columns = pictureBox1.Width / resolution;
            field.Columns = columns;
            field.Rows = rows;
            float chanceToHaveMask = (float)nudMask.Value;
            field.CreateHumanList(columns, rows, virus, chanceToHaveMask);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            DrawField();
        }
        // Первое отображение формы
        private void Form1_Shown(object sender, EventArgs e)
        {
            virus.ResetVirus((float)nudRiskYoung.Value, (float)nudRiskAdult.Value, (float)nudRiskAged.Value,
                (float)nudMortalityYoung.Value, (float)nudMortalityAdult.Value, (float)nudMortalityAged.Value);
            ResetField();
        }
        // Событие нажатия кнопки сброса поля
        private void buttonReset_Click(object sender, EventArgs e)
        {
            virus.ResetVirus((float)nudRiskYoung.Value, (float)nudRiskAdult.Value, (float)nudRiskAged.Value,
                (float)nudMortalityYoung.Value, (float)nudMortalityAdult.Value, (float)nudMortalityAged.Value);
            ResetField();
        }
        // Событие нажатия кнопки "Шаг"
        private void buttonStep_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            NextStep();
        }
        // Событие нажатия кнопки "Старт"
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        // Событие нажатия кнопки "Стоп"
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
