using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace SortComplexityDifferenceProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && textBox1.Text.Length > 0)
            {
                UpdateForms();
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateForms();
        }

        private void UpdateForms()
        {
            int operationCounter = 0;
            int arrayLength = int.Parse(textBox1.Text);
            int[] randomArray = ArrayInitializer.InitializeArray(arrayLength);

            if (randomArray.Length == 0) return;

            int quickSort = SortingManager.QuickSort(randomArray, 0, randomArray.Length - 1, ref operationCounter);
            int bubbleSort = SortingManager.BubbleSort(randomArray);
            int selectionSort = SortingManager.SelectionSort(randomArray);
            int shellSort = SortingManager.ShellSort(randomArray);
            int bogoSort = 0;

            if (checkBox1.Checked == true)
                bogoSort = SortingManager.BogoSort(randomArray);

            int[] resultArray = [quickSort, bubbleSort, selectionSort, shellSort, bogoSort];

            UpdateChart(resultArray);
            UpdateTable(resultArray);

            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1) button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void UpdateChart(int[] values)
        {
            string[] labels = { "Quick Sort", "Bubble Sort", "Selection Sort", "Shell Sort", "Bogo Sort" };

            chart1.Series.Clear();

            var series = new Series();
            series.ChartType = SeriesChartType.Column;
            chart1.Series.Add(series);

            for (int i = 0; i < values.Length; i++)
            {
                var point = new DataPoint(i + 1, values[i]);
                point.Label = values[i].ToString();
                series.Points.Add(point);

                chart1.ChartAreas[0].AxisY.Maximum = values.Max() * 1.1;
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(i + 0.5, i + 1.5, labels[i]);
            }
        }

        private void UpdateTable(int[] values)
        {
            dataGridView1.Rows[0].Cells["Column1"].Value = values[0];
            dataGridView1.Rows[0].Cells["Column2"].Value = values[1];
            dataGridView1.Rows[0].Cells["Column3"].Value = values[2];
            dataGridView1.Rows[0].Cells["Column4"].Value = values[3];
            dataGridView1.Rows[0].Cells["Column5"].Value = values[4];
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Warning!\nThis algorithm has complexity of O(n!).\nAre you sure you want to continue?", "BOGOSORT WARNING!", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    checkBox1.Checked = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    checkBox1.Checked = false;
                }
            }
        }
    }
}
