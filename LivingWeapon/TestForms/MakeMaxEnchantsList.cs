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

namespace LivingWeapon.TestForms
{
    public partial class MakeMaxEnchantsList : Form
    {
        private List<Enchant> _enchants;

        public MakeMaxEnchantsList()
        {
            InitializeComponent();

            txtMain.Text = "";

            _enchants = EnchantFactory.GetAllEnchant().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Lists.SelectedOption == Option.Feat100000p)
            {
                return;
            }

            Log("計算中");

            Refresh();


            MakeMESListFramework(ench =>
            {
                return new MaxEnchantSignatures { Ench = ench, Sigs = Lists.SigList.SearchByEnchant(ench, Lists.GetLastPage()).ToList() };
            });

            /*
            var mesList = new List<MaxEnchantSignatures>();

            foreach (var ench in enchants)
            {
                Log("処理中… {0}/{1}".Args(enchants.IndexOf(ench), enchants.Count));
                txtMain.SelectionStart = txtMain.Text.Length;
                txtMain.ScrollToCaret();
                Refresh();

                var mes = new MaxEnchantSignatures { Ench = ench, Sigs = Lists.SigList.SearchByEnchant(ench, lastPage).ToList() };

                mesList.Add(mes);
            }

            Lists.MesList.SetMaxEnchantSigList(mesList);

            Lists.MesList.Save();

            Log("計算終了！\r\n{0}".Args(DateTime.Now));
            */

        }

        private void process100000p()
        {
            var rowText = prepareRowText();

            var enchants = EnchantFactory.GetAllEnchant().ToList();

            //エンチャント文リストの作成

            //エンチャント文を使ってエンチャントを絞り込む

            //1000ページ
            var texts = rowText.Take(17000);
            var sigsForList = Lists.SigList.GetSigList(texts.ToList());

            var enchAndStrs = enchants.Select(ench => 
            {
                var sigHasEnch = sigsForList.First(sig => ench.Type.IsMatch(sig) && (!ench.Type.HasSkill() || ench.Type.GetSkillName(sig) == ench.Skill.Name));

                var expl = sigHasEnch.EnchantStr.Split('[')[0].Trim();

                var enchStr = ench.Type.ID == 1 ? expl.Substring(0, 2) : expl;

                return new { Ench = ench, Str = enchStr};
            });

            txtSearchStr.Text = enchAndStrs.Select(es => es.Str).JoinS("\r\n");

            MakeMESListFramework(enchT =>
            {
                var key = enchAndStrs.First(eas => eas.Ench.Equals(enchT)).Str;

                var filteredTexts = rowText.Where(row => row.Contains(key));

                var subSigList = Lists.SigList.GetSigList(filteredTexts.ToList());

                var result = Lists.SigList.SearchByEnchantRange(subSigList, enchT);

                return new MaxEnchantSignatures { Ench = enchT, Sigs = result.ToList() };

            });
            
            //SigList = GetSigList(rowText);
        }

        private List<MaxEnchantSignatures> MakeMESListFramework(Func<Enchant, MaxEnchantSignatures> coreProcess)
        {
            Log("計算中");

            Refresh();

            var mesList = new List<MaxEnchantSignatures>();

            foreach (var ench in _enchants)
            {
                Log("処理中… {0}/{1}".Args(_enchants.IndexOf(ench), _enchants.Count));
                txtMain.SelectionStart = txtMain.Text.Length;
                txtMain.ScrollToCaret();
                Refresh();

                var mes = coreProcess(ench);

                //var mes = new MaxEnchantSignatures { Ench = ench, Sigs = Lists.SigList.SearchByEnchant(ench, lastPage).ToList() };

                mesList.Add(mes);
            }

            Lists.MesList.SetMaxEnchantSigList(mesList);

            Lists.MesList.Save();

            Log("計算終了！\r\n{0}".Args(DateTime.Now));

            return mesList;
        }

        private List<string> prepareRowText()
        {
            var filename = Lists.GetEnchantListSignature() + ".csv";

            var filepath = System.IO.Path.Combine("./Data/EnchantList", filename);

            var wholeText = "";

            var rowText = new List<string>();

            using (var fs = new System.IO.StreamReader(filepath, Encoding.GetEncoding("Shift_JIS")))
            {
                //ヘッダ飛ばす
                fs.ReadLine();

                while(!fs.EndOfStream)
                {
                    wholeText = fs.ReadLine().Trim();

                    rowText.Add(wholeText);

                }
            }

//            var rowText = wholeText.Replace("\r", "").Trim().Split('\n');

            return rowText;
        }

        private List<string> cutRowText(Enchant ench, List<string> rowText)
        {

            throw new NotImplementedException();

        }

        private void Log(string str)
        {
            txtMain.Text += str + "\r\n";

        }

        private void btn100000p_Click(object sender, EventArgs e)
        {
            process100000p();
        }
    }
}
