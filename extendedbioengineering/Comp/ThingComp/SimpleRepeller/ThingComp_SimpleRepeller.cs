using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace extendedbioengineering
{
    class ThingComp_SimpleRepeller : ThingComp
    {
        public ThingComp_SimpleRepellerProperties Props => (ThingComp_SimpleRepellerProperties)props;

        public override string CompInspectStringExtra()
        {
            return base.CompInspectStringExtra() + "StringRepelSuccessRate".Translate() + ": " + Props.successRate.ToString() + "%";
        }
    }
}
