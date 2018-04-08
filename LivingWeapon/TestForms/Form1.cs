using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LivingWeapon.MyExt;

namespace LivingWeapon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMain.Text = "";

            var sigList = Lists.SigList;
            var etList = Lists.ETList;

            var sum = 0;

            foreach(var et in etList.ETList)
            {
                var enchCount = sigList.SigList.Count(sig => et.IsMatch(sig.EnchantStr));

                txtMain.Text += "{0}\t{1}\r\n".Args(et.TypeDiscription, enchCount);

                sum += enchCount;
            }

            txtMain.Text += "計：{0}".Args(sum);
            
            //var selectedET = enchantTypeList.First(et => et.ID == enchantID);

            //txtMain.Text += "選択エンチャントID：{0}\r\n".Args(selectedET.ID);
            //txtMain.Text += "選択エンチャントタイプ：{0}\r\n".Args(selectedET.TypeDiscription);

            //var seList = sigList.SigList.Where(sig => selectedET.Reg.IsMatch(sig.Enchant)).Take(100).ToList();

            //var keywordList = new List<string> { "上げる", "への耐性を授ける" };

            //var seList = sigList.SigList.Where(sig => sig.Enchant.Contains(keywordList[0])).Take(100).ToList();

            /*
            foreach (var sig in seList)
            {
                txtMain.Text += GetEnchantInfo(sig);
            } */                       
        }

        /// <summary>
        /// 銘検索し、200件の銘情報テキストを返します。
        /// </summary>
        /// <param name="sigList"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        string SearchName(List<Signature> sigList, string keyword)
        {
            var seachedList = sigList.Where((sig) => sig.Name.Contains(keyword)).ToList();

            var rtn = "";

            var count = 0;

            foreach (var sig in seachedList)
            {
                rtn += GetEnchantInfo(sig);

                ++count;

                if (count > 200) break;
            }

            return rtn;
        }

        string SearchXward(List<Signature> sigList, string keyword, int nowNo, bool isForward)
        {
            var rtnSig = isForward ? sigList.Skip(nowNo).FirstOrDefault(sig => sig.Name.Contains(keyword)) : sigList.Take(nowNo - 1).LastOrDefault(sig => sig.Name.Contains(keyword));

            return GetEnchantInfo(rtnSig);
        }

        string GetEnchantInfo(Signature sig)
        {
            if (sig == null) return "情報なし\r\n";

            var sigSamp = sig;

            var info =  string.Format("{0}番目の銘は{1}という名前で{4}ページ目にあり{6}、「{2}」というエンチャントが強度{3}で付く。血吸レベルは{5}\r\n",
                sigSamp.No,
                sigSamp.Name,
                sigSamp.EnchantStr,
                sigSamp.Value,
                sigSamp.Page,
                sigSamp.BloodLevel,
                sigSamp.Selectable ? "" : "（選択不能）");

            return info;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new EnchantSummaryForm();

            form.ShowDialog();
        }

        private void btnEnchant_Click(object sender, EventArgs e)
        {
            var form = new SelectSigForm();

            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new SelectSigForm();

            form.ShowDialog();
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            var form = new SelectSignatureListForm();

            form.Show();
        }
    }
}
