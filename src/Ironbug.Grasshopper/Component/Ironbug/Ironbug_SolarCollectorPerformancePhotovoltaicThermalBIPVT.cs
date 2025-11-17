using Grasshopper.Kernel;
using Ironbug.Grasshopper.Properties;
using System;
namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_SolarCollectorPerformancePhotovoltaicThermalBIPVT : Ironbug_HVACWithParamComponent
    {
        public Ironbug_SolarCollectorPerformancePhotovoltaicThermalBIPVT()
          : base("IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT", "BIPVT_Performance",
              "Description",
              "Ironbug", "02:LoopComponents",
              typeof(HVAC.IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT_FieldSet))
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.quarternary;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
        }
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT", "BIPVT_Performance", "Connect to Ironbug_SolarCollectorFlatPlatePhotovoltaicThermal", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var obj = new HVAC.IB_SolarCollectorPerformancePhotovoltaicThermalBIPVT();
            this.SetObjParamsTo(obj);
            DA.SetData(0, obj);
        }

        protected override System.Drawing.Bitmap Icon => Resources.BIPVT_Performance;

        public override Guid ComponentGuid => new Guid("{1AEC1CAA-08AD-4151-9813-007DB14F4363}");

    }

}