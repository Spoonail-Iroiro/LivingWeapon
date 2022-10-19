using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LivingWeapon;

namespace UISandbox_LivingWeapon
{
    public partial class StartupForm : Form
    {
        Form _dgvForm;

        public StartupForm()
        {
            InitializeComponent();
        }

        private void btnDGVForm_Click(object sender, EventArgs e)
        {
            var testData = new GenerateTestData();

            var testSelEnch = testData.GenerateSelectedEnchants();

            var searched = new SignatureSearch(1, 11, testSelEnch);

            var table = BasicSearchResultFormatter.GetResultTable(searched);

            _dgvForm = new DGVForm(table, true);

            _dgvForm.ShowDialog();
        }

        private void StartupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LivingWeapon.Util.ExitApplication();

            if (_dgvForm != null)
            {
                _dgvForm.Close();

            }
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {

            txtSigVersion.Text = Lists.GetEnchantListSignature();
        }
    }
}
