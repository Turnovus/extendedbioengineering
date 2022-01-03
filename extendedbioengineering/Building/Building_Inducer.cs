using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using VFEI;

namespace extendedbioengineering
{
    class Building_Inducer : Building
    {
        public const int RARE_TICKS_PER_DAY = 240;

        public int countdown = 0;
        public bool canFire = false;
        public CompPowerTrader compPowerTrader;

        public Building_Inducer()
        {
            countdown = -1;
        }

        public int GetNewCountdownTime()
        {
            ThingComp_InducerCooldown comp = this.TryGetComp<ThingComp_InducerCooldown>();
            return comp != null ? (int)(comp.Props.daysToFire * RARE_TICKS_PER_DAY) : RARE_TICKS_PER_DAY;
        }

        public string GetTimeRemaining()
        {
            int countSafe = Math.Max(countdown, 0);
            return (countSafe * RARE_TICKS_PER_DAY).ToStringTicksToPeriod();
        }

        public bool TryFireInducerNow()
        {
            if (TryInfest())
            {
                canFire = false;
                countdown = GetNewCountdownTime();
                return true;
            }
            else
            {
                Messages.Message("StringInducerNeedsBugs".Translate(), MessageTypeDefOf.NeutralEvent);
                return false;
            }
        }

        public bool TryInfest()
        {
            IncidentParms parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, MapHeld);
            parms.faction = Faction.OfInsects;

            if (!IncidentDefOf.Infestation.Worker.CanFireNow(parms))
                return false;

            IncidentDefOf.Infestation.Worker.TryExecute(parms);

            return true;
        }

        public void SetCountdownToNearZero()
        {
            countdown = 1;
        }

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            compPowerTrader = GetComp<CompPowerTrader>();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref countdown, "countdown");
            Scribe_Values.Look(ref canFire, "canFire");
        }

        public override void TickRare()
        {
            base.TickRare();
            if (countdown < 0)
            {
                countdown = GetNewCountdownTime();
                return;
            }
            if (!compPowerTrader.PowerOn)
            {
                canFire = false;
                return;
            }

            if (countdown > 0)
            {
                canFire = false;
                countdown--;
            }
            else
            {
                canFire = true;
            }
        }

        public override string GetInspectString()
        {
            string fireText = canFire ? "\n" + "StringInducerCanFire".Translate() : "\n" + "StringInducerCoolingDown".Translate() + ": " + GetTimeRemaining();
            return base.GetInspectString() + fireText;
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            foreach (Gizmo gizmo in base.GetGizmos())
                yield return gizmo;
            Command_Action Gizmo_FireInducer = new Command_Action();
            Gizmo_FireInducer.defaultLabel = "StringInducerButton".Translate();
            Gizmo_FireInducer.defaultDesc = "StringInducerAction".Translate();
            Gizmo_FireInducer.disabled = !canFire;

            Gizmo_FireInducer.disabledReason = "";
            if (!compPowerTrader.PowerOn)
                Gizmo_FireInducer.disabledReason = "NoPower".Translate();
            else
                Gizmo_FireInducer.disabledReason = "StringInducerCoolingDown".Translate();

            Gizmo_FireInducer.action = () => { TryFireInducerNow(); };

            Gizmo_FireInducer.icon = ThingDefOf.Hive.uiIcon;

            yield return Gizmo_FireInducer;

            if (Prefs.DevMode)
            {
                Command_Action Gizmo_SkipCountdown = new Command_Action();
                Gizmo_SkipCountdown.defaultLabel = "Debug: Skip countdown";
                Gizmo_SkipCountdown.action = (() => { SetCountdownToNearZero(); });
                yield return Gizmo_SkipCountdown;
            }


        }
    }
}
