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
    public partial class Upper15WeaponSelectEnchantForm : BaseForm
    {
        public Upper15WeaponSelectEnchantForm()
        {
            InitializeComponent();
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            _backFlag = true;
            this.Close();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if(!Validate())
            {
                var message = 
@"現在の生き武器レベルは15以上、付けるエンチャントの個数は1以上を入力してください。
※レベル15までの育成は最初の画面に戻り「生き武器（～Lv14）」から行ってください。";

                MessageBox.Show(message);

                return;
            }

            var currentLevel = decimal.ToInt32(nudLevel.Value);

            var maxLevel = currentLevel + decimal.ToInt32(nudSigCount.Value);

            var enchant = ecbMain.GetEnchant();

            var result = new Upper15Calc(currentLevel, maxLevel, enchant, decimal.ToInt32(nudPageLimit.Value));

            var form = new Upper15ResultForm(this, result);

            this.Hide();

            form.ShowDialog();

            if (Util.IsAppClosed)
            {
                Close();
                return;
            }

            this.Show();



        }

        private void Upper15WeaponSelectEnchantForm_Load(object sender, EventArgs e)
        {
            nudPageLimit.Value = Lists.GetLastPage();
            lblStartLevel.Text = "";
            lblGoalLevel.Text = "";
        }

        //入力値をチェック
        private bool Validate()
        {
            var level = decimal.ToInt32(nudLevel.Value);
            if (!(level >= 15))
            {
                return false;
            }
            var count = decimal.ToInt32(nudSigCount.Value);
            if (!(count >= 1))
            {
                return false;
            }

            return true;


        }

        private void nudLevel_ValueChanged(object sender, EventArgs e)
        {
            UpdateLevel();
        }

        private void nudSigCount_ValueChanged(object sender, EventArgs e)
        {
            UpdateLevel();
        }

        private void UpdateLevel()
        {
            if (!Validate())
            {
                lblStartLevel.Text = "";
                lblGoalLevel.Text = "";
                return;
            }
            var level = decimal.ToInt32(nudLevel.Value);
            var count = decimal.ToInt32(nudSigCount.Value);

            lblStartLevel.Text = level.ToString();
            lblGoalLevel.Text = $"{level + count}";




        }

        private void btnUnlimit_Click(object sender, EventArgs e)
        {
            nudPageLimit.Value = Lists.GetLastPage();
        }

        private void Upper16WeaponSelectEnchantForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_backFlag)
            {
                Util.ExitApplication();
            }
        }
    }
}
