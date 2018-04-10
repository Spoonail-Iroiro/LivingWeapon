namespace LivingWeapon
{
    partial class SignatureCombinationResultForm
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
            this.btnEnchantInfo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnchLv = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.txtMain.Size = new System.Drawing.Size(844, 449);
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
            // btnEnchantInfo
            // 
            this.btnEnchantInfo.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnEnchantInfo.Location = new System.Drawing.Point(281, 26);
            this.btnEnchantInfo.Name = "btnEnchantInfo";
            this.btnEnchantInfo.Size = new System.Drawing.Size(307, 34);
            this.btnEnchantInfo.TabIndex = 3;
            this.btnEnchantInfo.Text = "エンチャント情報（理想値比較）";
            this.btnEnchantInfo.UseVisualStyleBackColor = true;
            this.btnEnchantInfo.Click += new System.EventHandler(this.btnEnchantInfo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnExit.Location = new System.Drawing.Point(749, 492);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnchLv);
            this.groupBox1.Controls.Add(this.btnEnchantInfo);
            this.groupBox1.Location = new System.Drawing.Point(17, 532);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 80);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参考情報";
            // 
            // btnEnchLv
            // 
            this.btnEnchLv.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnEnchLv.Location = new System.Drawing.Point(6, 26);
            this.btnEnchLv.Name = "btnEnchLv";
            this.btnEnchLv.Size = new System.Drawing.Size(269, 34);
            this.btnEnchLv.TabIndex = 3;
            this.btnEnchLv.Text = "エンチャント情報（Lv順）";
            this.btnEnchLv.UseVisualStyleBackColor = true;
            this.btnEnchLv.Click += new System.EventHandler(this.btnEnchLv_Click);
            // 
            // SignatureCombinationResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShowTable);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSaveAsFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMain);
            this.Name = "SignatureCombinationResultForm";
            this.Text = "結果";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignatureCombinationResultForm_FormClosing);
            this.Load += new System.EventHandler(this.SignatureCombinationResultForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveAsFile;
        private System.Windows.Forms.Button btnShowTable;
        private System.Windows.Forms.Button btnEnchantInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEnchLv;
    }
}