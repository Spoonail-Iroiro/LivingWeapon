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
    public partial class SelectSigForm : Form
    {
        SignatureList _sigList;
        EnchantTypeList _etList;

        public SelectSigForm()
        {
            InitializeComponent();

            _sigList = Lists.SigList;
            _etList = Lists.ETList;

            cbxEnchant.DisplayMember = "TypeDiscription";
            cbxEnchant.DataSource = _etList.ETList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedEnchant = (EnchantType)cbxEnchant.SelectedValue;

            var sigs = _sigList.SigList.Skip(130).Where(sig => selectedEnchant.IsMatch(sig));

            if(cbxAdd.DataSource != null)
            {
                var selectedSkill = (Skill)cbxAdd.SelectedValue;

                sigs = sigs.Where(sig => selectedEnchant.GetSkillName(sig) == selectedSkill.Name);
            }

            sigs = sigs.OrderByDescending(sig => sig.Value).ThenBy(sig => sig.No).Take(100);

            var disc = selectedEnchant.TypeDiscription + "\r\n";

            disc += sigs.Select(sig => Util.GetEnchantInfo(sig)).JoinS("\r\n") + "\r\n";

            txtMain.Text = disc;

            //var maxSig = _sigList.SigList.Where(sig => selectedEnchant.IsMatch(sig)).OrderBy(sig => sig.Value).First();
        }

        private void cbxEnchant_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnchant = (EnchantType)cbxEnchant.SelectedValue;

            var skList = Lists.SkList.GetSkillListOfEnchantType(selectedEnchant);
            cbxAdd.DisplayMember = "Name";
            cbxAdd.DataSource = skList;
        }
    }
}
