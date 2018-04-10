using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWeapon
{
    internal class SelectedEnchants
    {
        internal class EnchantAndSignatures
        {
            public Enchant Enchant { get; private set; }
            public List<Signature> Signatures { get; private set; }

            internal EnchantAndSignatures(Enchant enchant)
            {
                Enchant = enchant;

                Signatures = Lists.SigList.SearchByEnchant(enchant).ToList();
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
        internal List<EnchantAndSignatures> ManageList { get; private set; }
        public List<int> SignatureSearchCountList { get; private set; }

        internal SelectedEnchants()
        {
            ManageList = new List<EnchantAndSignatures>();
            SignatureSearchCountList = new List<int>();
        }

        internal bool Add(Enchant enchant)
        {
            var enchSig = new EnchantAndSignatures(enchant);

            if(enchSig.Signatures.Count == 0)
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
        internal void Next()
        {
            var min = SignatureSearchCountList.Min();

            var minIndex = SignatureSearchCountList.IndexOf(min);

            SignatureSearchCountList[minIndex] += 1;
        }
        
        internal List<Signature> GetEnchantingSignatureList()
        {
            //TODO OutOfRangeExceptionで探索全失敗
            var sigs = ManageList.Select((EnchSig, idx) => EnchSig.Signatures[SignatureSearchCountList[idx]]).ToList();

            return sigs;
        }

        /// <summary>
        /// SignatureSearchCountListがすべて0（すべてのエンチャントで強度1位）のエンチャント銘セットを返します
        /// </summary>
        /// <returns></returns>
        internal List<Signature> GetIdealEnchantingSignatureList()
        {
            var temp = SignatureSearchCountList;

            //一時的に全て0に
            SignatureSearchCountList = ManageList.Select(eSig => 0).ToList();

            var rtn = GetEnchantingSignatureList();

            SignatureSearchCountList = temp;

            return rtn;
        }
        
        //index番目のエンチャントについて、強度valueRank（0オリジン）目のエンチャント銘を返す
        internal Signature GetEnchantingSignature(int index, int valueRank)
        {
            var selectedEnchantingSignature = ManageList[index].Signatures[valueRank];

            return selectedEnchantingSignature;

        }

        //index番目のエンチャントについて、GetEnchantingSignatureListで返すvalueRankをセットする
        internal void SetValueRank(int index, int valueRank)
        {
            SignatureSearchCountList[index] = valueRank;
        }
    }

    internal class SearchingEnchant
    {
        internal Signature EnchantingSignature { get;  private set;}
        //育成開始レベル
        internal int MinLevel { get; private set; }
        //最期のレベルアップの前レベル（育成後レベル-1）
        internal int MaxLevel { get; private set; }

        internal List<Signature> ChoiceSignatures { get; private set; }

        internal SearchingEnchant(int startLevel, int goalLevel, Signature enchantingSignature)
        {
            EnchantingSignature = enchantingSignature;
            MinLevel = startLevel;
            MaxLevel = goalLevel - 1;

            ChoiceSignatures = new List<Signature>();

            //MinLevel～MaxLevelの各レベルについて、エンチャント銘のエンチャントに対応する選択エンチャントを決定する
            for(var i = 0; i<(goalLevel - MinLevel); ++i)
            {
                var level = MinLevel + i;

                var gap = (level - 1) * 10;

                var gappedSigNo = EnchantingSignature.No - gap;

                var choices = new List<Signature>();

                choices.Add(Lists.SigList.GetSignature(gappedSigNo));
                choices.Add(Lists.SigList.GetSignature(gappedSigNo-1));
                choices.Add(Lists.SigList.GetSignature(gappedSigNo-2));

                //選択不可銘を除外
                choices.RemoveAll(sig => !sig.Selectable);

                //選択候補銘の中で最も高い血吸いレベル
                var maxBlood = choices.Max(sig => sig.BloodLevel);

                var choice = choices.First(sig => sig.BloodLevel == maxBlood);

                ChoiceSignatures.Add(choice);
            }
        }

        internal Signature GetChoiceSignature(int level)
        {
            if (!(MinLevel <= level && level <= MaxLevel) ) return null;

            return ChoiceSignatures[level - MinLevel];
        }
    }
}
