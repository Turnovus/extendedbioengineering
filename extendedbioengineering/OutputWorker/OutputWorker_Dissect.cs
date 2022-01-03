using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace extendedbioengineering
{
    class OutputWorker_Dissect : OutputWorker
    {
        public override IEnumerable<Thing> OutputFromIngredients(IEnumerable<Thing> ingredients)
        {
            Random random = new Random();
            DefExtension_CorpseWithGenes extension;

            foreach (Thing ingredient in ingredients)
            {
                Thing thing = ingredient is Corpse corpse ? corpse.InnerPawn : ingredient;

                extension = thing.def.GetModExtension<DefExtension_CorpseWithGenes>();
                if (extension == null || extension.thingDef == null)
                    continue;

                if (random.Next(100) > extension.baseChancePercent)
                    continue;

                Thing result = ThingMaker.MakeThing(extension.thingDef);
                if (!(result is ThingWithComps))
                {
                    Log.Error("Attempted to attach gene to Thing without comps! " + result.ToString());
                    continue;
                }

                ThingComp_TissueSample tissue = ((ThingWithComps)result).TryGetComp<ThingComp_TissueSample>();
                if (tissue == null)
                {
                    Log.Error("Tried and failed to get CompTissueSample in " + result.def.ToString());
                    continue;
                }

                tissue.genes = extension.genes;
                tissue.source = thing.def.label;
                yield return result;
            }
        }
    }
}
