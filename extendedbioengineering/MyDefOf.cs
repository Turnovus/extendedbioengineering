using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace extendedbioengineering
{
    [DefOf]
    public class MyDefOf : DefOf
    {
        // public static ThingDef EB_SimpleSonicRepeller;

        public static IncidentDef VFEI_GiantInfestation;

        static MyDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MyDefOf));
        }
    }
}
