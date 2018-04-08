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
    }
}
