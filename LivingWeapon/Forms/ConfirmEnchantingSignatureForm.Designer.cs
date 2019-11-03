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
            this.btnChangeMode = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblExplain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSigs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChangeMode
            // 
            this.btnChangeMode.Location = new System.Drawing.Point(518, 12);
            this.btnChangeMode.Name = "btnChangeMode";
            this.btnChangeMode.Size = new System.Drawing.Size(138, 34);
            this.btnChangeMode.TabIndex = 1;
            this.btnChangeMode.Text = "詳細表示";
            this.btnChangeMode.UseVisualStyleBackColor = true;
            this.btnChangeMode.Click += new System.EventHandler(this.btnChangeMode_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnBack.Location = new System.Drawing.Point(17, 621);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(138, 34);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "戻る";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.btnNext.Location = new System.Drawing.Point(523, 621);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(138, 34);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "次へ";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.lblExplain.Location = new System.Drawing.Point(13, 43);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(39, 19);
            this.lblExplain.TabIndex = 3;
            this.lblExplain.Text = "説明";
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
            // dgvSigs
            // 
            this.dgvSigs.AllowUserToAddRows = false;
            this.dgvSigs.AllowUserToDeleteRows = false;
            this.dgvSigs.AllowUserToResizeColumns = false;
            this.dgvSigs.AllowUserToResizeRows = false;
            this.dgvSigs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSigs.Location = new System.Drawing.Point(17, 214);
            this.dgvSigs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSigs.Name = "dgvSigs";
            this.dgvSigs.ReadOnly = true;
            this.dgvSigs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvSigs.RowTemplate.Height = 24;
            this.dgvSigs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSigs.Size = new System.Drawing.Size(644, 400);
            this.dgvSigs.TabIndex = 2;
            // 
            // ConfirmEnchantingSignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 666);
            this.Controls.Add(this.btnChangeMode);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSigs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfirmEnchantingSignatureForm";
            this.Text = "付与エンチャント確認";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfirmEnchantingSignatureForm_FormClosing);
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
        private System.Windows.Forms.Label lblExplain;
    }
}