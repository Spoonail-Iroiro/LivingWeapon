namespace LivingWeapon
{
    partial class EnchantCombobox
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxSkill = new System.Windows.Forms.ComboBox();
            this.cbxEnchant = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxSkill
            // 
            this.cbxSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSkill.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.cbxSkill.FormattingEnabled = true;
            this.cbxSkill.Location = new System.Drawing.Point(0, 33);
            this.cbxSkill.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxSkill.Name = "cbxSkill";
            this.cbxSkill.Size = new System.Drawing.Size(114, 27);
            this.cbxSkill.TabIndex = 2;
            // 
            // cbxEnchant
            // 
            this.cbxEnchant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEnchant.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.cbxEnchant.FormattingEnabled = true;
            this.cbxEnchant.Location = new System.Drawing.Point(0, 0);
            this.cbxEnchant.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxEnchant.Name = "cbxEnchant";
            this.cbxEnchant.Size = new System.Drawing.Size(277, 27);
            this.cbxEnchant.TabIndex = 1;
            this.cbxEnchant.SelectedIndexChanged += new System.EventHandler(this.cbxEnchant_SelectedIndexChanged);
            // 
            // EnchantCombobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbxSkill);
            this.Controls.Add(this.cbxEnchant);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EnchantCombobox";
            this.Size = new System.Drawing.Size(330, 61);
            this.Load += new System.EventHandler(this.EnchantCombobox_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxSkill;
        private System.Windows.Forms.ComboBox cbxEnchant;
    }
}
