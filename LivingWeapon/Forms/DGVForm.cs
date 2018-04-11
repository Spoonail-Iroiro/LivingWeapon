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
using System.IO;

namespace LivingWeapon
{
    public partial class DGVForm : BaseForm
    {
        public DGVForm()
        {
            InitializeComponent();
        }

        public DGVForm(DataTable table) : this()
        {
            dgvMain.DataSource = table;
        }

        private void btnSaveAsCSV_Click(object sender, EventArgs e)
        {
            var table = (DataTable)dgvMain.DataSource;

            var header = new List<string>();

            foreach(DataColumn column in table.Columns)
            {
                header.Add(column.ColumnName);
            }

            var content = header.JoinS(",") + "\r\n";

            content += table.AsEnumerable().Select(row => row.ItemArray.Select(item => item.ToString()).JoinS(",")).JoinS("\r\n");

            var sfd = new SaveFileDialog();

            sfd.FileName = "result.csv";
            sfd.Filter = "csvファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";

            try
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filepath = sfd.FileName;

                    using (var fs = new StreamWriter(filepath, false, Encoding.GetEncoding("Shift_JIS")))
                    {
                        fs.Write(content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("保存に失敗しました");
            }


        }

        private void DGVForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
        }
    }
}
