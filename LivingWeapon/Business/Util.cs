using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingWeapon
{
    public class Util
    {
        public static bool IsAppClosed { get; private set; }

        public static string GetEnchantInfo(Signature sig)
        {
            if (sig == null) return "情報なし\r\n";

            var sigSamp = sig;

            var info = string.Format("{0}番目の銘は{1}という名前で{4}ページ目にあり{6}、「{2}」というエンチャントが強度{3}で付く。血吸レベルは{5}\r\n",
                sigSamp.No,
                sigSamp.Name,
                sigSamp.EnchantStr,
                sigSamp.Value,
                sigSamp.Page,
                sigSamp.BloodLevel,
                sigSamp.Selectable ? "" : "（選択不能）");

            return info;
        }

        public static void ExitApplication()
        {
            IsAppClosed = true;
        }
    }
}
