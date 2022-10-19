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
using System.IO;

namespace LivingWeapon
{
    public partial class SignatureCombinationResultForm : BaseForm
    {
        private Form _previousForm;
        Dictionary<string, Form> _subForms;

        SignatureSearch _searched;


        #region コンストラクタとロード

        public SignatureCombinationResultForm()
        {
            InitializeComponent();
        }

        //この前でgoalLevel - startLevel(付けられる個数)がselectedEnchantsの個数と合っていることを保証（Select→Confirmの間）
        public SignatureCombinationResultForm(Form previous, SignatureSearch searchResult) : this()
        {
            _previousForm = previous;
            _searched = searchResult;

            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
        }

        private void SignatureCombinationResultForm_Load(object sender, EventArgs e)
        {
            if(!_searched.searchFinished)
            {
                throw new Exception("探索が終了していません");
            }

            //探索結果を取得
            var result = _searched.Result;

            txtMain.Text = BasicSearchResultFormatter.GetResultStr(_searched);

            _subForms = new Dictionary<string, Form>();

            {
                var table = BasicSearchResultFormatter.GetResultTable(_searched);

                var form = new DGVForm(table, true);

                form.Hide();

                _subForms["ResultAsList"] = form;
            }

            {
                var sigList = result.Select(sSig => sSig.EnchantingSignature).ToList();

                var form = new LvEnchantingSignatureForm(sigList, _searched.StartLevel);

                form.Hide();

                _subForms["LvEnchantingSignature"] = form;
            }

            {
                var tableReal = _searched.SelectedEnchants.GetEnchantingSignatureList();
                var tableIdeal = _searched.SelectedEnchants.GetIdealEnchantingSignatureList();

                var form = new ShowEnchantInfoForm(tableIdeal, tableReal, _searched.RetryN);

                form.Hide();

                _subForms["EnchantInfo"] = form;

            }


        }

        #endregion

        #region イベントハンドラ
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            _subForms["ResultAsList"].Show();
        }

        private void btnSaveAsFile_Click(object sender, EventArgs e)
        {
            var content = BasicSearchResultFormatter.GetResultStr(_searched);

            var sfd = new SaveFileDialog();

            sfd.FileName = "result.txt";
            sfd.Filter = "テキストファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";

            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filepath = sfd.FileName;

                    using (var fs = new StreamWriter(filepath, false, Encoding.GetEncoding("Shift_JIS")))
                    {
                        fs.Write(content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("保存に失敗しました");
            }
        }

        private void btnEnchantInfo_Click(object sender, EventArgs e)
        {
            _subForms["EnchantInfo"].Show();
        }

        private void btnEnchLv_Click(object sender, EventArgs e)
        {
            _subForms["LvEnchantingSignature"].Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Util.ExitApplication();

            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _backFlag = true;

            Close();
        }

        private void SignatureCombinationResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_backFlag)
            {
                Util.ExitApplication();
            }

            foreach(var form in _subForms.Values)
            {
                form.Close();
            }

        }

        #endregion

        private void chkFont_CheckedChanged(object sender, EventArgs e)
        {
            var font = chkFont.Checked ? new Font("ＭＳ ゴシック", 10) : new Font("Meiryo UI", 9);
            txtMain.Font = font;
        }
    }

}
