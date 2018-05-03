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
    public partial class InputDialog : BaseForm
    {
        Form _nsForm;

        public InputDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int page = 0;

            var success = int.TryParse(txtPage.Text, out page);

            if (!success) return;

            if(_nsForm != null)
            {
                _nsForm.Close();
                _nsForm.Dispose();
            }

            _nsForm = new ScrollOfNameForm(page);

            this.Hide();

            _nsForm.Show();

        }

        private void btnOKNo_Click(object sender, EventArgs e)
        {
            int no = 0;

            var success = int.TryParse(txtNo.Text, out no);

            if (!success) return;

            var target = Lists.SigList.GetSignatureOrNull(no);

            if (target == null) return;

            _nsForm = new ScrollOfNameForm(target);

            this.Hide();

            _nsForm.Show();

        }

        private void InputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_nsForm != null)
            {
                _nsForm.Close();
            }
        }
    }
}
