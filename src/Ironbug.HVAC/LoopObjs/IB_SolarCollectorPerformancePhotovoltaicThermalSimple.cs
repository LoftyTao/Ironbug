using Ironbug.HVAC.BaseClass;
using OpenStudio;
using System;

namespace Ironbug.HVAC
{
    public class IB_SolarCollectorPerformancePhotovoltaicThermalSimple : IB_SolarCollectorPerformancePhotovoltaicThermal
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_SolarCollectorPerformancePhotovoltaicThermalSimple();

        private static SolarCollectorPerformancePhotovoltaicThermalSimple NewDefaultOpsObj(Model model) => new SolarCollectorPerformancePhotovoltaicThermalSimple(model);

        public IB_SolarCollectorPerformancePhotovoltaicThermalSimple() : base(NewDefaultOpsObj)
        {
        }

        public override ModelObject ToOS(Model model)
        {
            var opsObj = base.OnNewOpsObj(NewDefaultOpsObj, model);
            return opsObj;
        }

    }


    public sealed class IB_SolarCollectorPerformancePhotovoltaicThermalSimple_FieldSet
        : IB_FieldSet<IB_SolarCollectorPerformancePhotovoltaicThermalSimple_FieldSet, SolarCollectorPerformancePhotovoltaicThermalSimple>
    {
        private IB_SolarCollectorPerformancePhotovoltaicThermalSimple_FieldSet() { }
    }
}
