namespace LivingWeapon
{
    partial class Upper15WeaponSelectEnchantForm
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
            this.ecbMain = new LivingWeapon.EnchantCombobox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGoalLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStartLevel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSigCount = new System.Windows.Forms.NumericUpDown();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudPageLimit = new System.Windows.Forms.NumericUpDown();
            this.btnUnlimit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPageLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // ecbMain
            // 
            this.ecbMain.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.ecbMain.Location = new System.Drawing.Point(7, 26);
            this.ecbMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ecbMain.Name = "ecbMain";
            this.ecbMain.Size = new System.Drawing.Size(334, 67);
            this.ecbMain.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudLevel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "現在の生き武器レベル";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "※15以上";
            // 
            // nudLevel
            // 
            this.nudLevel.Location = new System.Drawing.Point(7, 27);
            this.nudLevel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(120, 27);
            this.nudLevel.TabIndex = 0;
            this.nudLevel.ValueChanged += new System.EventHandler(this.nudLevel_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblGoalLevel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblStartLevel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nudSigCount);
            this.groupBox2.Controls.Add(this.ecbMain);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 194);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "エンチャント";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "→";
            // 
            // lblGoalLevel
            // 
            this.lblGoalLevel.AutoSize = true;
            this.lblGoalLevel.Location = new System.Drawing.Point(177, 159);
            this.lblGoalLevel.Name = "lblGoalLevel";
            this.lblGoalLevel.Size = new System.Drawing.Size(40, 19);
            this.lblGoalLevel.TabIndex = 7;
            this.lblGoalLevel.Text = "goal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "育成終了レベル";
            // 
            // lblStartLevel
            // 
            this.lblStartLevel.AutoSize = true;
            this.lblStartLevel.Location = new System.Drawing.Point(6, 159);
            this.lblStartLevel.Name = "lblStartLevel";
            this.lblStartLevel.Size = new System.Drawing.Size(43, 19);
            this.lblStartLevel.TabIndex = 5;
            this.lblStartLevel.Text = "start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "育成開始レベル";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "付ける個数：";
            // 
            // nudSigCount
            // 
            this.nudSigCount.Location = new System.Drawing.Point(104, 99);
            this.nudSigCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSigCount.Name = "nudSigCount";
            this.nudSigCount.Size = new System.Drawing.Size(120, 27);
            this.nudSigCount.TabIndex = 1;
            this.nudSigCount.ValueChanged += new System.EventHandler(this.nudSigCount_ValueChanged);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnBack.Location = new System.Drawing.Point(12, 384);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(138, 34);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnNext.Location = new System.Drawing.Point(215, 384);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(138, 34);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "次へ";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.nudPageLimit);
            this.groupBox3.Controls.Add(this.btnUnlimit);
            this.groupBox3.Location = new System.Drawing.Point(12, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 74);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ページ制限";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "ページまで";
            // 
            // nudPageLimit
            // 
            this.nudPageLimit.Location = new System.Drawing.Point(11, 28);
            this.nudPageLimit.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.nudPageLimit.Name = "nudPageLimit";
            this.nudPageLimit.Size = new System.Drawing.Size(98, 27);
            this.nudPageLimit.TabIndex = 10;
            // 
            // btnUnlimit
            // 
            this.btnUnlimit.Location = new System.Drawing.Point(188, 22);
            this.btnUnlimit.Name = "btnUnlimit";
            this.btnUnlimit.Size = new System.Drawing.Size(85, 34);
            this.btnUnlimit.TabIndex = 2;
            this.btnUnlimit.Text = "制限なし";
            this.btnUnlimit.UseVisualStyleBackColor = true;
            this.btnUnlimit.Click += new System.EventHandler(this.btnUnlimit_Click);
            // 
            // Upper15WeaponSelectEnchantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 430);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Upper15WeaponSelectEnchantForm";
            this.Text = "生き武器レベル・エンチャント設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Upper16WeaponSelectEnchantForm_FormClosing);
            this.Load += new System.EventHandler(this.Upper15WeaponSelectEnchantForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPageLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EnchantCombobox ecbMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudSigCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGoalLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStartLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPageLimit;
        private System.Windows.Forms.Button btnUnlimit;
    }
}