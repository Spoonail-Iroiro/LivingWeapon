using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWeapon
{
    public class SelectedEnchants
    {
        public class EnchantAndSignatures
        {
            public Enchant Enchant { get; private set; }
            public List<Signature> Signatures { get; private set; }

            public EnchantAndSignatures(Enchant enchant, int pageLimit)
            {
                Enchant = enchant;

                Signatures = Lists.SigList.SearchByEnchant(enchant, pageLimit).ToList();
            }
        }

        //現在探索対象になるエンチャント銘セットを表す
        //ManageListには選択されたエンチャントと、そのエンチャントの強度上位のエンチャント銘が格納されている
        //SignatureSearchCountListは強度上位のエンチャント群のそれぞれ何位を拾うか表す
        //現在探索対象になるエンチャント銘セット＝
        //ManageList[0].Signatures[SignatureSearchCountList[0]], 
        //ManageList[1].Signatures[SignatureSearchCountList[1]],
        //...
        //SSCLは初期状態で0,0,0...なので選択されたエンチャントそれぞれについて一番強度の高いエンチャント銘を拾う
        //そのエンチャント銘セットの探索で解がなければ1,0,0…それでもなければ1,1,0…とエンチャント強度を妥協していく
        public List<EnchantAndSignatures> ManageList { get; private set; }
        public List<int> SignatureSearchCountList { get; private set; }

        public SelectedEnchants()
        {
            ManageList = new List<EnchantAndSignatures>();
            SignatureSearchCountList = new List<int>();
        }

        public bool Add(Enchant enchant, int pageLimit)
        {
            var enchSig = new EnchantAndSignatures(enchant, pageLimit);

            if (enchSig.Signatures.Count == 0)
            {
                return false;
            }

            ManageList.Add(enchSig);
            SignatureSearchCountList.Add(0);

            return false;
        }

        /// <summary>
        /// 探索エンチャント銘セットを次のものに更新します
        /// </summary>
        /// <remarks>
        /// 管理リスト中のエンチャントの中から1つ選んでエンチャント銘を1つ格下のものにする
        /// </remarks>
        public void Next()
        {
            var min = SignatureSearchCountList.Min();

            var minIndex = SignatureSearchCountList.IndexOf(min);

            SignatureSearchCountList[minIndex] += 1;
        }

        public List<Signature> GetEnchantingSignatureList()
        {
            //TODO OutOfRangeExceptionで探索全失敗
            var sigs = ManageList.Select((EnchSig, idx) => EnchSig.Signatures[SignatureSearchCountList[idx]]).ToList();

            return sigs;
        }

        /// <summary>
        /// SignatureSearchCountListがすべて0（すべてのエンチャントで強度1位）のエンチャント銘セットを返します
        /// </summary>
        /// <returns></returns>
        public List<Signature> GetIdealEnchantingSignatureList()
        {
            var temp = SignatureSearchCountList;

            //一時的に全て0に
            SignatureSearchCountList = ManageList.Select(eSig => 0).ToList();

            var rtn = GetEnchantingSignatureList();

            SignatureSearchCountList = temp;

            return rtn;
        }

        //index番目のエンチャントについて、強度valueRank（0オリジン）目のエンチャント銘を返す
        public Signature GetEnchantingSignature(int index, int valueRank)
        {
            var selectedEnchantingSignature = ManageList[index].Signatures[valueRank];

            return selectedEnchantingSignature;

        }

        //index番目のエンチャントについて、GetEnchantingSignatureListで返すvalueRankをセットする
        public void SetValueRank(int index, int valueRank)
        {
            SignatureSearchCountList[index] = valueRank;
        }
    }

    //SearchingEnchantで3つor8つの候補の中からどの基準で選んで返すか
    public enum SearchingEnchantModes
    {
        LessBloodLevel, //血吸レベルが最小
        Top             //上の選択肢（つまり[a]か[b]）
    }

    public class SearchingEnchant
    {
        public Signature EnchantingSignature { get; private set; }
        //育成開始レベル
        public int MinLevel { get; private set; }
        //最期のレベルアップの前レベル（育成後レベル-1）
        public int MaxLevel { get; private set; }

        public List<Signature> ChoiceSignatures { get; private set; }

        public SearchingEnchantModes _mode = SearchingEnchantModes.LessBloodLevel;

        public SearchingEnchant(int startLevel, int goalLevel, Signature enchantingSignature, SearchingEnchantModes mode = SearchingEnchantModes.LessBloodLevel)
        {
            EnchantingSignature = enchantingSignature;
            MinLevel = startLevel;
            MaxLevel = goalLevel - 1;

            ChoiceSignatures = new List<Signature>();

            //MinLevel～MaxLevelの各レベルについて、エンチャント銘のエンチャントに対応する選択エンチャントを決定する
            for (var i = 0; i < (goalLevel - MinLevel); ++i)
            {
                var level = MinLevel + i;

                var gap = (level - 1) * 10;

                var gappedSigNo = EnchantingSignature.No - gap;

                var choices = new List<Signature>();

                if (Lists.SelectedVersion == Version.OO)
                {
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 1));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 2));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 3));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 4));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 5));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 6));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 7));
                }
                else
                {
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 1));
                    choices.Add(Lists.SigList.GetSignature(gappedSigNo - 2));
                }

                //選択不可銘を除外
                choices.RemoveAll(sig => !sig.Selectable);

                var choice = GetAppropriateSignatureFromChoices(choices);


                ChoiceSignatures.Add(choice);
            }
        }

        Signature GetAppropriateSignatureFromChoices(List<Signature> choices)
        {
            switch (_mode)
            {
                case SearchingEnchantModes.LessBloodLevel:
                    //選択候補銘の中で最も高い血吸いレベル
                    var maxBlood = choices.Max(sig => sig.BloodLevel);

                    var choice = choices.First(sig => sig.BloodLevel == maxBlood);
                    return choice;
                    break;
                case SearchingEnchantModes.Top:
                    return choices.First();
                    break;
                default:
                    throw new Exception($"想定しないモードです{_mode}");
                    break;
            }
        }

        public Signature GetChoiceSignature(int level)
        {
            if (!(MinLevel <= level && level <= MaxLevel)) return null;

            return ChoiceSignatures[level - MinLevel];
        }
    }
}
