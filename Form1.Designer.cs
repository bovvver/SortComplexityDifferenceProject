using System.Windows.Forms.DataVisualization.Charting;

namespace SortComplexityDifferenceProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ChartArea chartArea3 = new ChartArea();
            Title title3 = new Title();
            maxTextbox = new TextBox();
            sortButton = new Button();
            dataGridView = new DataGridView();
            quickSortColumn = new DataGridViewTextBoxColumn();
            bubbleSortColumn = new DataGridViewTextBoxColumn();
            selectionSortColumn = new DataGridViewTextBoxColumn();
            shellSortColumn = new DataGridViewTextBoxColumn();
            bogoSortColumn = new DataGridViewTextBoxColumn();
            bogoCheckBox = new CheckBox();
            complexityChart = new Chart();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)complexityChart).BeginInit();
            SuspendLayout();
            // 
            // maxTextbox
            // 
            maxTextbox.Location = new Point(15, 11);
            maxTextbox.Margin = new Padding(3, 2, 3, 2);
            maxTextbox.Name = "maxTextbox";
            maxTextbox.PlaceholderText = "Array Length";
            maxTextbox.Size = new Size(133, 23);
            maxTextbox.TabIndex = 1;
            maxTextbox.TextChanged += maxTextbox_TextChanged;
            maxTextbox.KeyPress += maxTextbox_KeyPress;
            // 
            // sortButton
            // 
            sortButton.Enabled = false;
            sortButton.Location = new Point(154, 11);
            sortButton.Margin = new Padding(3, 2, 3, 2);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(87, 23);
            sortButton.TabIndex = 2;
            sortButton.Text = "SORT";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { quickSortColumn, bubbleSortColumn, selectionSortColumn, shellSortColumn, bogoSortColumn });
            dataGridView.Location = new Point(15, 44);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(801, 87);
            dataGridView.TabIndex = 4;
            // 
            // quickSortColumn
            // 
            quickSortColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quickSortColumn.HeaderText = "Quick Sort";
            quickSortColumn.MinimumWidth = 6;
            quickSortColumn.Name = "quickSortColumn";
            quickSortColumn.ReadOnly = true;
            // 
            // bubbleSortColumn
            // 
            bubbleSortColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bubbleSortColumn.HeaderText = "Bubble Sort";
            bubbleSortColumn.MinimumWidth = 6;
            bubbleSortColumn.Name = "bubbleSortColumn";
            bubbleSortColumn.ReadOnly = true;
            // 
            // selectionSortColumn
            // 
            selectionSortColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            selectionSortColumn.HeaderText = "Selection Sort";
            selectionSortColumn.MinimumWidth = 6;
            selectionSortColumn.Name = "selectionSortColumn";
            selectionSortColumn.ReadOnly = true;
            // 
            // shellSortColumn
            // 
            shellSortColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            shellSortColumn.HeaderText = "Shell Sort";
            shellSortColumn.MinimumWidth = 6;
            shellSortColumn.Name = "shellSortColumn";
            shellSortColumn.ReadOnly = true;
            // 
            // bogoSortColumn
            // 
            bogoSortColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bogoSortColumn.HeaderText = "Bogo Sort";
            bogoSortColumn.MinimumWidth = 6;
            bogoSortColumn.Name = "bogoSortColumn";
            bogoSortColumn.ReadOnly = true;
            // 
            // bogoCheckBox
            // 
            bogoCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bogoCheckBox.AutoSize = true;
            bogoCheckBox.Location = new Point(709, 15);
            bogoCheckBox.Margin = new Padding(3, 2, 3, 2);
            bogoCheckBox.Name = "bogoCheckBox";
            bogoCheckBox.Size = new Size(107, 19);
            bogoCheckBox.TabIndex = 5;
            bogoCheckBox.Text = "Allow Bogosort";
            bogoCheckBox.UseVisualStyleBackColor = true;
            bogoCheckBox.CheckedChanged += bogoCheckBox_CheckedChanged;
            // 
            // complexityChart
            // 
            complexityChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea3.Name = "ChartArea1";
            complexityChart.ChartAreas.Add(chartArea3);
            complexityChart.Location = new Point(15, 135);
            complexityChart.Margin = new Padding(3, 2, 3, 2);
            complexityChart.Name = "complexityChart";
            complexityChart.Size = new Size(801, 280);
            complexityChart.TabIndex = 3;
            complexityChart.Text = "complexityChart";
            title3.Name = "Title1";
            title3.Text = "Complexity of sorting algorithms";
            complexityChart.Titles.Add(title3);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(828, 424);
            Controls.Add(bogoCheckBox);
            Controls.Add(dataGridView);
            Controls.Add(complexityChart);
            Controls.Add(sortButton);
            Controls.Add(maxTextbox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Sort Complexity Comparison Engine";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)complexityChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox maxTextbox;
        private Button sortButton;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn quickSortColumn;
        private DataGridViewTextBoxColumn bubbleSortColumn;
        private DataGridViewTextBoxColumn selectionSortColumn;
        private DataGridViewTextBoxColumn shellSortColumn;
        private DataGridViewTextBoxColumn bogoSortColumn;
        private CheckBox bogoCheckBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart complexityChart;
    }
}
