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

            _sigList = Lists.SigList;
            _etList = Lists.ETList;

            cbxEnchant.DisplayMember = "TypeDiscription";
            cbxEnchant.DataSource = _etList.ETList;

        }

        internal Enchant GetEnchant()
        {
            var rtn = new Enchant { Type = (EnchantType)cbxEnchant.SelectedValue, Skill = SkillLists.NonSkill };

            if(cbxSkill.Visible)
            {
                rtn.Skill = (Skill)cbxSkill.SelectedValue;
            }

            return rtn;            
        }

        internal List<Enchant> GetAllEnchants()
        {
            if (!HasSkills)
            {
                return new List<Enchant> { GetEnchant() };
            }

            var eType = GetEnchant().Type;

            var rtns = _skills.Select(sk => new Enchant { Type = eType, Skill = sk }).ToList();

            return rtns;
        }

        private void cbxEnchant_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEnchant = (EnchantType)cbxEnchant.SelectedValue;

            _skills = SkillLists.GetSkillListOfEnchantType(selectedEnchant);

            if(_skills != null)
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
