using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivingWeapon.MyExt;

namespace LivingWeapon
{
    public partial class SelectEnchantsForm : BaseForm
    {
        List<Enchant> _table;
        BindingSource _bs;
        Form _nsForm;

        public SelectEnchantsForm()
        {
            InitializeComponent();

            ecbEnchant.cbxEnchantSelectedIndexChanged += ecbEnchant_cbxEnchantSelectedIndexChanged;

            _table = new List<Enchant>();

            dgvEnchants.AutoGenerateColumns = false;

            _bs = new BindingSource(_table, "");

            dgvEnchants.DataSource = _bs;

            nudPageLimit.Value = GetLastPage();
        
            if(Lists.SelectedOption == Option.Feat100000p) SetUIFor100000p();

        }

        private void SetUIFor100000p()
        {
            groupBox3.Enabled = false;

            button1.Enabled = false;


        }

        private int GetLastPage()
        {
            //ここでoo100000p意外と分岐
            if (Lists.SelectedOption == Option.Feat100000p)
            {
                return 100000;
            }

            return Lists.SigList.SigList.Last().Page;
        }

        private void ReloadTable()
        {
            _table = _table.OrderBy(ench => ench.Type.ID).ThenBy(ench => ench.Skill.ID).ToList();

            _bs.DataSource = _table;

            _bs.ResetBindings(true);
        }

        #region イベントハンドラ

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

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            var enchants = ecbEnchant.GetAllEnchants();

            _table.AddRange(enchants);

            ReloadTable();
        }

        private void dgvEnchants_RowsChanged(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGridView1の行ヘッダーに行番号を表示する
            for (int i = 0; i < dgvEnchants.Rows.Count; i++)
            {
                dgvEnchants.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
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

        private void nudStart_ValueChanged(object sender, EventArgs e)
        {
            var count = Math.Max(nudGoal.Value - nudStart.Value, 0);

            lblEnchantCount.Text = count.ToString();
        }

        private void nudGoal_ValueChanged(object sender, EventArgs e)
        {
            nudStart_ValueChanged(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var tmp = lblPreparing.Text;

            try
            {
                lblPreparing.Text = "検索準備中…";

                Refresh();

                //色々☑
                //エンチャント個数との整合性
                var enchN = nudGoal.Value - nudStart.Value;

                if (enchN < 0)
                {
                    MessageBox.Show("育成開始・終了レベルの値が正しくありません");
                    return;
                }
                if (_table.Count != enchN)
                {
                    MessageBox.Show("エンチャントを{0}個選択して下さい".Args(enchN));
                    return;
                }

                var selectedEnchants = new SelectedEnchants();

                foreach (var enchant in _table)
                {
                    selectedEnchants.Add(enchant, (int)nudPageLimit.Value);
                }

                var form = new ConfirmEnchantingSignatureForm(this, (int)nudStart.Value, (int)nudGoal.Value, selectedEnchants);

                this.Hide();

                form.ShowDialog();

                if (Util.IsAppClosed)
                {
                    Close();
                    return;
                }


                this.Show();
            }
            finally
            {
                lblPreparing.Text = tmp;
            }


            //var result = _table.Select(ench => Lists.SigList.SearchByEnchant(ench)).ToList();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _backFlag = true;

            Close();
        }


        private void SelectEnchantsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_backFlag)
            {
                Util.ExitApplication();
            }

            if(_nsForm != null)
            {
                _nsForm.Close();
            }
        }

        #endregion

        private void btnUnlimit_Click(object sender, EventArgs e)
        {
            nudPageLimit.Value = Lists.SigList.SigList.Last().Page;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_nsForm != null) _nsForm.Dispose();

            _nsForm = new InputDialog();

            AddOwnedForm(_nsForm);

            _nsForm.Show();
            _nsForm.WindowState = FormWindowState.Normal;
            _nsForm.Activate();
        }
    }
}
