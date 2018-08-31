namespace LivingWeapon
{
    partial class EvilWeaponResultForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMain = new System.Windows.Forms.TextBox();
            this.btnSaveAsFile = new System.Windows.Forms.Button();
            this.btnShowTable = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.chkFont = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "結果（テキスト）";
            // 
            // txtMain
            // 
            this.txtMain.Location = new System.Drawing.Point(17, 37);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(681, 449);
            this.txtMain.TabIndex = 4;
            // 
            // btnSaveAsFile
            // 
            this.btnSaveAsFile.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnSaveAsFile.Location = new System.Drawing.Point(122, 492);
            this.btnSaveAsFile.Name = "btnSaveAsFile";
            this.btnSaveAsFile.Size = new System.Drawing.Size(138, 34);
            this.btnSaveAsFile.TabIndex = 1;
            this.btnSaveAsFile.Text = "ファイル保存";
            this.btnSaveAsFile.UseVisualStyleBackColor = true;
            this.btnSaveAsFile.Click += new System.EventHandler(this.btnSaveAsFile_Click);
            // 
            // btnShowTable
            // 
            this.btnShowTable.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnShowTable.Location = new System.Drawing.Point(266, 492);
            this.btnShowTable.Name = "btnShowTable";
            this.btnShowTable.Size = new System.Drawing.Size(138, 34);
            this.btnShowTable.TabIndex = 2;
            this.btnShowTable.Text = "表形式";
            this.btnShowTable.UseVisualStyleBackColor = true;
            this.btnShowTable.Click += new System.EventHandler(this.btnShowTable_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnExit.Location = new System.Drawing.Point(586, 493);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 34);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "終了";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnBack.Location = new System.Drawing.Point(17, 492);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(99, 34);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // chkFont
            // 
            this.chkFont.AutoSize = true;
            this.chkFont.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.chkFont.Location = new System.Drawing.Point(410, 496);
            this.chkFont.Name = "chkFont";
            this.chkFont.Size = new System.Drawing.Size(130, 29);
            this.chkFont.TabIndex = 14;
            this.chkFont.Text = "等幅フォント";
            this.chkFont.UseVisualStyleBackColor = true;
            this.chkFont.CheckedChanged += new System.EventHandler(this.chkFont_CheckedChanged);
            // 
            // EvilWeaponResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 539);
            this.Controls.Add(this.chkFont);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShowTable);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSaveAsFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMain);
            this.Name = "EvilWeaponResultForm";
            this.Text = "結果";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignatureCombinationResultForm_FormClosing);
            this.Load += new System.EventHandler(this.SignatureCombinationResultForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveAsFile;
        private System.Windows.Forms.Button btnShowTable;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.CheckBox chkFont;
    }
}