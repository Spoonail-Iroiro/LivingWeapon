namespace LivingWeapon
{
    partial class DGVForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkFont = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAsCSV = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // chkFont
            // 
            this.chkFont.AutoSize = true;
            this.chkFont.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.chkFont.Location = new System.Drawing.Point(201, 444);
            this.chkFont.Name = "chkFont";
            this.chkFont.Size = new System.Drawing.Size(130, 29);
            this.chkFont.TabIndex = 12;
            this.chkFont.Text = "等幅フォント";
            this.chkFont.UseVisualStyleBackColor = true;
            this.chkFont.CheckedChanged += new System.EventHandler(this.chkFont_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "結果（表形式）";
            // 
            // btnSaveAsCSV
            // 
            this.btnSaveAsCSV.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnSaveAsCSV.Location = new System.Drawing.Point(17, 440);
            this.btnSaveAsCSV.Name = "btnSaveAsCSV";
            this.btnSaveAsCSV.Size = new System.Drawing.Size(169, 34);
            this.btnSaveAsCSV.TabIndex = 2;
            this.btnSaveAsCSV.Text = "csvファイル保存";
            this.btnSaveAsCSV.UseVisualStyleBackColor = true;
            this.btnSaveAsCSV.Click += new System.EventHandler(this.btnSaveAsCSV_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(17, 38);
            this.dgvMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvMain.RowTemplate.Height = 24;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(883, 395);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            // 
            // DGVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 486);
            this.Controls.Add(this.chkFont);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveAsCSV);
            this.Controls.Add(this.dgvMain);
            this.Name = "DGVForm";
            this.Text = "結果";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DGVForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnSaveAsCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFont;
    }
}