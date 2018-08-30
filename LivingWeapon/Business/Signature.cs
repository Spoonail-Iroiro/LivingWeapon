using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using LivingWeapon.Properties;
using LivingWeapon.Business;
using LivingWeapon.MyExt;

namespace LivingWeapon
{
    enum Version
    {
        Ver116fix2b,
        Ver122,
        OO
    }

    enum WeaponType
    {
        Melee,
        Ranged
    }

    enum Option
    {
        Feat,
        NoFeat,
        Feat100000p
    }

    static class Lists
    {
        public static SignatureList SigList { get; set; }
        public static EnchantTypeList ETList { get; set; }
        public static SkillLists SkList { get; set; }

        public static MaxEnchantSignatureLists MesList { get; set; }


        public static bool ListLoaded { get { return ETList != null; } }
        public static Version SelectedVersion { get; private set; }
        public static WeaponType SelectedWType { get; private set; }
        public static Option SelectedOption { get; private set; }


        /// <summary>
        /// エンチャントリストを読み込み各種リストクラスを初期化します。
        /// </summary>
        /// <param name="version"></param>
        /// <param name="wtype"></param>
        /// <param name="feated"></param>
        public static void Init(Version version, WeaponType wtype, Option option)
        {
            SelectedVersion = version;
            SelectedWType = wtype;
            SelectedOption = option;

            ETList = new EnchantTypeList();
            SigList = new SignatureList(version, wtype, option);
            SkList = new SkillLists();

            ETList.TrimEnchant(SigList);
            SigList.Validate();

            MesList = new MaxEnchantSignatureLists(Settings.Default.UseStaticJsonData);
        }

        public static Enchant GetEnchant(Signature signature)
        {
            var enchantType = ETList.ETList.FirstOrDefault(et => et.IsMatch(signature));

            if (enchantType == null) return null;

            //TODO 見つからなかった場合

            var skillList = Lists.SkList.GetSkillListOfEnchantType(enchantType);

            if (skillList == null) return new Enchant { Type = enchantType, Skill = SkillLists.NonSkill };

            var skill = skillList.First(sk => sk.Name == enchantType.GetSkillName(signature));

            return new Enchant { Type = enchantType, Skill = skill };
        }

        /// <summary>
        /// 引数で指定された銘リストの識別子を返します。
        /// </summary>
        /// <returns></returns>
        public static String GetEnchantListSignature(Version version, WeaponType wtype, Option option)
        {
            var ver = version == Version.Ver116fix2b ? "1.16fix2b" : (version == Version.Ver122 ? "1.22" : "oo");
            var weapon = wtype == WeaponType.Melee ? "Melee" : "Ranged";
            var opt = option == Option.Feat ? "Feat" : (option == Option.NoFeat ? "NoFeat" : "Feat100000p");

            var signature = string.Join("_", ver, weapon, opt);

            return signature;
        }

        /// <summary>
        /// 現在読み込んでいる銘リストの識別子を返します。
        /// </summary>
        /// <returns></returns>
        public static String GetEnchantListSignature()
        {
            return GetEnchantListSignature(SelectedVersion, SelectedWType, SelectedOption);
        }


    }

    //検索高速化のため静的に保存するデータ（jsonファイル）関連のクラス
    static class StaticJson
    {
        //値の保存用jsonパスを返します
        public static String GetJsonPath(String key)
        {
            var path = System.IO.Path.Combine("./Data", "Json", key + "_" + Lists.GetEnchantListSignature() + ".json");

            return path;
        }

        public static T Load<T>(String key)
        {
            var filepath = StaticJson.GetJsonPath(key);

            try
            {

                using (var fs = new System.IO.StreamReader(filepath))
                {
                    var json = fs.ReadToEnd();

                    var obj = JsonConvert.DeserializeObject<T>(json);

                    return obj;
                }
            }
            catch(Exception ex)
            {
                throw new StaticJsonLoadException("JSONのロード中にエラーが発生しました", ex);
            }
        }


        public static void Save<T>(String key, T obj)
        {
            var filepath = StaticJson.GetJsonPath(key);

            try
            {

                using (var fs = new System.IO.StreamWriter(filepath))
                {
                    var json = JsonConvert.SerializeObject(obj);

                    fs.Write(json);
                }
            }
            catch(Exception ex)
            {
                throw new StaticJsonLoadException("JSONのセーブ中にエラーが発生しました", ex);

            }
        }
    }

    //銘リスト
    class SignatureList
    {
        public List<Signature> SigList { get; set; }

        public SignatureList(Version version, WeaponType wtype, Option opt)
        {
            //100000ページ検索時はSigListオブジェクトを作らない
            //if (opt == Option.Feat100000p) return;

            var filename = Lists.GetEnchantListSignature() + ".csv";

            var filepath = System.IO.Path.Combine("./Data/EnchantList", filename);

            var wholeText = "";

            try
            {
                using (var fs = new System.IO.StreamReader(filepath, Encoding.GetEncoding("Shift_JIS")))
                {
                    //ヘッダ飛ばす
                    fs.ReadLine();
                    wholeText = fs.ReadToEnd();
                }
            }
            catch(System.IO.FileNotFoundException ex)
            {
                throw new SignatureListLoadException("", ex);
            }

            var rowText = wholeText.Replace("\r", "").Trim().Split('\n').ToList();

            SigList = GetSigList(rowText);

        }

        bool _isValid = false;

        //銘リストの行区切りListからSigListを作成
        public List<Signature> GetSigList(List<string> rowText)
        {
            var sigList = rowText.Select(row =>
            {
                var cells = row.Split(',');

                var selectable = !cells[2].Contains("名前の巻物で選択不能") && !cells[2].Contains("選択不可");

                return new Signature
                {
                    No = int.Parse(cells[0]),
                    Page = int.Parse(cells[5]),
                    Name = cells[2],
                    EnchantStr = cells[3],
                    Value = int.Parse(cells[4]),
                    BloodLevel = int.Parse(cells[6]),
                    Selectable = selectable//int.Parse(cells[6]) > 0 
                };
            }).ToList();

            return sigList;
        } 

        //Noベースで銘を取得
        public Signature GetSignature(int no)
        {
            if (!_isValid) throw new Exception("検証に成功していないSignatureListでNoベースアクセスがされました");

            return GetSignatureNoValidate(no);
        }

        private Signature GetSignatureNoValidate(int no)
        {
            return SigList[no - 1];
        }

        public Signature GetSignatureOrNull(int no)
        {
            if (!(1 <= no && no <= SigList.Count)) return null;

            return GetSignatureNoValidate(no);
        }

        //GetSignatureが正常に動作するか確認する
        public bool Validate()
        {
            //100000p検索時はSigListを作らない
            //if (Lists.SelectedOption == Option.Feat100000p) return true;

            foreach (var sig in SigList)
            {
                var noBaseSelect = GetSignatureOrNull(sig.No);

                if (noBaseSelect == null || sig.No != noBaseSelect.No)
                {
                    return false;
                }
            }

            _isValid = true;

            return true;
        }

        /// <summary>
        /// メイン処理用の検索（レベル上昇によるズレを考慮しリスト頭140のエンチャント銘は検索しない、探索するのは上位10エンチャまで）
        /// 指定エンチャントで銘リスト（頭listSkip個を除外）をpageLimitページまでで検索し、該当するエンチャント銘の強度順（強度が同じ場合No順）にsearchTake個返します。
        /// </summary>
        /// <param name="enchant"></param>
        /// <returns></returns>
        public IEnumerable<Signature> SearchByEnchant(Enchant enchant, int pageLimit)
        {
            if(Settings.Default.UseStaticJsonData)
            {
                return Lists.MesList.SearchByEnchant(enchant, pageLimit);
            }
            else
            {
                var listSkip = 140;

                var searchSigList = SigList.Take(17 * pageLimit - 1).Skip(listSkip);

                var sigs = SearchByEnchantRange(searchSigList, enchant);

                return sigs;

            }

        }

        /// <summary>
        /// 検索範囲が限定されたsigsに対して該当するエンチャント銘の強度順（強度が同じ場合No順）にsearchTake個返します。
        /// </summary>
        /// <param name="sigs"></param>
        /// <param name="enchant"></param>
        /// <returns></returns>
        public IEnumerable<Signature> SearchByEnchantRange(IEnumerable<Signature> sigs, Enchant enchant)
        {
            var searchTake = 100;

            var eType = enchant.Type;

            sigs = sigs.Where(sig => eType.IsMatch(sig));

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
            var key = "TrimEnchant";

            //100000ページ検索時は強制でJSON参照
            if (Settings.Default.UseStaticJsonData || Lists.SelectedOption == Option.Feat100000p)
            {
                var etIDList = StaticJson.Load<List<int>>(key);

                //sigListにないエンチャを除外
                ETList = ETList.Where(et => etIDList.Contains(et.ID)).ToList();
            }
            else
            {
                //sigListにないエンチャを除外
                ETList = ETList.Where(et => sigList.SigList.Any(sig => et.IsMatch(sig.EnchantStr))).ToList();

                //保存用
                var etIDList = ETList.Select(et => et.ID).ToList();

                StaticJson.Save(key, etIDList);

            }


        }

        public EnchantType GetEnchantType(int id)
        {
            return ETList.First(et => et.ID == id);
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

        //スキル指定のあるエンチャントタイプかどうか
        public bool HasSkill()
        {
            var skillList = Lists.SkList.GetSkillListOfEnchantType(this);

            return  skillList != null;
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

    internal class SkillLists
    {
        /*
        //主能力
        public static List<Skill> MainParamList { get; private set; } = new List<Skill>();
        //属性
        public static List<Skill> ElementList { get; private set; } = new List<Skill>();
        //技能
        public static List<Skill> TechSkillList { get; private set; } = new List<Skill>();
        */

        public static List<Skill> SkList { get; private set; } = new List<Skill>();

        public static readonly Skill NonSkill = new Skill { ID = 99999, Name = "" };

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

                SkList.Add(new Skill { ID = id, Name = cells[1] });
            }

            //出血属性の削除
            SkList.RemoveAll(sk => sk.ID == 61);

            SkList.OrderBy(sk => sk.ID);

            /*
            MainParamList.OrderBy(sk => sk.ID);
            ElementList.OrderBy(sk => sk.ID);
            TechSkillList.OrderBy(sk => sk.ID);
            */
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

        public enum SkillType
        {
            MainParam,
            Element,
            TechSkill,
            Other
        }

        public static SkillType GetSkillType(int id)
        {
            if (10 <= id && id <= 19)
            {
                return SkillType.MainParam;
            }
            else if (50 <= id && id <= 61)
            {
                return SkillType.Element;
            }
            else if (150 <= id && id <= 189)
            {
                return SkillType.TechSkill;
            }
            else
            {
                return SkillType.Other;
            }
        }

        /*
          @"MainParam 1,～～（能力値）を上げる（下げる）,-,(..)(を)(\d+)(上げる)(.*)
            Element 2,～～への耐性を授ける（弱化する）,-,(.+)(への耐性を授ける)(.*)
            TechSkill 3,～～の技能を上げる（下げる）,-,// 技能だけは特殊処理
            MainParam 6,～～（能力値）を維持する,-,(.+)(を維持する)(.*)
            Element 7,～～属性の追加ダメージを与える,近接・遠隔武器,(.+)(属性の追加ダメージを与える)(.*)
            //8,～～を発動する,-,(.+)(を発動する)(.*)
            //9,～～を装填できる,矢弾,(.+)(を装填できる)(.*)"
         */

        public Skill GetSkill(int id)
        {
            if (NonSkill.ID == id) return NonSkill;

            return SkList.First(sk => sk.ID == id);
        }

        /// <summary>
        /// エンチャントタイプに付随するスキルに対応するスキルリストを返します。スキルがないエンチャントタイプの場合nullが返されます。
        /// </summary>
        /// <param name="enchantType">エンチャントタイプ</param>
        /// <returns></returns>
        public IEnumerable<Skill> GetSkillListOfEnchantType(EnchantType enchantType)
        {
            return GetSkillListOfEnchantType(enchantType.ID);
        }

        public IEnumerable<Skill> GetSkillListOfEnchantType(int enchantTypeID)
        {
            //IDによるスキル種類の違い
            var type = SkillType.Element;

            switch (enchantTypeID)
            {
                case 1:
                case 6:
                    type = SkillType.MainParam;
                    break;
                case 2:
                case 7:
                    type = SkillType.Element;
                    break;
                case 3:
                    type = SkillType.TechSkill;
                    break;
                default:
                    return null;
                    break;
            }

            return SkList.Where(sk => GetSkillType(sk.ID) == type);


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

    //EnchantTypeとSkillからなるEnchantクラスのオブジェクトを包括的に管理するクラス
    static class EnchantFactory
    {
        public static List<Enchant> GetAllEnchant()
        {
            var enchList = new List<Enchant> { };

            foreach (var et in Lists.ETList.ETList)
            {
                enchList.AddRange(GetAllEnchantWithEnchantType(et));

                /*
                if (!et.HasSkill())
                {
                    var rtn = new Enchant { Type = et, Skill = SkillLists.NonSkill };
                    enchList.Add(rtn);
                    continue;
                }

                var skills = Lists.SkList.GetSkillListOfEnchantType(et);

                var rtns = skills.Select(sk => new Enchant { Type = et, Skill = sk }).ToList();

                enchList.AddRange(rtns);
                */
            }

            return enchList;
        }

        public static List<Enchant> GetAllEnchantWithEnchantType(EnchantType eType)
        {
            if (!eType.HasSkill())
            {
                var rtn = new Enchant { Type = eType, Skill = SkillLists.NonSkill };
                return new List<Enchant> { rtn };
            }

            var skills = Lists.SkList.GetSkillListOfEnchantType(eType);

            var rtns = skills.Select(sk => new Enchant { Type = eType, Skill = sk }).ToList();

            return rtns;
        }
    }

    //すべてのエンチャントに対し、最強強度を持つエンチャント銘のランキングリストを持つクラス
    internal class MaxEnchantSignatureLists
    {
        public List<MaxEnchantSignatures> MaxEnchantSigList { get; private set; }

        public MaxEnchantSignatureLists(bool load = true)
        {
            //読み込み

            if(load)
            {
                var proxyList = StaticJson.Load<List<MESproxy>>("MESList");

                MaxEnchantSigList = proxyList.Select(pl => GetMES(pl)).ToList();
            }
        }

        /// <summary>
        /// 静的jsonを読み込んでいる場合に、SignatureList.SearchByEnchantを代替する
        /// </summary>
        /// <param name="ench"></param>
        /// <param name="pageLimit"></param>
        /// <returns></returns>
        public List<Signature> SearchByEnchant(Enchant ench, int pageLimit)
        {
            var pair = MaxEnchantSigList.First(mes => mes.Ench.Equals(ench));

            var limited = pair.Sigs.Where(sig => sig.Page <= pageLimit);

            return limited.ToList();
        }

        //ファイル書き出し用
        public void SetMaxEnchantSigList(List<MaxEnchantSignatures> mes)
        {
            MaxEnchantSigList = mes;
        }

        //ファイル書き出し用
        public void Save()
        {
            var proxys = MaxEnchantSigList.Select(mes => GetProxy(mes)).ToList();

            StaticJson.Save<List<MESproxy>>("MESList", proxys);
        }

        internal List<Signature> GetSignatureRankingList()
        {
            throw new NotImplementedException();
        }

        private MESproxy GetProxy(MaxEnchantSignatures mes)
        {
            var etSkStr = "{0}-{1}".Args(mes.Ench.Type.ID, mes.Ench.Skill.ID);
            var signos = mes.Sigs.Select(sig => sig.No).ToList();

            return new MESproxy { EtSkStr = etSkStr, SignatureNos = signos };
        }

        private MaxEnchantSignatures GetMES(MESproxy proxy)
        {
            var keys = proxy.EtSkStr.Split('-');
            int etID = int.Parse(keys[0]);
            int skID = int.Parse(keys[1]);
            //IDでEnchantTypeとSkillを引っ張ってくる
            var ench = new Enchant { Type = Lists.ETList.GetEnchantType(etID), Skill = Lists.SkList.GetSkill(skID) };

            var sigs = proxy.SignatureNos.Select(sno => Lists.SigList.GetSignature(sno)).ToList();

            return new MaxEnchantSignatures { Ench = ench, Sigs = sigs };

        }

        //上記クラスのjsonプロキシ
        public class MESproxy
        {
            //EnchantTypeID-SkillID形式の文字列
            public string EtSkStr { get; set; }
            public List<int> SignatureNos { get; set; }
        }

    }

    internal class MaxEnchantSignatures
    {
        internal Enchant Ench { get; set; }
        internal List<Signature> Sigs { get; set; }

    }

}
