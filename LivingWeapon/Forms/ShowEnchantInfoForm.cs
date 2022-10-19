using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingWeapon
{
    public partial class ShowEnchantInfoForm : BaseForm
    {
        public ShowEnchantInfoForm()
        {
            InitializeComponent();
        }

        public ShowEnchantInfoForm(List<Signature> enchSigIdeal, List<Signature> enchSigReal, int retryN):this()
        {
            SetDGV(dgvIdeal);
            SetDGV(dgvReal);

            dgvIdeal.AutoGenerateColumns = false;
            dgvReal.AutoGenerateColumns = false;

            dgvIdeal.DataSource = enchSigIdeal;
            dgvReal.DataSource = enchSigReal;

            lblRetryN.Text = retryN.ToString();

            if (retryN != 0) lblIdeal.Visible = false;
        }

        private void SetDGV(DataGridView dgv)
        {
            dgv.Columns.Clear();

            var settings = new[]
            {
                new {HeaderText = "No", DataPropertyName = "No"},
                new {HeaderText = "ページ", DataPropertyName = "Page"},
                new {HeaderText = "（銘）", DataPropertyName = "Name"},
                new {HeaderText = "エンチャント", DataPropertyName = "EnchantStr"},
                new {HeaderText = "強度", DataPropertyName = "Value"}
            };

            foreach (var setting in settings)
            {
                var column = new DataGridViewTextBoxColumn();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.HeaderText = setting.HeaderText;
                column.DataPropertyName = setting.DataPropertyName;
                if (setting.DataPropertyName == "Name")
                {
                    var style = column.DefaultCellStyle;
                    style.ForeColor = Color.Gray;
                    column.DefaultCellStyle = style;
                }

                dgv.Columns.Add(column);
            }

            //DataGridView1の行ヘッダーに行番号を表示する
            for (int i = 0; i < dgvIdeal.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void ShowEnchantInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();

        }
    }
}
