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
    public partial class FIxSignatureListForm : Form
    {
        public FIxSignatureListForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var targetList = new[]
            {
                new { Version = Version.Ver116fix2b, WType = WeaponType.Melee, Feat = true },
                new { Version = Version.Ver116fix2b, WType = WeaponType.Ranged, Feat = true },
            };

            foreach(var target in targetList)
            {
                Lists.Init(target.Version, target.WType, target.Feat);

                var ver = target.Version == Version.Ver116fix2b ? "1.16fix2b" : "1.22";
                var weapon = target.WType == WeaponType.Melee ? "Melee" : "Ranged";
                var feat = target.Feat ? "Feat" : "NoFeat";

                var filename = string.Join("_", ver, weapon, feat) + ".csv";

                var filepath = System.IO.Path.Combine("./Data/EnchantList", filename);

                var wholeText = "";

                var header = "";
                using (var fs = new System.IO.StreamReader(filepath, Encoding.GetEncoding("Shift_JIS")))
                {
                    //ヘッダ飛ばす
                    header = fs.ReadLine();
                    wholeText = fs.ReadToEnd();
                }

                var csv = wholeText.Replace("\r", "").Trim().Split('\n').Select(row => row.Split(',')).ToList();

                foreach(var row in csv)
                {
                    var selectable = !row[2].Contains("名前の巻物で選択不能");

                    var sig = new Signature
                    {
                        No = int.Parse(row[0]),
                        Page = int.Parse(row[5]),
                        Name = row[2],
                        EnchantStr = row[3],
                        Value = int.Parse(row[4]),
                        BloodLevel = int.Parse(row[6]),
                        Selectable = selectable//int.Parse(row[6]) > 0 
                    };

                    var ench = Lists.GetEnchant(sig);

                    if (ench == null) continue;

                    if(ench.Type.ID == 2)
                    {
                        if(ench.Skill.ID == 53)
                        {
                            var newValue = sig.Value * 2;
                            var star = new String('*', Math.Min(newValue / 100 + 1, 5)) + (newValue >= 500 ? "+" : "");
                            
                            var enchStr = "暗黒への耐性を授ける [{0}]".Args(star);

                            row[3] = enchStr;
                            row[4] = newValue.ToString();
                        }
                    }
                    
                }

                var writeCSV = csv.Select(row => row.JoinS(",")).JoinS("\r\n");

                using (var fs = new System.IO.StreamWriter("{0}_new.csv".Args(string.Join("_", ver, weapon, feat)), false, Encoding.GetEncoding("Shift_JIS")))
                {
                    fs.Write(header + "\r\n" + writeCSV);
                }

            }
          
        }
    }
}
