using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using InsectoidBioengineering;

namespace extendedbioengineering
{
    class WorkGiver_InsertFirstGenomeMakeshift : WorkGiver_InsertFirstGenome
    {
        public override ThingRequest PotentialWorkThingRequest => ThingRequest.ForDef(ThingDef.Named("EB_SimpleBioengineeringIncubator"));
    }

    class WorkGiver_InsertSecondGenomeMakeshift : WorkGiver_InsertSecondGenome
    {
        public override ThingRequest PotentialWorkThingRequest => ThingRequest.ForDef(ThingDef.Named("EB_SimpleBioengineeringIncubator"));
    }

    class WorkGiver_InsertThirdGenomeMakeshift : WorkGiver_InsertThirdGenome
    {
        public override ThingRequest PotentialWorkThingRequest => ThingRequest.ForDef(ThingDef.Named("EB_SimpleBioengineeringIncubator"));
    }
}
