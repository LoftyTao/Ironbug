using OpenStudio;
using System;

namespace Ironbug.HVAC.BaseClass
{
    public abstract class IB_SolarCollectorPerformancePhotovoltaicThermal : IB_ModelObject
    {
        public IB_SolarCollectorPerformancePhotovoltaicThermal(Func<OpenStudio.Model, ModelObject> ghostObjInit) : base(ghostObjInit)
        {
        }
        public abstract ModelObject ToOS(Model model);

    }
}
