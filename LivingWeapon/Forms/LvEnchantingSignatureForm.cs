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
    public partial class LvEnchantingSignatureForm : BaseForm
    {

        public LvEnchantingSignatureForm()
        {
            InitializeComponent();
        }

        internal LvEnchantingSignatureForm(List<Signature> lvEnchantingSignature, int startLevel) : this()
        {
            SetDGV(dgvMain);
            dgvMain.AutoGenerateColumns = false;
            dgvMain.DataSource = lvEnchantingSignature;

            var table = new DataTable();
            table.Columns.Add("Lv", typeof(int));
            table.Columns.Add("LvUp", typeof(int));
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("Page", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("EnchantStr", typeof(string));
            table.Columns.Add("Value", typeof(int));

            int index = 0;
            foreach (var sig in lvEnchantingSignature)
            {
                table.Rows.Add(
                    startLevel + index,
                    startLevel + index + 1,
                    sig.No,
                    sig.Page,
                    sig.Name,
                    sig.EnchantStr,
                    sig.Value                    
                    );

                ++index;
            }

            dgvMain.DataSource = table;

        }

        private void SetDGV(DataGridView dgv)
        {
            dgv.Columns.Clear();

            var settings = new[]
            {
                new {HeaderText = "Lv", DataPropertyName = "Lv"},
                new {HeaderText = "LvUp", DataPropertyName = "LvUp"},
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
            /*

            //DataGridView1の行ヘッダーに行番号を表示する
            for (int i = 0; i < dgvMain.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }*/
        }

        private void LvEnchantingSignatureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();

        }
    }
}
