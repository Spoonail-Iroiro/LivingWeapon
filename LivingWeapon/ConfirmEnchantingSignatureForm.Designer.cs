namespace LivingWeapon
{
    partial class ConfirmEnchantingSignatureForm
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
            this.dgvSigs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnChangeMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSigs
            // 
            this.dgvSigs.AllowUserToAddRows = false;
            this.dgvSigs.AllowUserToDeleteRows = false;
            this.dgvSigs.AllowUserToResizeColumns = false;
            this.dgvSigs.AllowUserToResizeRows = false;
            this.dgvSigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSigs.Location = new System.Drawing.Point(12, 49);
            this.dgvSigs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSigs.Name = "dgvSigs";
            this.dgvSigs.ReadOnly = true;
            this.dgvSigs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvSigs.RowTemplate.Height = 24;
            this.dgvSigs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSigs.Size = new System.Drawing.Size(644, 374);
            this.dgvSigs.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "以下のエンチャントが付きます。よろしいですか？";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnNext.Location = new System.Drawing.Point(518, 430);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(138, 34);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "次へ";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnBack.Location = new System.Drawing.Point(12, 430);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(138, 34);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnChangeMode
            // 
            this.btnChangeMode.Location = new System.Drawing.Point(518, 8);
            this.btnChangeMode.Name = "btnChangeMode";
            this.btnChangeMode.Size = new System.Drawing.Size(138, 34);
            this.btnChangeMode.TabIndex = 6;
            this.btnChangeMode.Text = "詳細表示";
            this.btnChangeMode.UseVisualStyleBackColor = true;
            this.btnChangeMode.Click += new System.EventHandler(this.btnChangeMode_Click);
            // 
            // ConfirmEnchantingSignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 476);
            this.Controls.Add(this.btnChangeMode);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSigs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfirmEnchantingSignatureForm";
            this.Text = "ConfirmEnchantingSignatureForm";
            this.Load += new System.EventHandler(this.ConfirmEnchantingSignatureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSigs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnChangeMode;
    }
}