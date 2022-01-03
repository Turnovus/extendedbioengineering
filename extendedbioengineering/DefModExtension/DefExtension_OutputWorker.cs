using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace extendedbioengineering
{
    class DefExtension_OutputWorker : DefModExtension
    {
        public Type outputWorker = typeof(OutputWorker);

        [Unsaved(false)]
        private OutputWorker workerInt;

        public OutputWorker Worker
        {
            get
            {
                if (workerInt == null)
                {
                    workerInt = (OutputWorker)Activator.CreateInstance(outputWorker);
                }
                return workerInt;
            }
        }
    }
}
