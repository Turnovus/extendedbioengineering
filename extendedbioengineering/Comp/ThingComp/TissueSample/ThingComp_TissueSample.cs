using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace extendedbioengineering
{
    class ThingComp_TissueSample : ThingComp
    {
        public List<WeightedGene> genes;
        public string source = "The void";

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref genes, "genes");
            Scribe_Values.Look(ref source, "source");
        }

        public override string CompInspectStringExtra()
        {
            return base.CompInspectStringExtra() + "StringTissueSource".Translate() + ": " + source;
        }
    }
}
