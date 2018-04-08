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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var version = Version.Ver116fix2b;
            var wType = WeaponType.Melee;

            if(rdb1.Checked)
            {
                version = Version.Ver116fix2b;
                wType = WeaponType.Melee;
            }
            else if(rdb2.Checked)
            {
                version = Version.Ver116fix2b;
                wType = WeaponType.Ranged;
            }

            Lists.Init(version, wType, chkFeated.Checked);

            var form = new SelectEnchantsForm();

            form.Show();

            this.Close();

        }

        private void SelectSignatureListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
