using Grasshopper.Kernel;
using Ironbug.Grasshopper.Properties;
using System;

namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_SolarCollectorFlatPlatePhotovoltaicThermal : Ironbug_HVACWithParamComponent
    {
        public Ironbug_SolarCollectorFlatPlatePhotovoltaicThermal()
          : base("IB_SolarCollectorFlatPlatePhotovoltaicThermal", "PVT",
              "Description",
              "Ironbug", "02:LoopComponents",
              typeof(HVAC.IB_SolarCollectorFlatPlatePhotovoltaicThermal_FieldSet))
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.quarternary;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("GeneratorPV", "_pv", "IB_GeneratorPhotovoltaic", GH_ParamAccess.item);
            pManager[pManager.AddGenericParameter("Solar Collector Performance", "sc_performance_", "SolarCollectorPerformancePhotovoltaicThermalSimple or SolarCollectorPerformancePhotovoltaicThermalBIPVT", GH_ParamAccess.item)].Optional = true;
        }
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("IB_SolarCollectorFlatPlatePhotovoltaicThermal", "PVT", "Connect the PhotovoltaicThermal (PVT) Solar Collector to the supply side of a hot water or air loop.", GH_ParamAccess.item);
            pManager.AddGenericParameter("IB_GeneratorPhotovoltaic", "generator", "Connect the PV generator of PVT to ELC Distribution (SubPanel)", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var obj = new HVAC.IB_SolarCollectorFlatPlatePhotovoltaicThermal();
            var pv = (HVAC.IB_GeneratorPhotovoltaic)null;
            var sc_p = (HVAC.BaseClass.IB_SolarCollectorPerformancePhotovoltaicThermal)null;

            if (DA.GetData(0, ref pv))
            {
                var pvDup = pv.Duplicate(renewId: true) as HVAC.IB_GeneratorPhotovoltaic;
                pvDup.SetIsPVT(true);
                obj.SetPvGenerator(pvDup);
                DA.SetData(1, pvDup);
            }

            if (DA.GetData(1, ref sc_p))
            {
                obj.SetSolarCollectorPerformance(sc_p);
            }


            this.SetObjParamsTo(obj);
            var objs = this.SetObjDupParamsTo(obj);
            DA.SetDataList(0, objs);
        }

        protected override System.Drawing.Bitmap Icon => Resources.PTV;

        public override Guid ComponentGuid => new Guid("{0D618AFF-F472-4AB9-BF71-9FAE78C3BC4E}");

    }

}