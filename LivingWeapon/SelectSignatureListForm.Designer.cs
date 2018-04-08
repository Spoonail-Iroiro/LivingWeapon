namespace LivingWeapon
{
    partial class SelectSignatureListForm
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
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkFeated = new System.Windows.Forms.CheckBox();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdb1
            // 
            this.rdb1.AutoSize = true;
            this.rdb1.Checked = true;
            this.rdb1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.rdb1.Location = new System.Drawing.Point(7, 34);
            this.rdb1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb1.Name = "rdb1";
            this.rdb1.Size = new System.Drawing.Size(185, 23);
            this.rdb1.TabIndex = 1;
            this.rdb1.TabStop = true;
            this.rdb1.Text = "ver1.16fix2b 近接武器";
            this.rdb1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.chkFeated);
            this.groupBox1.Controls.Add(this.rdb2);
            this.groupBox1.Controls.Add(this.rdb1);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(360, 188);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "バージョンを選ぶ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnOK.Location = new System.Drawing.Point(6, 141);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 34);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "決定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkFeated
            // 
            this.chkFeated.AutoSize = true;
            this.chkFeated.Checked = true;
            this.chkFeated.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFeated.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.chkFeated.Location = new System.Drawing.Point(7, 110);
            this.chkFeated.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkFeated.Name = "chkFeated";
            this.chkFeated.Size = new System.Drawing.Size(93, 23);
            this.chkFeated.TabIndex = 10;
            this.chkFeated.Text = "フィートあり";
            this.chkFeated.UseVisualStyleBackColor = true;
            // 
            // rdb2
            // 
            this.rdb2.AutoSize = true;
            this.rdb2.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.rdb2.Location = new System.Drawing.Point(7, 65);
            this.rdb2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb2.Name = "rdb2";
            this.rdb2.Size = new System.Drawing.Size(185, 23);
            this.rdb2.TabIndex = 2;
            this.rdb2.TabStop = true;
            this.rdb2.Text = "ver1.16fix2b 遠隔武器";
            this.rdb2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.groupBox2.Location = new System.Drawing.Point(12, 209);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(360, 106);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "銘リストを読み込む";
            // 
            // SelectSignatureListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 330);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectSignatureListForm";
            this.Text = "銘リスト選択";
            this.Load += new System.EventHandler(this.SelectSignatureListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkFeated;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}