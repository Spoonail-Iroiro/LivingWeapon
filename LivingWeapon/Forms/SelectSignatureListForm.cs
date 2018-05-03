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

                lblLoading.Text = "読み込み中…";

                Refresh();

                try
                {
                    Lists.Init(version, wType, chkFeated.Checked);
                }
                catch
                {
                    MessageBox.Show("銘リストファイルが見つかりませんでした。\r\n※ver1.22のフィート無し銘リストはありません");

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


    }
}
