namespace LivingWeapon
{
    partial class ScrollOfNameForm
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
            this.txtPage = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPageNext = new System.Windows.Forms.Button();
            this.btnPageBack = new System.Windows.Forms.Button();
            this.btnSearchBack = new System.Windows.Forms.Button();
            this.btnSearchNext = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPageCountAll = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNameList = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGoalPage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastPage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEnchName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSearchTarget = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(104, 12);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(87, 27);
            this.txtPage.TabIndex = 1;
            this.txtPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPage_KeyPress);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(104, 53);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(288, 27);
            this.txtSearch.TabIndex = 10;
            // 
            // btnPageNext
            // 
            this.btnPageNext.Location = new System.Drawing.Point(398, 7);
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Size = new System.Drawing.Size(86, 34);
            this.btnPageNext.TabIndex = 3;
            this.btnPageNext.Text = ">>";
            this.btnPageNext.UseVisualStyleBackColor = true;
            this.btnPageNext.Click += new System.EventHandler(this.btnPageNext_Click);
            // 
            // btnPageBack
            // 
            this.btnPageBack.Location = new System.Drawing.Point(12, 7);
            this.btnPageBack.Name = "btnPageBack";
            this.btnPageBack.Size = new System.Drawing.Size(86, 34);
            this.btnPageBack.TabIndex = 2;
            this.btnPageBack.Text = "<<";
            this.btnPageBack.UseVisualStyleBackColor = true;
            this.btnPageBack.Click += new System.EventHandler(this.btnPageBack_Click);
            // 
            // btnSearchBack
            // 
            this.btnSearchBack.Location = new System.Drawing.Point(12, 48);
            this.btnSearchBack.Name = "btnSearchBack";
            this.btnSearchBack.Size = new System.Drawing.Size(86, 34);
            this.btnSearchBack.TabIndex = 11;
            this.btnSearchBack.Text = "<<検索";
            this.btnSearchBack.UseVisualStyleBackColor = true;
            this.btnSearchBack.Click += new System.EventHandler(this.btnSearchBack_Click);
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.Location = new System.Drawing.Point(398, 48);
            this.btnSearchNext.Name = "btnSearchNext";
            this.btnSearchNext.Size = new System.Drawing.Size(86, 34);
            this.btnSearchNext.TabIndex = 12;
            this.btnSearchNext.Text = "検索>>";
            this.btnSearchNext.UseVisualStyleBackColor = true;
            this.btnSearchNext.Click += new System.EventHandler(this.btnSearchNext_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "ページ";
            // 
            // lblPageCountAll
            // 
            this.lblPageCountAll.AutoSize = true;
            this.lblPageCountAll.Location = new System.Drawing.Point(213, 15);
            this.lblPageCountAll.Name = "lblPageCountAll";
            this.lblPageCountAll.Size = new System.Drawing.Size(45, 19);
            this.lblPageCountAll.TabIndex = 0;
            this.lblPageCountAll.Text = "0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "/";
            // 
            // lblNameList
            // 
            this.lblNameList.AutoSize = true;
            this.lblNameList.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.lblNameList.Location = new System.Drawing.Point(100, 125);
            this.lblNameList.Name = "lblNameList";
            this.lblNameList.Size = new System.Drawing.Size(69, 20);
            this.lblNameList.TabIndex = 0;
            this.lblNameList.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label4.Location = new System.Drawing.Point(12, 575);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "目標：";
            // 
            // lblGoalPage
            // 
            this.lblGoalPage.AutoSize = true;
            this.lblGoalPage.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.lblGoalPage.Location = new System.Drawing.Point(74, 575);
            this.lblGoalPage.Name = "lblGoalPage";
            this.lblGoalPage.Size = new System.Drawing.Size(60, 25);
            this.lblGoalPage.TabIndex = 4;
            this.lblGoalPage.Text = "0000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label2.Location = new System.Drawing.Point(27, 604);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "あと";
            // 
            // lblLastPage
            // 
            this.lblLastPage.AutoSize = true;
            this.lblLastPage.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.lblLastPage.Location = new System.Drawing.Point(74, 604);
            this.lblLastPage.Name = "lblLastPage";
            this.lblLastPage.Size = new System.Drawing.Size(60, 25);
            this.lblLastPage.TabIndex = 4;
            this.lblLastPage.Text = "0000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label6.Location = new System.Drawing.Point(130, 604);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "ページめくる";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label7.Location = new System.Drawing.Point(130, 575);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "ページ";
            // 
            // lblEnchName
            // 
            this.lblEnchName.AutoSize = true;
            this.lblEnchName.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.lblEnchName.Location = new System.Drawing.Point(212, 575);
            this.lblEnchName.Name = "lblEnchName";
            this.lblEnchName.Size = new System.Drawing.Size(0, 25);
            this.lblEnchName.TabIndex = 4;
            this.lblEnchName.Click += new System.EventHandler(this.label5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 10F);
            this.label5.Location = new System.Drawing.Point(13, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "検索結果：";
            // 
            // lblSearchTarget
            // 
            this.lblSearchTarget.AutoSize = true;
            this.lblSearchTarget.Font = new System.Drawing.Font("Meiryo UI", 10F);
            this.lblSearchTarget.Location = new System.Drawing.Point(100, 85);
            this.lblSearchTarget.Name = "lblSearchTarget";
            this.lblSearchTarget.Size = new System.Drawing.Size(0, 22);
            this.lblSearchTarget.TabIndex = 4;
            // 
            // ScrollOfNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 653);
            this.Controls.Add(this.lblLastPage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblGoalPage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEnchName);
            this.Controls.Add(this.lblSearchTarget);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnPageNext);
            this.Controls.Add(this.btnPageBack);
            this.Controls.Add(this.btnSearchBack);
            this.Controls.Add(this.btnSearchNext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPageCountAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNameList);
            this.Name = "ScrollOfNameForm";
            this.Text = "*名前*の巻物";
            this.Load += new System.EventHandler(this.ScrollOfNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNameList;
        private System.Windows.Forms.Button btnSearchNext;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPageCountAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchBack;
        private System.Windows.Forms.Button btnPageBack;
        private System.Windows.Forms.Button btnPageNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGoalPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEnchName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSearchTarget;
    }
}