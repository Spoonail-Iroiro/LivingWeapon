namespace LivingWeapon
{
    partial class SelectEnchantsForm
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
            this.dgvEnchants = new System.Windows.Forms.DataGridView();
            this.enchantTypeDiscription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ecbEnchant = new LivingWeapon.EnchantCombobox();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudGoal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEnchantCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudStart = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPreparing = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnchants)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEnchants
            // 
            this.dgvEnchants.AllowUserToAddRows = false;
            this.dgvEnchants.AllowUserToDeleteRows = false;
            this.dgvEnchants.AllowUserToResizeColumns = false;
            this.dgvEnchants.AllowUserToResizeRows = false;
            this.dgvEnchants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnchants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enchantTypeDiscription,
            this.skill});
            this.dgvEnchants.Location = new System.Drawing.Point(321, 12);
            this.dgvEnchants.MultiSelect = false;
            this.dgvEnchants.Name = "dgvEnchants";
            this.dgvEnchants.ReadOnly = true;
            this.dgvEnchants.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvEnchants.RowTemplate.Height = 24;
            this.dgvEnchants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnchants.Size = new System.Drawing.Size(433, 401);
            this.dgvEnchants.TabIndex = 1;
            this.dgvEnchants.TabStop = false;
            this.dgvEnchants.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvEnchants_RowsChanged);
            // 
            // enchantTypeDiscription
            // 
            this.enchantTypeDiscription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.enchantTypeDiscription.DataPropertyName = "TypeStr";
            this.enchantTypeDiscription.HeaderText = "エンチャント";
            this.enchantTypeDiscription.Name = "enchantTypeDiscription";
            this.enchantTypeDiscription.ReadOnly = true;
            this.enchantTypeDiscription.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.enchantTypeDiscription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.enchantTypeDiscription.Width = 81;
            // 
            // skill
            // 
            this.skill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.skill.DataPropertyName = "SkillStr";
            this.skill.HeaderText = "　";
            this.skill.Name = "skill";
            this.skill.ReadOnly = true;
            this.skill.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.skill.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ecbEnchant);
            this.groupBox1.Controls.Add(this.btnAddAll);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新規";
            // 
            // ecbEnchant
            // 
            this.ecbEnchant.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.ecbEnchant.Location = new System.Drawing.Point(7, 26);
            this.ecbEnchant.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ecbEnchant.Name = "ecbEnchant";
            this.ecbEnchant.Size = new System.Drawing.Size(288, 61);
            this.ecbEnchant.TabIndex = 1;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(98, 93);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(119, 34);
            this.btnAddAll.TabIndex = 3;
            this.btnAddAll.Text = ">>全部追加";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 93);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 34);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = ">追加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(19, 162);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(138, 34);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "コピー";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(19, 202);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(138, 34);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnNext.Location = new System.Drawing.Point(616, 419);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(138, 34);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = "次へ";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.nudGoal);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblEnchantCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nudStart);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(19, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 168);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "育成レベル設定";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Lv";
            this.label5.Click += new System.EventHandler(this.label4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lv";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // nudGoal
            // 
            this.nudGoal.Location = new System.Drawing.Point(90, 95);
            this.nudGoal.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudGoal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGoal.Name = "nudGoal";
            this.nudGoal.Size = new System.Drawing.Size(68, 27);
            this.nudGoal.TabIndex = 7;
            this.nudGoal.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudGoal.ValueChanged += new System.EventHandler(this.nudGoal_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "↓";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblEnchantCount
            // 
            this.lblEnchantCount.AutoSize = true;
            this.lblEnchantCount.Location = new System.Drawing.Point(123, 134);
            this.lblEnchantCount.Name = "lblEnchantCount";
            this.lblEnchantCount.Size = new System.Drawing.Size(27, 19);
            this.lblEnchantCount.TabIndex = 7;
            this.lblEnchantCount.Text = "14";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "エンチャント個数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "育成後：";
            // 
            // nudStart
            // 
            this.nudStart.Location = new System.Drawing.Point(90, 25);
            this.nudStart.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStart.Name = "nudStart";
            this.nudStart.Size = new System.Drawing.Size(68, 27);
            this.nudStart.TabIndex = 6;
            this.nudStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStart.ValueChanged += new System.EventHandler(this.nudStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "育成開始：";
            // 
            // lblPreparing
            // 
            this.lblPreparing.AutoSize = true;
            this.lblPreparing.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.lblPreparing.Location = new System.Drawing.Point(441, 424);
            this.lblPreparing.Name = "lblPreparing";
            this.lblPreparing.Size = new System.Drawing.Size(0, 25);
            this.lblPreparing.TabIndex = 9;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnBack.Location = new System.Drawing.Point(19, 419);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(138, 34);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // SelectEnchantsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 461);
            this.Controls.Add(this.lblPreparing);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvEnchants);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopy);
            this.Name = "SelectEnchantsForm";
            this.Text = "エンチャント選択";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectEnchantsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnchants)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEnchants;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private EnchantCombobox ecbEnchant;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn enchantTypeDiscription;
        private System.Windows.Forms.DataGridViewTextBoxColumn skill;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudGoal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEnchantCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPreparing;
        private System.Windows.Forms.Button btnBack;
    }
}