namespace LivingWeapon
{
    partial class ShowEnchantInfoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReal = new System.Windows.Forms.DataGridView();
            this.dgvIdeal = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRetryN = new System.Windows.Forms.Label();
            this.lblIdeal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdeal)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "決定";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label1.Location = new System.Drawing.Point(558, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "効果値最大";
            // 
            // dgvReal
            // 
            this.dgvReal.AllowUserToAddRows = false;
            this.dgvReal.AllowUserToDeleteRows = false;
            this.dgvReal.AllowUserToResizeColumns = false;
            this.dgvReal.AllowUserToResizeRows = false;
            this.dgvReal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReal.Location = new System.Drawing.Point(17, 38);
            this.dgvReal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvReal.Name = "dgvReal";
            this.dgvReal.ReadOnly = true;
            this.dgvReal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvReal.RowTemplate.Height = 24;
            this.dgvReal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReal.Size = new System.Drawing.Size(527, 489);
            this.dgvReal.TabIndex = 3;
            // 
            // dgvIdeal
            // 
            this.dgvIdeal.AllowUserToAddRows = false;
            this.dgvIdeal.AllowUserToDeleteRows = false;
            this.dgvIdeal.AllowUserToResizeColumns = false;
            this.dgvIdeal.AllowUserToResizeRows = false;
            this.dgvIdeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdeal.Location = new System.Drawing.Point(550, 38);
            this.dgvIdeal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvIdeal.Name = "dgvIdeal";
            this.dgvIdeal.ReadOnly = true;
            this.dgvIdeal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvIdeal.RowTemplate.Height = 24;
            this.dgvIdeal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIdeal.Size = new System.Drawing.Size(524, 489);
            this.dgvIdeal.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label3.Location = new System.Drawing.Point(12, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "探索リトライ回数：";
            // 
            // lblRetryN
            // 
            this.lblRetryN.AutoSize = true;
            this.lblRetryN.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.lblRetryN.Location = new System.Drawing.Point(171, 531);
            this.lblRetryN.Name = "lblRetryN";
            this.lblRetryN.Size = new System.Drawing.Size(24, 25);
            this.lblRetryN.TabIndex = 4;
            this.lblRetryN.Text = "n";
            // 
            // lblIdeal
            // 
            this.lblIdeal.AutoSize = true;
            this.lblIdeal.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.lblIdeal.Location = new System.Drawing.Point(201, 531);
            this.lblIdeal.Name = "lblIdeal";
            this.lblIdeal.Size = new System.Drawing.Size(112, 25);
            this.lblIdeal.TabIndex = 4;
            this.lblIdeal.Text = "（理想値）";
            // 
            // ShowEnchantInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 578);
            this.Controls.Add(this.lblIdeal);
            this.Controls.Add(this.lblRetryN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReal);
            this.Controls.Add(this.dgvIdeal);
            this.Name = "ShowEnchantInfoForm";
            this.Text = "エンチャント情報（理想値比較）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowEnchantInfoForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdeal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIdeal;
        private System.Windows.Forms.DataGridView dgvReal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRetryN;
        private System.Windows.Forms.Label lblIdeal;
    }
}