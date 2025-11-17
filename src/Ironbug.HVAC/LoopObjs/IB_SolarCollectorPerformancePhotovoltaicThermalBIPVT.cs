using Ironbug.HVAC.BaseClass;
using OpenStudio;
using System;

namespace Ironbug.HVAC
{
    public class IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT : IB_SolarCollectorPerformancePhotovoltaicThermal
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT();

        private static SolarCollectorPerformancePhotovoltaicThermalBIPVT NewDefaultOpsObj(Model model) => new SolarCollectorPerformancePhotovoltaicThermalBIPVT(model);

        public IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT() : base(NewDefaultOpsObj)
        {
        }

        public override ModelObject ToOS(Model model)
        {
            var opsObj = base.OnNewOpsObj(NewDefaultOpsObj, model);
            return opsObj;
        }

    }


    public sealed class IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT_FieldSet
        : IB_FieldSet<IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT_FieldSet, SolarCollectorPerformancePhotovoltaicThermalBIPVT>
    {
        private IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT_FieldSet() { }
    }
}
