using OpenStudio;
using System;

namespace Ironbug.HVAC.BaseClass
{
    public abstract class IB_PhotovoltaicPerformance : IB_ModelObject
    {
        public IB_PhotovoltaicPerformance(Func<OpenStudio.Model, ModelObject> ghostObjInit) : base(ghostObjInit)
        {
        }
        public abstract PhotovoltaicPerformance ToOS(Model model);

    }
}
