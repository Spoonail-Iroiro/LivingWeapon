using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivingWeapon;

namespace UISandbox_LivingWeapon
{
    public class GenerateTestData
    {
        public GenerateTestData() { }

        public SelectedEnchants GenerateSelectedEnchants()
        {
            var selEnch = new SelectedEnchants();

            var sampleSig = Lists.SigList.GetSignature(10000);

            var ench = Lists.GetEnchant(sampleSig);

            for (var i = 0; i < 10; ++i)
            {
                selEnch.Add(ench, 5600);
            }

            return selEnch;

        }

    }
}
