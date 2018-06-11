using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivingWeapon
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //テスト
            //Lists.Init(Version.OO, WeaponType.Ranged, true);
            //var form = new SelectSigForm();
            
            //本番
            var form = new SelectSignatureListForm();

            Application.Run(form);
        }
    }
}
