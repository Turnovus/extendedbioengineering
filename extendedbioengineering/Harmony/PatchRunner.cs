using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using HarmonyLib;

namespace extendedbioengineering
{
    [StaticConstructorOnStartup]
    class PatchRunner
    {
        static PatchRunner()
        {
            new Harmony("com.turnovus.submod.extendedbioengineering").PatchAll();
        }
    }
}
