namespace LivingWeapon
{
    partial class EvilWeaponSettingForm
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSelect2 = new System.Windows.Forms.TextBox();
            this.txtSelect1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSignature = new System.Windows.Forms.Label();
            this.lblEnchant = new System.Windows.Forms.Label();
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.btnEnchOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudLv = new System.Windows.Forms.NumericUpDown();
            this.groupbox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(44, 30);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(137, 27);
            this.txtID.TabIndex = 0;
            this.txtID.Text = "68042";
            // 
            // txtSelect2
            // 
            this.txtSelect2.Location = new System.Drawing.Point(6, 113);
            this.txtSelect2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSelect2.MaxLength = 1;
            this.txtSelect2.Name = "txtSelect2";
            this.txtSelect2.Size = new System.Drawing.Size(68, 27);
            this.txtSelect2.TabIndex = 0;
            this.txtSelect2.Text = "g";
            // 
            // txtSelect1
            // 
            this.txtSelect1.Location = new System.Drawing.Point(6, 78);
            this.txtSelect1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSelect1.MaxLength = 1;
            this.txtSelect1.Name = "txtSelect1";
            this.txtSelect1.Size = new System.Drawing.Size(68, 27);
            this.txtSelect1.TabIndex = 0;
            this.txtSelect1.Text = "a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "エンチャント情報（Lv1時）:";
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(192, 64);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(24, 19);
            this.lblSignature.TabIndex = 3;
            this.lblSignature.Text = "銘";
            // 
            // lblEnchant
            // 
            this.lblEnchant.AutoSize = true;
            this.lblEnchant.Location = new System.Drawing.Point(192, 92);
            this.lblEnchant.Name = "lblEnchant";
            this.lblEnchant.Size = new System.Drawing.Size(75, 19);
            this.lblEnchant.TabIndex = 4;
            this.lblEnchant.Text = "エンチャント";
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.lblEnchant);
            this.groupbox1.Controls.Add(this.btnEnchOK);
            this.groupbox1.Controls.Add(this.txtID);
            this.groupbox1.Controls.Add(this.lblSignature);
            this.groupbox1.Controls.Add(this.label2);
            this.groupbox1.Controls.Add(this.label3);
            this.groupbox1.Location = new System.Drawing.Point(12, 12);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(410, 127);
            this.groupbox1.TabIndex = 6;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "エンチャント指定";
            // 
            // btnEnchOK
            // 
            this.btnEnchOK.Location = new System.Drawing.Point(187, 26);
            this.btnEnchOK.Name = "btnEnchOK";
            this.btnEnchOK.Size = new System.Drawing.Size(98, 33);
            this.btnEnchOK.TabIndex = 6;
            this.btnEnchOK.Text = "確定";
            this.btnEnchOK.UseVisualStyleBackColor = true;
            this.btnEnchOK.Click += new System.EventHandler(this.btnEnchOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSelect1);
            this.groupBox2.Controls.Add(this.txtSelect2);
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 156);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "選択肢設定";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 378);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 33);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(324, 378);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(98, 33);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "次へ";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "を2つ入力してください（例：a g）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "上記のエンチャントの強度が最大になる時の選択肢（アルファベット）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "邪武器Lv";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudLv);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 307);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 65);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "出力数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "まで";
            // 
            // nudLv
            // 
            this.nudLv.Location = new System.Drawing.Point(78, 27);
            this.nudLv.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLv.Name = "nudLv";
            this.nudLv.Size = new System.Drawing.Size(109, 27);
            this.nudLv.TabIndex = 9;
            this.nudLv.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // EvilWeaponSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 424);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupbox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EvilWeaponSettingForm";
            this.Text = "邪武器設定";
            this.groupbox1.ResumeLayout(false);
            this.groupbox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSelect2;
        private System.Windows.Forms.TextBox txtSelect1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblEnchant;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnchOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudLv;
        private System.Windows.Forms.Label label6;
    }
}