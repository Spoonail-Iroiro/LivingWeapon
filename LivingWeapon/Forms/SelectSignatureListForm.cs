using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivingWeapon.Business;
using LivingWeapon.MyExt;

namespace LivingWeapon
{
    public partial class SelectSignatureListForm : BaseForm
    {
        public SelectSignatureListForm()
        {
            InitializeComponent();
        }

        private bool LoadSignatureList()
        {
            var tmp = lblLoading.Text;

            try
            {

                var version = Version.Ver116fix2b;
                var wType = WeaponType.Melee;

                if (rdb1.Checked)
                {
                    version = Version.Ver116fix2b;
                    wType = WeaponType.Melee;
                }
                else if (rdb2.Checked)
                {
                    version = Version.Ver116fix2b;
                    wType = WeaponType.Ranged;
                }
                else if (rdb3.Checked)
                {
                    version = Version.Ver122;
                    wType = WeaponType.Melee;
                }
                else if (rdb4.Checked)
                {
                    version = Version.Ver122;
                    wType = WeaponType.Ranged;

                }
                else if (rdb5.Checked)
                {
                    version = Version.OO;
                    wType = WeaponType.Melee;

                }
                else if (rdb6.Checked)
                {
                    version = Version.OO;
                    wType = WeaponType.Ranged;

                }
                else if (rdb7.Checked)
                {
                    version = Version.OO;
                    wType = WeaponType.Melee;
                }
                else if (rdb8.Checked)
                {
                    version = Version.OO;
                    wType = WeaponType.Ranged;
                }

                lblLoading.Text = "読み込み中…";

                Refresh();

                try
                {
                    var checkedOO100000p = rdb7.Checked || rdb8.Checked;

                    //ここに100000p用のラジオボタン分岐
                    Option opt = checkedOO100000p ? Option.Feat100000p : (chkFeated.Checked ? Option.Feat : Option.NoFeat);
                    if(checkedOO100000p && !chkFeated.Checked)
                    {
                        //エラー表示
                        throw new SignatureListLoadException();
                    }

                    Lists.Init(version, wType, opt);
                }
                catch (SignatureListLoadException sllex)
                {
                    MessageBox.Show("銘リストファイルが見つかりませんでした。\r\n※ver1.22, ooのフィート無し銘リストはありません");

                    return false;
                }
                catch(Exception ex)
                {
                    var message = new List<String> { "不明なエラーが発生しました。",
                        ex.Message,
                        (ex.InnerException != null ? ex.InnerException.Message : "") }.JoinS("\r\n");

                    MessageBox.Show(message);
                    return false;
                }

            }
            finally
            {
                lblLoading.Text = tmp;
            }

            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var success = LoadSignatureList();

            if (!success) return;

            var form = new SelectEnchantsForm();

            this.Hide();

            form.ShowDialog();

            if (Util.IsAppClosed)
            {
                Close();
                return;
            }

            this.Show();

        }

        private void SelectSignatureListForm_Load(object sender, EventArgs e)
        {

        }

        private void SelectSignatureListForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnTestForm_Click(object sender, EventArgs e)
        {
            var success = LoadSignatureList();

            if (!success) return;

            var form = new TestForms.MakeMaxEnchantsList();

            form.ShowDialog();
        }

        private void btnEvil_Click(object sender, EventArgs e)
        {
            var success = LoadSignatureList();

            if (!success) return;

            var form = new EvilWeaponSettingForm();

            this.Hide();

            form.ShowDialog();

            if (Util.IsAppClosed)
            {
                Close();
                return;
            }

            this.Show();
        }
    }
}
