using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivingWeapon.MyExt;
using System.Data;

namespace LivingWeapon
{
    
    public class Upper15Calc
    {
        int _startLevel;
        int _goalLevel;
        Signature EnchSig { get; set; }
        List<Signature> Result { get; set; } = new List<Signature>();

        public Upper15Calc(int startLevel, int goalLevel, Enchant ench, int pageLimit)
        {
            _startLevel = startLevel;
            _goalLevel = goalLevel;

            var count = goalLevel - startLevel;

            //目標のエンチャントを強度順に取得
            //TODO:ページ制限
            var sigs = Lists.SigList.SearchByEnchant(ench, pageLimit);

            //一番強い強度のエンチャントで選択銘を算出
            //TODO:一番強い強度のエンチャントをリストしたときに、銘リストから飛び出してしまう場合の対策
            this.EnchSig = sigs.First();
            var searchSig = new SearchingEnchant(_startLevel, _goalLevel, EnchSig);

            //例：Lv1→Lv15 エンチャント14個 15 - 1
            this.Result = Enumerable.Range(_startLevel, _goalLevel - _startLevel)
                .Select(level => searchSig.GetChoiceSignature(level))
                .ToList();
        }

        private string GetSigStr(int index)
        {
            var lv = index + _startLevel;
            var choice = Result[index];

            //var selectChar = new String((char)('a' + (sig.No % 17)), 1);

            var resultStr = "{0,2}=>{1,2} |{2,7},{3,6}ページ, {4}, {5}, 強度{6}, （血吸{7}）".Args(
                    lv.ToString().PadLeft(2),
                    (lv + 1).ToString().PadLeft(2),
                    choice.No,
                    choice.Page,
                    choice.Name,
                    EnchSig.EnchantStr,
                    EnchSig.Value,
                    choice.BloodLevel);
            return resultStr;
        }

        public string GetResultStr()
        {
            return Result.Select((sig, idx) => GetSigStr(idx)).JoinS("\r\n");
        }

        public DataTable GetResultTable()
        {
            var table = new DataTable();

            table.Columns.Add(new DataColumn("Lv", typeof(int)));
            table.Columns.Add(new DataColumn("LvUp", typeof(int)));
            table.Columns.Add(new DataColumn("No", typeof(int)));
            table.Columns.Add(new DataColumn("ページ", typeof(int)));
            table.Columns.Add(new DataColumn("銘", typeof(string)));
            table.Columns.Add(new DataColumn("選択するエンチャント", typeof(string)));
            table.Columns.Add(new DataColumn("強度", typeof(int)));

            var rows = Result.Select((sEnch, index) =>
            {
                var level = _startLevel + index;
                var choice = Result[index];

                return new object[]
                {
                    level,
                    level +1,
                    choice.No,
                    choice.Page,
                    choice.Name,
                    EnchSig.EnchantStr,
                    EnchSig.Value
                };
            });

            foreach (var row in rows)
            {
                table.Rows.Add(row);
            }


            return table;
        }

    }
}
