namespace FoodManager
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewMenu = new System.Windows.Forms.DataGridView();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.labelPickNextDays = new System.Windows.Forms.Label();
            this.numericUpDownPickNextDays = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.buttonGoToDateCustom = new System.Windows.Forms.Button();
            this.labelExistingFiles = new System.Windows.Forms.Label();
            this.labelCustomDate = new System.Windows.Forms.Label();
            this.buttonGoToDateExisting = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxWeekFiles = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPickNextDays)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMenu
            // 
            this.dataGridViewMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMenu.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMenu.Name = "dataGridViewMenu";
            this.dataGridViewMenu.RowHeadersVisible = false;
            this.dataGridViewMenu.Size = new System.Drawing.Size(428, 179);
            this.dataGridViewMenu.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dataGridViewMenu);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.labelPickNextDays);
            this.splitContainer.Panel2.Controls.Add(this.numericUpDownPickNextDays);
            this.splitContainer.Panel2.Controls.Add(this.buttonGenerateReport);
            this.splitContainer.Panel2.Controls.Add(this.buttonGoToDateCustom);
            this.splitContainer.Panel2.Controls.Add(this.labelExistingFiles);
            this.splitContainer.Panel2.Controls.Add(this.labelCustomDate);
            this.splitContainer.Panel2.Controls.Add(this.buttonGoToDateExisting);
            this.splitContainer.Panel2.Controls.Add(this.dateTimePicker);
            this.splitContainer.Panel2.Controls.Add(this.comboBoxWeekFiles);
            this.splitContainer.Panel2.Controls.Add(this.buttonSave);
            this.splitContainer.Size = new System.Drawing.Size(428, 267);
            this.splitContainer.SplitterDistance = 179;
            this.splitContainer.TabIndex = 1;
            // 
            // labelPickNextDays
            // 
            this.labelPickNextDays.AutoSize = true;
            this.labelPickNextDays.Location = new System.Drawing.Point(3, 57);
            this.labelPickNextDays.Name = "labelPickNextDays";
            this.labelPickNextDays.Size = new System.Drawing.Size(88, 13);
            this.labelPickNextDays.TabIndex = 9;
            this.labelPickNextDays.Text = "Pick ... next days";
            // 
            // numericUpDownPickNextDays
            // 
            this.numericUpDownPickNextDays.InterceptArrowKeys = false;
            this.numericUpDownPickNextDays.Location = new System.Drawing.Point(98, 55);
            this.numericUpDownPickNextDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPickNextDays.Name = "numericUpDownPickNextDays";
            this.numericUpDownPickNextDays.Size = new System.Drawing.Size(146, 20);
            this.numericUpDownPickNextDays.TabIndex = 8;
            this.numericUpDownPickNextDays.Tag = "days";
            this.numericUpDownPickNextDays.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Location = new System.Drawing.Point(250, 55);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(75, 20);
            this.buttonGenerateReport.TabIndex = 7;
            this.buttonGenerateReport.Text = "Generate report";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            this.buttonGenerateReport.Click += new System.EventHandler(this.buttonGenerateReport_Click);
            // 
            // buttonGoToDateCustom
            // 
            this.buttonGoToDateCustom.Location = new System.Drawing.Point(250, 30);
            this.buttonGoToDateCustom.Name = "buttonGoToDateCustom";
            this.buttonGoToDateCustom.Size = new System.Drawing.Size(75, 20);
            this.buttonGoToDateCustom.TabIndex = 6;
            this.buttonGoToDateCustom.Text = "-->";
            this.buttonGoToDateCustom.UseVisualStyleBackColor = true;
            this.buttonGoToDateCustom.Click += new System.EventHandler(this.buttonGoToDateCustom_Click);
            // 
            // labelExistingFiles
            // 
            this.labelExistingFiles.AutoSize = true;
            this.labelExistingFiles.Location = new System.Drawing.Point(3, 8);
            this.labelExistingFiles.Name = "labelExistingFiles";
            this.labelExistingFiles.Size = new System.Drawing.Size(82, 13);
            this.labelExistingFiles.TabIndex = 5;
            this.labelExistingFiles.Text = "Pick existing file";
            // 
            // labelCustomDate
            // 
            this.labelCustomDate.AutoSize = true;
            this.labelCustomDate.Location = new System.Drawing.Point(3, 33);
            this.labelCustomDate.Name = "labelCustomDate";
            this.labelCustomDate.Size = new System.Drawing.Size(89, 13);
            this.labelCustomDate.TabIndex = 4;
            this.labelCustomDate.Text = "Pick custom date";
            // 
            // buttonGoToDateExisting
            // 
            this.buttonGoToDateExisting.Location = new System.Drawing.Point(250, 5);
            this.buttonGoToDateExisting.Name = "buttonGoToDateExisting";
            this.buttonGoToDateExisting.Size = new System.Drawing.Size(75, 21);
            this.buttonGoToDateExisting.TabIndex = 3;
            this.buttonGoToDateExisting.Text = "-->";
            this.buttonGoToDateExisting.UseVisualStyleBackColor = true;
            this.buttonGoToDateExisting.Click += new System.EventHandler(this.buttonGoToDateExisting_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(98, 30);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(146, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // comboBoxWeekFiles
            // 
            this.comboBoxWeekFiles.FormattingEnabled = true;
            this.comboBoxWeekFiles.Location = new System.Drawing.Point(98, 5);
            this.comboBoxWeekFiles.Name = "comboBoxWeekFiles";
            this.comboBoxWeekFiles.Size = new System.Drawing.Size(146, 21);
            this.comboBoxWeekFiles.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(331, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 70);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save to CSV";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 267);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 306);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPickNextDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMenu;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxWeekFiles;
        private System.Windows.Forms.Button buttonGoToDateExisting;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonGoToDateCustom;
        private System.Windows.Forms.Label labelExistingFiles;
        private System.Windows.Forms.Label labelCustomDate;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.Label labelPickNextDays;
        private System.Windows.Forms.NumericUpDown numericUpDownPickNextDays;
    }
}

