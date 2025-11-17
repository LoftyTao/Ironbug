using Grasshopper.Kernel;
using Ironbug.Grasshopper.Properties;
using System;
namespace Ironbug.Grasshopper.Component
{
    public class Ironbug_SolarCollectorPerformancePhotovoltaicThermalSimple : Ironbug_HVACWithParamComponent
    {
        public Ironbug_SolarCollectorPerformancePhotovoltaicThermalSimple()
          : base("IB_SolarCollectorPerformancePhotovoltaicThermalSimple", "PVT_Performance",
              "Description",
              "Ironbug", "02:LoopComponents",
              typeof(HVAC.IB_SolarCollectorPerformancePhotovoltaicThermalSimple_FieldSet))
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.quarternary;

        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
        }
        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("IB_SolarCollectorPerformancePhotovoltaicThermalSimple", "PVT_Performance", "Connect to Ironbug_SolarCollectorFlatPlatePhotovoltaicThermal", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var obj = new HVAC.IB_SolarCollectorPerformancePhotovoltaicThermalSimple();
            this.SetObjParamsTo(obj);
            DA.SetData(0, obj);
        }

        protected override System.Drawing.Bitmap Icon => Resources.PTV_Performance;

        public override Guid ComponentGuid => new Guid("{BB7DD988-FEED-4F83-A3D0-53D70B0C2D7C}");

    }

}