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
        Form _snForm;

        public DGVForm()
        {
            InitializeComponent();
        }

        public DGVForm(DataTable table, bool IsScrollOfNameButtonOn) : this()
        {
            dgvMain.DataSource = table;

            //明示的にウィンドウを可変に
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;

            if (!IsScrollOfNameButtonOn) return;

            var buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "ScrollOfName";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.Text = "名前の巻物";
            buttonColumn.HeaderText = "名前の巻物";

            dgvMain.Columns.Add(buttonColumn);
        }

        private void btnSaveAsCSV_Click(object sender, EventArgs e)
        {
            var table = (DataTable)dgvMain.DataSource;

            var header = new List<string>();

            foreach (DataColumn column in table.Columns)
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
            if (_snForm != null)
            {
                _snForm.Close();
            }

            if (Util.IsAppClosed) return;

            e.Cancel = true;

            this.Hide();
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMain.Columns[e.ColumnIndex].Name == "ScrollOfName")
            {
                var table = (DataTable)dgvMain.DataSource;

                var no = table.Rows[e.RowIndex].Field<int>(2);

                var targetSig = Lists.SigList.SigList.First(sig => sig.No == no);

                //起動中は前に開いていた位置を記憶
                if (_snForm != null)
                {
                    var prevPos = _snForm.Location;

                    _snForm.Close();

                    _snForm = new ScrollOfNameForm(targetSig);

                    _snForm.StartPosition = FormStartPosition.Manual;

                    _snForm.Location = prevPos;
                }
                else
                {
                    _snForm = new ScrollOfNameForm(targetSig);

                    _snForm.StartPosition = FormStartPosition.Manual;

                    var centerX = this.Left + this.Width / 2;

                    _snForm.Left = centerX - _snForm.Width / 2;
                    _snForm.Top = this.Top;

                }

                _snForm.Show();



            }
        }

        private void chkFont_CheckedChanged(object sender, EventArgs e)
        {
            var font = chkFont.Checked ? new Font("ＭＳ ゴシック", 12) : new Font("Meiryo UI", 9);

            foreach (DataGridViewColumn col in dgvMain.Columns)
            {

                col.DefaultCellStyle.Font = font;
            }
        }
    }
}
