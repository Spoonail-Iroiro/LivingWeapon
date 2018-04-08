namespace LivingWeapon
{
    partial class SelectSigForm
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
            this.txtIn = new System.Windows.Forms.TextBox();
            this.txtMain = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxEnchant = new System.Windows.Forms.ComboBox();
            this.cbxAdd = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtIn
            // 
            this.txtIn.Font = new System.Drawing.Font("Ricty", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtIn.Location = new System.Drawing.Point(172, 50);
            this.txtIn.Name = "txtIn";
            this.txtIn.Size = new System.Drawing.Size(169, 28);
            this.txtIn.TabIndex = 8;
            // 
            // txtMain
            // 
            this.txtMain.Location = new System.Drawing.Point(12, 84);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(482, 494);
            this.txtMain.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 66);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxEnchant
            // 
            this.cbxEnchant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEnchant.FormattingEnabled = true;
            this.cbxEnchant.Location = new System.Drawing.Point(173, 12);
            this.cbxEnchant.Name = "cbxEnchant";
            this.cbxEnchant.Size = new System.Drawing.Size(383, 23);
            this.cbxEnchant.TabIndex = 9;
            this.cbxEnchant.SelectedIndexChanged += new System.EventHandler(this.cbxEnchant_SelectedIndexChanged);
            // 
            // cbxAdd
            // 
            this.cbxAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAdd.FormattingEnabled = true;
            this.cbxAdd.Location = new System.Drawing.Point(434, 50);
            this.cbxAdd.Name = "cbxAdd";
            this.cbxAdd.Size = new System.Drawing.Size(122, 23);
            this.cbxAdd.TabIndex = 9;
            // 
            // SelectSigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 631);
            this.Controls.Add(this.cbxAdd);
            this.Controls.Add(this.cbxEnchant);
            this.Controls.Add(this.txtIn);
            this.Controls.Add(this.txtMain);
            this.Controls.Add(this.button1);
            this.Name = "SelectSigForm";
            this.Text = "SelectSigForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIn;
        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbxEnchant;
        private System.Windows.Forms.ComboBox cbxAdd;
    }
}