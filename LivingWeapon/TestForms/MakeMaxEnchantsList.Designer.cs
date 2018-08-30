namespace LivingWeapon.TestForms
{
    partial class MakeMaxEnchantsList
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
            this.txtMain = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn100000p = new System.Windows.Forms.Button();
            this.txtSearchStr = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMain
            // 
            this.txtMain.Location = new System.Drawing.Point(12, 48);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMain.Size = new System.Drawing.Size(819, 500);
            this.txtMain.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn100000p
            // 
            this.btn100000p.Location = new System.Drawing.Point(203, 12);
            this.btn100000p.Name = "btn100000p";
            this.btn100000p.Size = new System.Drawing.Size(163, 30);
            this.btn100000p.TabIndex = 1;
            this.btn100000p.Text = "100000p";
            this.btn100000p.UseVisualStyleBackColor = true;
            this.btn100000p.Click += new System.EventHandler(this.btn100000p_Click);
            // 
            // txtSearchStr
            // 
            this.txtSearchStr.Location = new System.Drawing.Point(837, 48);
            this.txtSearchStr.Multiline = true;
            this.txtSearchStr.Name = "txtSearchStr";
            this.txtSearchStr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSearchStr.Size = new System.Drawing.Size(335, 500);
            this.txtSearchStr.TabIndex = 0;
            // 
            // MakeMaxEnchantsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 560);
            this.Controls.Add(this.btn100000p);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSearchStr);
            this.Controls.Add(this.txtMain);
            this.Name = "MakeMaxEnchantsList";
            this.Text = "MakeMaxEnchantsList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn100000p;
        private System.Windows.Forms.TextBox txtSearchStr;
    }
}