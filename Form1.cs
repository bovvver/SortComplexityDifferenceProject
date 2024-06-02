using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace SortComplexityDifferenceProject
{
    public partial class Form1 : Form
    {
        public Series QuickSort { get; private set; }
        public Series BubbleSort { get; private set; }
        public Series SelectionSort { get; private set; }
        public Series ShellSort { get; private set; }
        public Series BogoSort { get; private set; }
        readonly int MIN_VALUE = 3;

        public Form1()
        {
            InitializeComponent();
            QuickSort = CreateSeries("Quick Sort");
            BubbleSort = CreateSeries("Bubble Sort");
            SelectionSort = CreateSeries("Selection Sort");
            ShellSort = CreateSeries("Shell Sort");
            BogoSort = CreateSeries("Bogo Sort");
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

        private void UpdateForms()
        {
            int arrayLength = int.Parse(maxTextbox.Text);

            ClearChart();

            for (int i = MIN_VALUE; i <= arrayLength; i++)
            {
                int[] randomArray = ArrayInitializer.InitializeArray(i);
                int operationCounter = 0;

                if (randomArray.Length == 0) return;

                int quickSort = SortingManager.QuickSort(randomArray, 0, randomArray.Length - 1, ref operationCounter, true);
                int bubbleSort = SortingManager.BubbleSort(randomArray);
                int selectionSort = SortingManager.SelectionSort(randomArray);
                int shellSort = SortingManager.ShellSort(randomArray);
                int bogoSort = 0;

                if (bogoCheckBox.Checked == true)
                    bogoSort = SortingManager.BogoSort(randomArray);

                int[] resultArray = [quickSort, bubbleSort, selectionSort, shellSort, bogoSort];

                UpdateChart(resultArray, i);
                UpdateTable(resultArray);
            }

            ApplySeriesToChart();
            maxTextbox.Text = "";
        }

        private void maxTextbox_TextChanged(object sender, EventArgs e)
        {
            if (maxTextbox.Text.Length < 1) sortButton.Enabled = false;
            else sortButton.Enabled = true;
        }

        private void UpdateChart(int[] values, int index)
        {
            /*String test = $"Index: {index}\n" +
                $"Quick Sort: {values[0]}\n" +
                $"Bubble Sort: {values[1]}\n" +
                $"Selection Sort: {values[2]}\n" +
                $"Shell Sort: {values[3]}\n" +
                $"Bogo Sort: {values[4]}\n";

            MessageBox.Show(test);*/

            QuickSort.Points.AddXY(index, values[0]);
            BubbleSort.Points.AddXY(index, values[1]);
            SelectionSort.Points.AddXY(index, values[2]);
            ShellSort.Points.AddXY(index, values[3]);
            BogoSort.Points.AddXY(index, values[4]);
        }

        private void UpdateTable(int[] values)
        {
            /*dataGridView.Rows[0].Cells["quickSortColumn"].Value = values[0];
            dataGridView.Rows[0].Cells["bubbleSortColumn"].Value = values[1];
            dataGridView.Rows[0].Cells["selectionSortColumn"].Value = values[2];
            dataGridView.Rows[0].Cells["shellSortColumn"].Value = values[3];
            dataGridView.Rows[0].Cells["bogoSortColumn"].Value = values[4];*/
        }

        private Series CreateSeries (string name)
        {
            var series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.Name = name;

            return series;
        }

        private void ApplySeriesToChart()
        {
            complexityChart.Series.Add(QuickSort);
            complexityChart.Series.Add(BubbleSort);
            complexityChart.Series.Add(SelectionSort);
            complexityChart.Series.Add(ShellSort);
            complexityChart.Series.Add(BogoSort);

            complexityChart.Legends.Add(new Legend());

            complexityChart.ChartAreas[0].AxisX.Minimum = 3;
        }

        private void ClearChart () 
        {
            foreach (var series in complexityChart.Series)
            {
                series.Points.Clear();
            }
            complexityChart.Series.Clear();
            complexityChart.Legends.Clear();
        }
    }
}
