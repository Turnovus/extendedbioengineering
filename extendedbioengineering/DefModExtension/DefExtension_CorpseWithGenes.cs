using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace extendedbioengineering
{
    class DefExtension_CorpseWithGenes : DefModExtension
    {
        public List<WeightedGene> genes;
        public int baseChancePercent = 50;
        public ThingDef thingDef = null;
    }
}
