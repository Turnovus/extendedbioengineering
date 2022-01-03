using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace extendedbioengineering
{
    class ThingComp_CorpseWithGenesProperties : CompProperties
    {
        public List<WeightedGene> genes;
        public int baseChancePercent = 50;
        public ThingDef thingDef = null;

        public ThingComp_CorpseWithGenesProperties() => compClass = typeof(ThingComp_CorpseWithGenes);
    }
}
