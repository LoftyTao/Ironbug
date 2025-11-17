using Ironbug.HVAC.BaseClass;
using Newtonsoft.Json;
using OpenStudio;
using System;

namespace Ironbug.HVAC
{
    public class IB_SolarCollectorFlatPlatePhotovoltaicThermal : IB_HVACObject, IIB_PlantLoopObjects, IIB_AirLoopObject
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_SolarCollectorFlatPlatePhotovoltaicThermal();

        private static SolarCollectorFlatPlatePhotovoltaicThermal NewDefaultOpsObj(Model model) => new SolarCollectorFlatPlatePhotovoltaicThermal(model);


        private IB_GeneratorPhotovoltaic _gpv => this.GetChild<IB_GeneratorPhotovoltaic>(0);
        private IB_SolarCollectorPerformancePhotovoltaicThermal _scp => this.GetChild<IB_SolarCollectorPerformancePhotovoltaicThermal>(1);

        [JsonConstructor]
        private IB_SolarCollectorFlatPlatePhotovoltaicThermal(bool forDeserialization) : base(null)
        {
        }

        public IB_SolarCollectorFlatPlatePhotovoltaicThermal() : base(NewDefaultOpsObj)
        {
            this.AddChild(null);
            this.AddChild(null);
        }

        public void SetPvGenerator(IB_GeneratorPhotovoltaic pv)
        {
            this.SetChild(0, pv);
        }

        public void SetSolarCollectorPerformance(IB_SolarCollectorPerformancePhotovoltaicThermal performance)
        {
            this.SetChild(1, performance);
        }


        public override HVACComponent ToOS(Model model)
        {
            // Ensure the PV generator object is created in the model
            if (_gpv == null)
                throw new ArgumentException("A photovoltaic generator object must be assigned.");
            var generator = _gpv.ToOS(model) as GeneratorPhotovoltaic;
            var oShade = generator.surface();
            if (!oShade.is_initialized())
                throw new ArgumentException("The photovoltaic generator must be associated with a surface.");

            // Set the shade surface
            var shd = oShade.get();
            var opsObj = base.OnNewOpsObj(NewDefaultOpsObj, model);
            opsObj.setSurface(shd);
            opsObj.setGeneratorPhotovoltaic(generator);


            // Set the PV performance
            if (this._scp != null)
            {
                var p = _scp.ToOS(model);
                if (p is SolarCollectorPerformancePhotovoltaicThermalSimple sp)
                {
                    opsObj.setSolarCollectorPerformance(sp);
                }
                else if (p is SolarCollectorPerformancePhotovoltaicThermalBIPVT bp)
                {
                    opsObj.setSolarCollectorPerformance(bp);
                }
            }

            return opsObj;
        }


    }

    public sealed class IB_SolarCollectorFlatPlatePhotovoltaicThermal_FieldSet
            : IB_FieldSet<IB_SolarCollectorFlatPlatePhotovoltaicThermal_FieldSet, SolarCollectorFlatPlatePhotovoltaicThermal>
    {
        private IB_SolarCollectorFlatPlatePhotovoltaicThermal_FieldSet() { }
    }
}
