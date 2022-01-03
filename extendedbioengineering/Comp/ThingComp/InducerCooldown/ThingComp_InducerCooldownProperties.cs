using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace extendedbioengineering
{
    class ThingComp_InducerCooldownProperties : CompProperties
    {
        public float daysToFire = 1f;

        public ThingComp_InducerCooldownProperties() => compClass = typeof(ThingComp_InducerCooldown);
    }
}
