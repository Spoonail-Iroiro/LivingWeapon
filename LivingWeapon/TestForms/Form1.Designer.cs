namespace LivingWeapon
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtMain = new System.Windows.Forms.TextBox();
            this.txtIn = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEnchant = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnApp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 66);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMain
            // 
            this.txtMain.Location = new System.Drawing.Point(12, 272);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(534, 238);
            this.txtMain.TabIndex = 1;
            // 
            // txtIn
            // 
            this.txtIn.Font = new System.Drawing.Font("Ricty", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtIn.Location = new System.Drawing.Point(377, 238);
            this.txtIn.Name = "txtIn";
            this.txtIn.Size = new System.Drawing.Size(169, 28);
            this.txtIn.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "さまり";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEnchant
            // 
            this.btnEnchant.Location = new System.Drawing.Point(418, 12);
            this.btnEnchant.Name = "btnEnchant";
            this.btnEnchant.Size = new System.Drawing.Size(75, 23);
            this.btnEnchant.TabIndex = 3;
            this.btnEnchant.Text = "エンチャ";
            this.btnEnchant.UseVisualStyleBackColor = true;
            this.btnEnchant.Click += new System.EventHandler(this.btnEnchant_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(499, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "エンチャ選択";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnApp
            // 
            this.btnApp.Location = new System.Drawing.Point(12, 22);
            this.btnApp.Name = "btnApp";
            this.btnApp.Size = new System.Drawing.Size(154, 66);
            this.btnApp.TabIndex = 0;
            this.btnApp.Text = "アプリ起動";
            this.btnApp.UseVisualStyleBackColor = true;
            this.btnApp.Click += new System.EventHandler(this.btnApp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 522);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnEnchant);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtIn);
            this.Controls.Add(this.txtMain);
            this.Controls.Add(this.btnApp);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.TextBox txtIn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEnchant;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnApp;
    }
}

