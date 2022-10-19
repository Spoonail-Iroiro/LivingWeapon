namespace UISandbox_LivingWeapon
{
    partial class StartupForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDGVForm = new System.Windows.Forms.Button();
            this.txtSigVersion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDGVForm
            // 
            this.btnDGVForm.Location = new System.Drawing.Point(12, 96);
            this.btnDGVForm.Name = "btnDGVForm";
            this.btnDGVForm.Size = new System.Drawing.Size(100, 23);
            this.btnDGVForm.TabIndex = 1;
            this.btnDGVForm.Text = "DGVForm";
            this.btnDGVForm.UseVisualStyleBackColor = true;
            this.btnDGVForm.Click += new System.EventHandler(this.btnDGVForm_Click);
            // 
            // txtSigVersion
            // 
            this.txtSigVersion.Location = new System.Drawing.Point(12, 12);
            this.txtSigVersion.Name = "txtSigVersion";
            this.txtSigVersion.Size = new System.Drawing.Size(338, 22);
            this.txtSigVersion.TabIndex = 2;
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 291);
            this.Controls.Add(this.txtSigVersion);
            this.Controls.Add(this.btnDGVForm);
            this.Name = "StartupForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartupForm_FormClosing);
            this.Load += new System.EventHandler(this.StartupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDGVForm;
        private System.Windows.Forms.TextBox txtSigVersion;
    }
}

