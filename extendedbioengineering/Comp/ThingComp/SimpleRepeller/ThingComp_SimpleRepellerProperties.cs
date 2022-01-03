using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace extendedbioengineering
{
    class ThingComp_SimpleRepellerProperties : CompProperties
    {
        public float successRate = 0f;

        public ThingComp_SimpleRepellerProperties() => compClass = typeof(ThingComp_SimpleRepeller);
    }
}
