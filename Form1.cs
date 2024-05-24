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

        private void maxTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && maxTextbox.Text.Length > 0)
            {
                UpdateForms();
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            UpdateForms();
        }

        private void UpdateForms()
        {
            int operationCounter = 0;
            int arrayLength = int.Parse(maxTextbox.Text);
            int[] randomArray = ArrayInitializer.InitializeArray(arrayLength);

            if (randomArray.Length == 0) return;

            int quickSort = SortingManager.QuickSort(randomArray, 0, randomArray.Length - 1, ref operationCounter, true);
            int bubbleSort = SortingManager.BubbleSort(randomArray);
            int selectionSort = SortingManager.SelectionSort(randomArray);
            int shellSort = SortingManager.ShellSort(randomArray);
            int bogoSort = 0;

            if (bogoCheckBox.Checked == true)
                bogoSort = SortingManager.BogoSort(randomArray);

            int[] resultArray = [quickSort, bubbleSort, selectionSort, shellSort, bogoSort];

            UpdateChart(resultArray);
            UpdateTable(resultArray);

            maxTextbox.Text = "";
        }

        private void maxTextbox_TextChanged(object sender, EventArgs e)
        {
            if (maxTextbox.Text.Length < 1) sortButton.Enabled = false;
            else sortButton.Enabled = true;
        }

        private void UpdateChart(int[] values)
        {
            string[] labels = { "Quick Sort", "Bubble Sort", "Selection Sort", "Shell Sort", "Bogo Sort" };

            complexityChart.Series.Clear();

            var series = new Series();
            series.ChartType = SeriesChartType.Column;
            complexityChart.Series.Add(series);

            for (int i = 0; i < values.Length; i++)
            {
                var point = new DataPoint(i + 1, values[i]);
                point.Label = values[i].ToString();
                series.Points.Add(point);

                complexityChart.ChartAreas[0].AxisY.Maximum = values.Max() * 1.1;
                complexityChart.ChartAreas[0].AxisX.CustomLabels.Add(i + 0.5, i + 1.5, labels[i]);
            }
        }

        private void UpdateTable(int[] values)
        {
            dataGridView.Rows[0].Cells["quickSortColumn"].Value = values[0];
            dataGridView.Rows[0].Cells["bubbleSortColumn"].Value = values[1];
            dataGridView.Rows[0].Cells["selectionSortColumn"].Value = values[2];
            dataGridView.Rows[0].Cells["shellSortColumn"].Value = values[3];
            dataGridView.Rows[0].Cells["bogoSortColumn"].Value = values[4];
        }

        private void bogoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bogoCheckBox.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Warning!\nThis algorithm has complexity of O(n!).\nAre you sure you want to continue?", "BogoSort Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    bogoCheckBox.Checked = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    bogoCheckBox.Checked = false;
                }
            }
        }
    }
}
