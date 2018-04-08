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
    public partial class EnchantSummaryForm : Form
    {
        public EnchantSummaryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sigList = Lists.SigList;
            var etList = Lists.ETList;
            var wholeSum = 0;

            foreach (var et in etList.ETList)
            {
                txtMain.Text += "ID:{0} 種類：{1}\r\n".Args(et.ID, et.TypeDiscription);
                var searchedList = sigList.SigList.Where(sig => et.IsMatch(sig.EnchantStr));
                var discList = searchedList.Select(sig => sig.EnchantStr).Distinct().OrderBy(key => key);
                txtMain.Text += discList.JoinS("\r\n") + "\r\n";
                var typeCount = searchedList.Count();
                txtMain.Text += "計：{0}銘\r\n".Args(typeCount);

                wholeSum += typeCount;

            }

            txtMain.Text += "★総計：{0}".Args(wholeSum);

        }
    }
}
