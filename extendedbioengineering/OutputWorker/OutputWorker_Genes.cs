using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace extendedbioengineering
{
    class OutputWorker_Genes : OutputWorker
    {
        public override IEnumerable<Thing> OutputFromIngredients(IEnumerable<Thing> ingredients)
        {
            Random random = new Random();

            ThingComp_TissueSample sample;
            List<WeightedGene> genes;
            List<ThingDef> resultPool;
            ThingDef result;
            
            foreach (Thing ingredient in ingredients)
            {
                sample = ingredient.TryGetComp<ThingComp_TissueSample>();
                if (sample == null)
                    continue;

                genes = sample.genes;
                if (genes.NullOrEmpty())
                {
                    Log.Error(String.Format("Tried to extract sample from {0} with no genes. {1}", sample.source, ingredient.ToString()));
                    continue;
                }

                resultPool = new List<ThingDef>();
                foreach (WeightedGene geneChoice in genes)
                {
                    for (int i = 0; i < geneChoice.weight; i++)
                    {
                        if (geneChoice.gene == null)
                        {
                            Log.Error(String.Format("Tissue sample from {0} has null genes.", sample.source));
                        }
                        else
                        {
                            resultPool.Add(geneChoice.gene);
                        }
                    }
                }
                
                result = resultPool[random.Next(resultPool.Count)];
                yield return ThingMaker.MakeThing(result);
            }
        }
    }
}
