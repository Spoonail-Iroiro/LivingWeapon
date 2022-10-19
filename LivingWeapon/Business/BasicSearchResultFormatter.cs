using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LivingWeapon.MyExt;

namespace LivingWeapon
{
    public static class BasicSearchResultFormatter
    {
        public static string GetResultStr(SignatureSearch searched)
        {
            var result = searched.Result;

            return result.Select((sEnch, index) =>
            {
                var level = searched.StartLevel + index;

                var choice = sEnch.GetChoiceSignature(level);

                return "{0,2}=>{1,2} |{2,7},{3,6}ページ, {4}, {5}, 強度{6}, （血吸{7}）".Args(
                    level.ToString().PadLeft(2),
                    (level + 1).ToString().PadLeft(2),
                    choice.No,
                    choice.Page,
                    choice.Name,
                    sEnch.EnchantingSignature.EnchantStr,
                    sEnch.EnchantingSignature.Value,
                    choice.BloodLevel);
            })
            .JoinS("\r\n") + "\r\n";
        }

        public static DataTable GetResultTable(SignatureSearch searched)
        {
            var result = searched.Result;

            var table = new DataTable();

            table.Columns.Add(new DataColumn("Lv", typeof(int)));
            table.Columns.Add(new DataColumn("LvUp", typeof(int)));
            table.Columns.Add(new DataColumn("No", typeof(int)));
            table.Columns.Add(new DataColumn("ページ", typeof(int)));
            table.Columns.Add(new DataColumn("銘", typeof(string)));
            table.Columns.Add(new DataColumn("選択するエンチャント", typeof(string)));
            table.Columns.Add(new DataColumn("強度", typeof(int)));
            table.Columns.Add(new DataColumn("血吸", typeof(int)));

            var rows = result.Select((sEnch, index) =>
            {
                var level = searched.StartLevel + index;
                var choice = sEnch.GetChoiceSignature(level);

                return new object[]
                {
                    level,
                    level +1,
                    choice.No,
                    choice.Page,
                    choice.Name,
                    sEnch.EnchantingSignature.EnchantStr,
                    sEnch.EnchantingSignature.Value,
                    choice.BloodLevel
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
