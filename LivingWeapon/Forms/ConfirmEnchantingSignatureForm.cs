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
    public partial class ConfirmEnchantingSignatureForm : BaseForm
    {
        Form _previousForm;
        int _startLevel;
        int _goalLevel;
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

        internal ConfirmEnchantingSignatureForm(Form previous, int startLevel, int goalLevel, SelectedEnchants selectedEnchants)
        {
            InitializeComponent();

            _previousForm = previous;
            _startLevel = startLevel;
            _goalLevel = goalLevel;
            _selectedEnchants = selectedEnchants;
            _mode = Mode.Simple;

            dgvSigs.AutoGenerateColumns = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _previousForm.Show();

            _backFlag = true;

            this.Close();
        }

        private void ConfirmEnchantingSignatureForm_Load(object sender, EventArgs e)
        {
            _sigs = _selectedEnchants.GetEnchantingSignatureList();

            _bs = new BindingSource(_sigs, "");

            dgvSigs.DataSource = _bs;

            SetMode(Mode.Simple);

        }

        private void SetExplain(Mode mode)
        {
            var text =
@"Lv{0}→Lv{1}　付与エンチャント数：{2}

※エンチャント表示は、重ねがけ時の強度半分を考慮していません。
※探索しても血吸いを回避できる組み合わせが見つからない場合はこれより強度が低くなることが
　あります（探索後に最終結果表示）
".Args(_startLevel, _goalLevel, (_goalLevel - _startLevel));

            if (mode == Mode.More)
            {
                text +=
@"以下は銘リストの中のどこのエンチャントを採用しているかを確認するための情報です。
※実際に名前の巻物で選択する銘と順番はこの後探索するため、同じ銘が並んでいる・選択不能の銘がある
　などの状態でも問題ありません。
";

            }


            lblExplain.Text = text;
        }

        private void SetMode(Mode mode)
        {
            _mode = mode;

            SetExplain(mode);

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            var start = _startLevel;
            var goal = _goalLevel;

            var form = new SignatureCombinationResultForm(this, start, goal, _selectedEnchants);

            this.Hide();

            form.ShowDialog();

            if (Util.IsAppClosed)
            {
                Close();
                return;
            }

            this.Show();

        }

        private void ConfirmEnchantingSignatureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_backFlag)
            {
                Util.ExitApplication();
            }
        }
    }
}
