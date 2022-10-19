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
using LivingWeapon.MyExt;

namespace LivingWeapon
{
    public partial class EvilWeaponSettingForm : BaseForm
    {
        public EvilWeaponSettingForm()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtSelect1.Text == "" || txtSelect2.Text == "")
            {
                MessageBox.Show("選択肢を2つ入力してください");
                return;
            }

            if (txtSelect1.Text == txtSelect2.Text)
            {
                MessageBox.Show("異なる選択肢を2つ入力してください");
                return;
            }

            var backOffset1 = txtSelect1.Text[0] - 'a';
            var backOffset2 = txtSelect2.Text[0] - 'a';

            var ecalc = new EvilWeaponCalc(int.Parse(txtID.Text), txtSelect1.Text[0], txtSelect2.Text[0], (int) nudLv.Value);

            //Test
            //txtTest.Text = ecalc.GetResultStr();

            //次フォーム
            var form = new EvilWeaponResultForm(this, ecalc);

            this.Hide();

            form.ShowDialog();

            if (Util.IsAppClosed)
            {
                Close();
                return;
            }


            this.Show();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            _backFlag = true;

            Close();
        }

        private void btnEnchOK_Click(object sender, EventArgs e)
        {
            var no = 0;

            try
            {
                var id = int.Parse(txtID.Text);

                no = Lists.GetNoFromID(id);

                if (no < 1)
                {
                    throw new ArgumentException("IDの範囲が不正です：50500より小さい数字を入力していませんか？");
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show("入力が数値ではありません");
                return;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var sigList = Lists.SigList;

            var targetEnchSig = sigList.GetSignature(no);

            lblSignature.Text = "『{0}』".Args(targetEnchSig.Name);

            lblEnchant.Text = targetEnchSig.EnchantStr+ ", 強度" + targetEnchSig.Value.ToString();

        }
    }

    public class EvilWeaponCalc
    {
        public int StartID { get; set; }
        public char OffsetChar1 { get; set; }
        public char OffsetChar2 { get; set; }

        public Signature EnchSig
        {
            get
            {
                return Lists.SigList.GetSignature(Lists.GetNoFromID(StartID));
            }
        }

        public List<Signature> Result { get; set; }

        public EvilWeaponCalc(int startID, char offsetChar1, char offsetChar2, int count)
        {
            StartID = startID;
            OffsetChar1 = offsetChar1;
            OffsetChar2 = offsetChar2;

            calc(count);
        }

        public void calc(int count)
        {
            var backOffset1 = OffsetChar1 - 'a';
            var backOffset2 = OffsetChar2 - 'a';

            var origNo = Lists.GetNoFromID(StartID);

            Result = new List<Signature>();

            foreach (var i in Enumerable.Range(0, count))
            {
                var sig1 = Lists.SigList.GetSignature(origNo - backOffset1 - 10 * i);
                var sig2 = Lists.SigList.GetSignature(origNo - backOffset2 - 10 * i);

                Result.Add(sig1.Selectable ? sig1 : sig2);
            }

            //txtTest.Text = resultList.Select((sig, idx) => GetSigStr(sig, idx + 1)).JoinS("\r\n");
        }

        private string GetSigStr(Signature sig, int lv)
        {
            var selectChar = sig.ChoiceLabelCharOnScrollOfName;

            return "Lv{6,4},{3,5}ページ,[{0}] {4},{5},{1}(No),{2}(ID)".Args(
                selectChar,
                sig.No,
                Lists.GetIDFromNo(sig.No),
                sig.Page,
                sig.Name,
                EnchSig.EnchantStrWithoutValue,
                lv,
                lv + 1
                );
        }

        public string GetResultStr()
        {
            return Result.Select((sig, idx) => GetSigStr(sig, idx + 1)).JoinS("\r\n");
        }

        public DataTable GetResultTable()
        {
            var table = new DataTable();

            table.Columns.Add(new DataColumn("Lv", typeof(int)));
            table.Columns.Add(new DataColumn("ページ", typeof(int)));
            table.Columns.Add(new DataColumn("選択肢", typeof(string)));
            table.Columns.Add(new DataColumn("銘", typeof(string)));
            table.Columns.Add(new DataColumn("選択するエンチャント", typeof(string)));
            table.Columns.Add(new DataColumn("No", typeof(int)));
            table.Columns.Add(new DataColumn("ID", typeof(int)));

            var rows = Result.Select((sig, index) =>
            {
                var level = index + 1;

                return new object[]
                {
                    level,
                    sig.Page,
                    "[{0}]".Args((char)('a' + (sig.No % 17))),
                    sig.Name,
                    EnchSig.EnchantStrWithoutValue,
                    sig.No,
                    Lists.GetIDFromNo(sig.No)
                };
            });

            foreach (var row in rows)
            {
                table.Rows.Add(row);
            }


            return table;
        }

    }
}
