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
    public partial class SelectEnchantsForm : BaseForm
    {
        List<Enchant> _table;
        BindingSource _bs;

        public SelectEnchantsForm()
        {
            InitializeComponent();

            ecbEnchant.cbxEnchantSelectedIndexChanged += ecbEnchant_cbxEnchantSelectedIndexChanged;

            _table = new List<Enchant>();
           
            dgvEnchants.AutoGenerateColumns = false;

            _bs = new BindingSource(_table, "");

            dgvEnchants.DataSource = _bs;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ecbEnchant_cbxEnchantSelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddAll.Visible = ecbEnchant.HasSkills;

            if (ecbEnchant.GetEnchant().Type.ID == 3) btnAddAll.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var enchant = ecbEnchant.GetEnchant();

            _table.Add(enchant);

            ReloadTable();
        }

        private void dgvEnchants_RowsChanged(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGridView1の行ヘッダーに行番号を表示する
            for (int i = 0; i < dgvEnchants.Rows.Count; i++)
            {
                dgvEnchants.Rows[i].HeaderCell.Value = (i+1).ToString();
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var enchants = ecbEnchant.GetAllEnchants();

            _table.AddRange(enchants);

            ReloadTable();
        }

        private void ReloadTable()
        {
            _table = _table.OrderBy(ench => ench.Type.ID).ThenBy(ench => ench.Skill.ID).ToList();

            _bs.DataSource = _table;

            _bs.ResetBindings(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedIndex = dgvEnchants.CurrentCellAddress.Y;

            if (selectedIndex < 0) return;

            _table.RemoveAt(selectedIndex);

            ReloadTable();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var selectedIndex = dgvEnchants.CurrentCellAddress.Y;

            if (selectedIndex < 0) return;

            _table.Add(_table[selectedIndex]);

            ReloadTable();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void nudStart_ValueChanged(object sender, EventArgs e)
        {
            var count = nudGoal.Value - nudStart.Value;

            lblEnchantCount.Text = count.ToString();
        }

        private void nudGoal_ValueChanged(object sender, EventArgs e)
        {
            nudStart_ValueChanged(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //色々☑
            //エンチャント個数との整合性
            //銘リストに存在しないエンチャチェック

            var selectedEnchants = new SelectedEnchants();

            foreach (var enchant in _table)
            {
                selectedEnchants.Add(enchant);
            }

            var form = new ConfirmEnchantingSignatureForm(this, selectedEnchants);

            form.Show();

            this.Hide();

            //var result = _table.Select(ench => Lists.SigList.SearchByEnchant(ench)).ToList();
        }
    }
}
