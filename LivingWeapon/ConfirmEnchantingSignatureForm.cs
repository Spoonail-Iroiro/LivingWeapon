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
    public partial class ConfirmEnchantingSignatureForm : BaseForm
    {
        Form _previousForm;
        SelectedEnchants _selectedEnchants;
        Mode _mode;
        List<Signature> _sigs;
        BindingSource _bs;

        enum Mode
        {
            Simple,
            More
        }

        internal ConfirmEnchantingSignatureForm()
        {
            InitializeComponent();
        }

        internal ConfirmEnchantingSignatureForm(Form previous, SelectedEnchants selectedEnchants)
        {
            InitializeComponent();

            _previousForm = previous;
            _selectedEnchants = selectedEnchants;
            _mode = Mode.Simple;

            dgvSigs.AutoGenerateColumns = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _previousForm.Show();

            this.Close();
        }

        private void ConfirmEnchantingSignatureForm_Load(object sender, EventArgs e)
        {
            _sigs = _selectedEnchants.GetEnchantingSignatureList();

            _bs = new BindingSource(_sigs, "");

            dgvSigs.DataSource = _bs;

            SetMode(Mode.Simple);

        }

        private void SetMode(Mode mode)
        {
            _mode = mode;

            dgvSigs.Columns.Clear();

            var settings = new[]
            {
                new {HeaderText = "No", DataPropertyName = "No"},
                new {HeaderText = "ページ", DataPropertyName = "Page"},
                new {HeaderText = "（銘）", DataPropertyName = "Name"},
                new {HeaderText = "エンチャント", DataPropertyName = "EnchantStr"},
                new {HeaderText = "強度", DataPropertyName = "Value"}
            };

            /*
            var column = new DataGridViewColumn();
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column.HeaderText = "エンチャント";
            column.DataPropertyName ="EnchantStr"
            */

            //dgvSigs.Columns.Add()


            switch (mode)
            {
                case Mode.Simple:
                    {
                        var setting = settings[3];
                        var column = new DataGridViewTextBoxColumn();
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        column.HeaderText = setting.HeaderText;
                        column.DataPropertyName = setting.DataPropertyName;
                        dgvSigs.Columns.Add(column);
                    }
                    break;
                case Mode.More:
                    foreach(var setting in settings)
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

                        dgvSigs.Columns.Add(column);
                    }
                    break;
                default:
                    break;
            }

            _bs.DataSource = _sigs;

            _bs.ResetBindings(true);

            //DataGridView1の行ヘッダーに行番号を表示する
            for (int i = 0; i < dgvSigs.Rows.Count; i++)
            {
                dgvSigs.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void btnChangeMode_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case Mode.Simple:
                    SetMode(Mode.More);
                    btnChangeMode.Text = "簡易表示";
                    break;
                case Mode.More:
                    SetMode(Mode.Simple);
                    btnChangeMode.Text = "詳細表示";
                    break;
                default:
                    break;
            }
        }
    }
}
