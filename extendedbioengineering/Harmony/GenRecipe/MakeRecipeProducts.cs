using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Verse;
using RimWorld;

namespace extendedbioengineering
{
    [HarmonyPatch(typeof(GenRecipe))]
    [HarmonyPatch("MakeRecipeProducts")]
    static class MakeRecipeProducts
    {
        public static void Postfix(
            RecipeDef recipeDef,
            List<Thing> ingredients,
            ref IEnumerable<Thing> __result)
        {
            DefExtension_OutputWorker extension = recipeDef.GetModExtension<DefExtension_OutputWorker>();
            if (extension == null || extension.outputWorker == null)
            {
                return;
            }

            __result = __result.Concat(extension.Worker.OutputFromIngredients(ingredients));
        }
    }
}
