using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LivingWeapon
{
    enum Version
    {
        Ver116fix2b,
        Ver122
    }

    enum WeaponType
    {
        Melee,
        Ranged
    }

    static class Lists
    {
        public static SignatureList SigList { get; set; }
        public static EnchantTypeList ETList { get; set; }
        public static SkillLists SkList { get; set; }

        public static bool ListLoaded { get { return ETList != null; } }

        /// <summary>
        /// エンチャントリストを読み込み各種リストクラスを初期化します。
        /// </summary>
        /// <param name="version"></param>
        /// <param name="wtype"></param>
        /// <param name="feated"></param>
        public static void Init(Version version, WeaponType wtype, bool feated)
        {
            ETList = new EnchantTypeList();
            SigList = new SignatureList(version, wtype, feated);
            SkList = new SkillLists();

            ETList.TrimEnchant(SigList);

        }

        public static Enchant GetEnchant(Signature signature)
        {
            var enchantType = ETList.ETList.FirstOrDefault(et => et.IsMatch(signature));

            //TODO 見つからなかった場合

            var skillList = SkillLists.GetSkillListOfEnchantType(enchantType);

            if (skillList == null) return new Enchant { Type = enchantType, Skill = SkillLists.NonSkill };

            var skill = skillList.First(sk => sk.Name == enchantType.GetSkillName(signature));

            return new Enchant { Type = enchantType, Skill = skill };
        }
    }

    //銘リスト
    class SignatureList
    {
        public List<Signature> SigList { get; set; }

        public SignatureList(Version version, WeaponType wtype, bool feated)
        {
            var ver = version == Version.Ver116fix2b ? "1.16fix2b" : "1.22";
            var weapon = wtype == WeaponType.Melee ? "Melee" : "Ranged";
            var feat = feated ? "Feat" : "NoFeat";

            var filename = string.Join("_", ver, weapon, feat) + ".csv";

            var filepath = System.IO.Path.Combine("./Data/EnchantList", filename);

            var wholeText = "";

            using (var fs = new System.IO.StreamReader(filepath, Encoding.GetEncoding("Shift_JIS")))
            {
                //ヘッダ飛ばす
                fs.ReadLine();
                wholeText = fs.ReadToEnd();
            }

            var rowText = wholeText.Replace("\r", "").Trim().Split('\n').ToList();

            SigList = rowText.Select(row =>
            {
                var cells = row.Split(',');

                return new Signature
                {
                    No = int.Parse(cells[0]),
                    Page = int.Parse(cells[5]),
                    Name = cells[2],
                    EnchantStr = cells[3],
                    Value = int.Parse(cells[4]),
                    BloodLevel = int.Parse(cells[6]),
                    Selectable = int.Parse(cells[6]) > 0 //BloodLevel 0 == UnSelectable
                };
            }).ToList();

        }

        /// <summary>
        /// メイン処理用の検索（レベル上昇によるズレを考慮しリスト頭140のエンチャント銘は検索しない、探索するのは上位10エンチャまで）
        /// </summary>
        /// <param name="enchant"></param>
        /// <returns></returns>
        public IEnumerable<Signature> SearchByEnchant(Enchant enchant)
        {
            return SearchByEnchant(enchant, 140, 10);
        }

        /// <summary>
        /// 指定エンチャントで銘リスト（頭listSkip個を除外）を検索し、該当するエンチャント銘の強度順（強度が同じ場合No順）にsearchTake個返します。
        /// </summary>
        /// <param name="enchant">検索エンチャント</param>
        /// <param name="listSkip">検索対象から外す数</param>
        /// <param name="searchTake">検索結果の上位何個を取得するか</param>
        /// <returns></returns>
        private IEnumerable<Signature> SearchByEnchant(Enchant enchant, int listSkip, int searchTake)
        {
            var eType = enchant.Type; 

            var sigs = SigList.Skip(listSkip).Where(sig => eType.IsMatch(sig));

            if (enchant.HasSkill)
            {
                var selectedSkill = enchant.Skill;

                sigs = sigs.Where(sig => eType.GetSkillName(sig) == selectedSkill.Name);
            }

            sigs = sigs.OrderByDescending(sig => sig.Value).ThenBy(sig => sig.No).Take(searchTake);

            return sigs;
        }
    }

    //銘リスト1行に対応するクラス
    class Signature
    {
        public int No { get; set; }
        public int Page { get; set; }
        public string Name { get; set; }

        private string _enchantStr;
        public string EnchantStr
        {
            get
            {
                return _enchantStr;
            }
            set
            {
                _enchantStr = value;
                //Enchant = Lists.GetEnchant(this);
            }
        }
        public int Value { get; set; }
        public int BloodLevel { get; set; }
        public bool Selectable { get; set; } = false;
        //public Enchant Enchant { get; private set; }

    }

    //エンチャント種類（主能力を維持する等）のリスト
    class EnchantTypeList
    {
        public List<EnchantType> ETList { get; set; }

        public EnchantTypeList()
        {
            var filepath = System.IO.Path.Combine("./Eseshinpu/Data", "EnchantData.csv");

            var wholeText = "";

            using (var fs = new System.IO.StreamReader(filepath, Encoding.GetEncoding("Shift_JIS")))
            {
                //ヘッダ飛ばす
                fs.ReadLine();
                wholeText = fs.ReadToEnd();
            }

            var rowText = wholeText.Replace("\r", "").Trim().Split('\n').ToList();

            ETList = rowText.Select(row =>
            {
                var cells = row.Split(',');

                return new EnchantType
                {
                    ID = int.Parse(cells[0]),
                    TypeDiscription = cells[1],
                    Reg = new Regex(cells[3])
                };
            }).ToList();

            /*
1,～～（能力値）を上げる（下げる）,-,(..)(を)(\d+)(上げる)(.*)
2,～～への耐性を授ける（弱化する）,-,(.+)(への耐性を授ける)(.*)
3,～～の技能を上げる（下げる）,-,// 技能だけは特殊処理
6,～～（能力値）を維持する,-,(.+)(を維持する)(.*)
7,～～属性の追加ダメージを与える,近接・遠隔武器,(.+)(属性の追加ダメージを与える)(.*)
8,～～を発動する,-,(.+)(を発動する)(.*)
9,～～を装填できる,矢弾,(.+)(を装填できる)(.*)*/

            var etNameProxy = new List<Tuple<int, string>>
            {
                new Tuple<int, string>(1, "（主能力）を上げる"),
                new Tuple<int, string>(2, "（属性）への耐性を授ける"),
                new Tuple<int, string>(3, "（スキル）の技能を上げる"),
                new Tuple<int, string>(6, "（主能力）を維持する"),
                new Tuple<int, string>(7, "（属性）の追加ダメージを与える"),
                new Tuple<int, string>(8, "（効果）を発動する"),
                new Tuple<int, string>(9, "（矢弾）を装填できる")
            };

            foreach (var proxy in etNameProxy)
            {
                var target = ETList.FirstOrDefault(et => et.ID == proxy.Item1);

                if (target == null) continue;

                target.TypeDiscription = proxy.Item2;
            }


            //魔法威力スキップを追加　1.66
            //ETList.Add(new EnchantType { ID = 99, Reg = new Regex("(魔法の威力～だがスキップされた)"), TypeDiscription = "魔法威力スキップ" });
            //1.22
            //ETList.Add(new EnchantType { ID = 99, Reg = new Regex("(スキップ)"), TypeDiscription = "魔法威力スキップ" });
        }

        public void TrimEnchant(SignatureList sigList)
        {
            //sigListにないエンチャを除外
            ETList = ETList.Where(et => sigList.SigList.Any(sig => et.IsMatch(sig.EnchantStr))).ToList();
        }
    }

    class EnchantType
    {
        public int ID { get; set; }
        public string TypeDiscription { get; set; }
        public Regex Reg { private get; set; }

        #region temp
        public List<string> GetParams(Signature sig)
        {
            return GetParams(sig.EnchantStr);
        }

        public List<string> GetParams(string str)
        {
            if (ID != 3) return Reg.Match(str).Groups.Cast<Group>().Select(gr => gr.Value).ToList();

            return TechSkillBoostEnchant.GetParams(str);
        }

        public string GetSkillName(Signature sig)
        {
            return GetSkillName(sig.EnchantStr);
        }

        public string GetSkillName(string str)
        {
            switch (ID)
            {
                case 1:
                case 2:
                case 3:
                case 6:
                case 7:
                case 8:
                case 9:
                    return GetParams(str)[1];
                default:
                    return "";
            }
        }

        #endregion

        public bool IsMatch(Signature sig)
        {
            return IsMatch(sig.EnchantStr);
        }

        public bool IsMatch(string str)
        {
            if (ID != 3) return Reg.IsMatch(str);

            return TechSkillBoostEnchant.IsMatch(str);
        }


    }

    //エンチャント種類のうち、スキルブースト系に対して検索・スキル（対象スキル）抽出するためのクラス
    class TechSkillBoostEnchant
    {
        //TechSkillBoostEnchantのみで利用 スキルブースト系エンチャント1つを表す
        //Enchantクラスで指定されるSkillとは関係なし
        public class TechSkill
        {
            public string Type { get; set; }
            public string Discription { get; set; }
        }

        public static List<TechSkill> SkillList { get; set; }

        static TechSkillBoostEnchant()
        {
            var filepath = System.IO.Path.Combine("./Eseshinpu/Data", "TechnicalSkillEnchantData.csv");

            var wholeText = "";

            using (var fs = new System.IO.StreamReader(filepath, Encoding.GetEncoding("Shift_JIS")))
            {
                //ヘッダ飛ばす
                fs.ReadLine();
                wholeText = fs.ReadToEnd();
            }

            var rowText = wholeText.Replace("\r", "").Trim().Split('\n').ToList();

            SkillList = rowText.Select(row =>
            {
                var cells = row.Split(',');

                return new TechSkill
                {
                    Type = cells[0],
                    Discription = cells[2]
                };
            }).ToList();
        }

        public static bool IsMatch(string str)
        {
            return SkillList.Any(skill => str.Contains(skill.Discription));
        }

        public static List<string> GetParams(string str)
        {
            var matchedSkill = SkillList.FirstOrDefault(skill => str.Contains(skill.Discription));

            return matchedSkill == null ? new List<string>() : new List<string> { matchedSkill.Discription, matchedSkill.Type };
        }


    }

    class SkillLists
    {
        //主能力
        public static List<Skill> MainParamList { get; private set; } = new List<Skill>();
        //属性
        public static List<Skill> ElementList { get; private set; } = new List<Skill>();
        //技能
        public static List<Skill> TechSkillList { get; private set; } = new List<Skill>();

        static SkillLists()
        {

            var filepath = System.IO.Path.Combine("./Eseshinpu/Data", "SkillData.csv");

            var wholeText = "";

            using (var fs = new System.IO.StreamReader(filepath, Encoding.GetEncoding("Shift_JIS")))
            {
                //ヘッダ飛ばす
                fs.ReadLine();
                wholeText = fs.ReadToEnd();
            }

            var rowTexts = wholeText.Replace("\r", "").Trim().Split('\n').ToList();

            foreach (var row in rowTexts)
            {
                var cells = row.Split(',');

                if (cells[0] == "") continue;

                var id = int.Parse(cells[0]);

                if (10 <= id && id <= 19)
                {
                    MainParamList.Add(new Skill { ID = id, Name = cells[1] });
                }
                else if (50 <= id && id <= 61)
                {
                    ElementList.Add(new Skill { ID = id, Name = cells[1] });
                }
                else if (150 <= id && id <= 189)
                {
                    TechSkillList.Add(new Skill { ID = id, Name = cells[1] });
                }
            }

            //出血属性の削除
            ElementList.RemoveAll(sk => sk.ID == 61);

            MainParamList.OrderBy(sk => sk.ID);
            ElementList.OrderBy(sk => sk.ID);
            TechSkillList.OrderBy(sk => sk.ID);

            /*
            SkillList = rowText.Select(row =>
            {
                var cells = row.Split(',');

                return new TechSkill
                {
                    Type = cells[0],
                    Discription = cells[2]
                };
            }).ToList();
            */
        }

        public static readonly Skill NonSkill = new Skill { ID = 99999, Name = "" };

        /*
          @"MainParam 1,～～（能力値）を上げる（下げる）,-,(..)(を)(\d+)(上げる)(.*)
            Element 2,～～への耐性を授ける（弱化する）,-,(.+)(への耐性を授ける)(.*)
            TechSkill 3,～～の技能を上げる（下げる）,-,// 技能だけは特殊処理
            MainParam 6,～～（能力値）を維持する,-,(.+)(を維持する)(.*)
            Element 7,～～属性の追加ダメージを与える,近接・遠隔武器,(.+)(属性の追加ダメージを与える)(.*)
            //8,～～を発動する,-,(.+)(を発動する)(.*)
            //9,～～を装填できる,矢弾,(.+)(を装填できる)(.*)"
         */

        /// <summary>
        /// エンチャントタイプに付随するスキルに対応するスキルリストを返します。スキルがないエンチャントタイプの場合nullが返されます。
        /// </summary>
        /// <param name="enchantType">エンチャントタイプ</param>
        /// <returns></returns>
        public static List<Skill> GetSkillListOfEnchantType(EnchantType enchantType)
        {
            return GetSkillListOfEnchantType(enchantType.ID);
        }

        public static List<Skill> GetSkillListOfEnchantType(int enchantTypeID)
        {
            switch (enchantTypeID)
            {
                case 1:
                case 6:
                    return MainParamList;
                    break;
                case 2:
                case 7:
                    return ElementList;
                    break;
                case 3:
                    return TechSkillList;
                    break;
                default:
                    return null;
                    break;
            }

        }



    }

    class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    //エンチャント スキルを伴う場合（例：筋力を維持）はエンチャント種類（主能力を維持）＋スキル（筋力）
    //それ以外（例：混乱無効）はエンチャント種類（混乱を無効にする）＋SkillLists.NonSkill
    class Enchant
    {
        public EnchantType Type { get; set; }
        public Skill Skill { get; set; }

        public string TypeStr { get { return Type.TypeDiscription; } }
        public string SkillStr { get { return Skill.Name; } }

        public bool HasSkill
        {
            get
            {
                return Skill.ID != SkillLists.NonSkill.ID;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var eobj = obj as Enchant;

            if (eobj == null)
            {
                return false;
            }

            if (this.Type == null || eobj.Type == null ||
               this.Skill == null || eobj.Skill == null)
            {
                return false;
            }

            return (this.Type.ID == eobj.Type.ID) && (this.Skill.ID == eobj.Skill.ID);
        }

        public bool Equals(Enchant eobj)
        {
            if (eobj == null)
            {
                return false;
            }

            if (this.Type == null || eobj.Type == null ||
               this.Skill == null || eobj.Skill == null)
            {
                return false;
            }

            return (this.Type.ID == eobj.Type.ID) && (this.Skill.ID == eobj.Skill.ID);
        }

        public override int GetHashCode()
        {
            return this.Type.ID ^ this.Skill.ID;
        }
    }

}
