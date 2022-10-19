using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingWeapon
{
    public partial class EnchantCombobox : UserControl
    {
        private EnchantTypeList _etList;
        private SignatureList _sigList;

        private List<Skill> _skills;
        public bool HasSkills { get { return _skills != null; } }

        public event EventHandler<EventArgs> cbxEnchantSelectedIndexChanged;

        public EnchantCombobox()
        {
            InitializeComponent();
        }

        private void EnchantCombobox_Load(object sender, EventArgs e)
        {
            //デザイナ用
            if (!Lists.ListLoaded) return;

            _etList = Lists.ETList;

            cbxEnchant.DisplayMember = "TypeDiscription";
            cbxEnchant.DataSource = _etList.ETList;

        }

        public Enchant GetEnchant()
        {
            var enchantType = (EnchantType)cbxEnchant.SelectedValue;

            var rtn = new Enchant { Type = enchantType, Skill = SkillLists.NonSkill };

            if(enchantType.HasSkill())
            {
                rtn.Skill = (Skill)cbxSkill.SelectedValue;
            }

            return rtn;            
        }

        //選択されているエンチャントタイプに属するエンチャントをすべて取得する
        public List<Enchant> GetAllEnchants()
        {
            var ench = GetEnchant();

            var rtns = EnchantFactory.GetAllEnchantWithEnchantType(ench.Type);

            return rtns;
        }

        private void cbxEnchant_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnchantType = (EnchantType)cbxEnchant.SelectedValue;

            var skillEnu = Lists.SkList.GetSkillListOfEnchantType(selectedEnchantType);

            _skills = skillEnu != null ? skillEnu.ToList() : null;

            if(selectedEnchantType.HasSkill())
            {
                cbxSkill.DisplayMember = "Name";
                cbxSkill.DataSource = _skills;
                cbxSkill.Visible = true;
            }
            else
            {
                cbxSkill.DataSource = _skills;
                cbxSkill.Visible = false;
            }

            cbxEnchantSelectedIndexChanged?.Invoke(sender, e);

        }

    }
}
