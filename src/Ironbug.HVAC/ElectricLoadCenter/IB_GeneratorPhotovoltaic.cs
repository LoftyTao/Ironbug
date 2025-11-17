using Ironbug.HVAC.BaseClass;
using Newtonsoft.Json;
using OpenStudio;
using System;
using System.Runtime.Serialization;

namespace Ironbug.HVAC
{
    public class IB_GeneratorPhotovoltaic : IB_Generator
    {
        protected override Func<IB_ModelObject> IB_InitSelf => () => new IB_GeneratorPhotovoltaic();

        private static GeneratorPhotovoltaic NewDefaultOpsObj(Model model) => GeneratorPhotovoltaic.simple(model);

        [DataMember]
        private string SurfaceID { get; set; }

        [DataMember]
        private bool IsPVT { get; set; }

        private IB_PhotovoltaicPerformance _performance => this.GetChild<IB_PhotovoltaicPerformance>(0);

        [JsonConstructor]
        private IB_GeneratorPhotovoltaic(bool forDeserialization) : base(null)
        {
        }

        public IB_GeneratorPhotovoltaic() : base(NewDefaultOpsObj)
        {
            this.AddChild(null);
        }

        public override IB_ModelObject Duplicate()
        {
            var dup = base.Duplicate() as IB_GeneratorPhotovoltaic;
            dup.SurfaceID = this.SurfaceID;
            dup.IsPVT = this.IsPVT;
            return dup;
        }

        public void SetSurface(string surfaceID)
        {
            SurfaceID = surfaceID;
        }

        public void SetIsPVT(bool isPVT)
        {
            IsPVT = isPVT;
        }

        public void SetPhotovoltaicPerformance(IB_PhotovoltaicPerformance performance)
        {
            this.SetChild(0, performance);
        }

        public override Generator ToOS(Model model)
        {
            var trackingID = string.Empty;
            if (IsPVT)
            {
                // shared obj in IB_SolarCollectorFlatPlatePhotovoltaicThermal
                trackingID = this.GetTrackingID();
                var objInModel = this.GetIfInModel<GeneratorPhotovoltaic>(model, trackingID);
                if (objInModel != null)
                    return objInModel;
            }

            // create a new one
            if (string.IsNullOrEmpty(SurfaceID))
                throw new ArgumentException("Invalid shading surface ID");

            var oShade = model.getShadingSurfaceByName(SurfaceID);
            if (oShade == null || oShade.isNull())
                throw new ArgumentException($"Invalid shading surface ID: {SurfaceID}");
            if (!oShade.is_initialized())
                throw new ArgumentException($"Invalid shading surface ID: {SurfaceID}");

            var shd = oShade.get();

            GeneratorPhotovoltaic obj = null;
            if (_performance == null)
            {
                obj = base.OnNewOpsObj((m) => GeneratorPhotovoltaic.simple(m), model);
            }
            else if (_performance is IB_PhotovoltaicPerformanceSimple simple)
            {
                obj = base.OnNewOpsObj((m) => GeneratorPhotovoltaic.simple(m), model);
                var perf = obj.photovoltaicPerformance()?.to_PhotovoltaicPerformanceSimple();
                if (perf.is_initialized())
                    simple.ApplyAttributesToObj(model, perf.get());

            }
            else if (_performance is IB_PhotovoltaicPerformanceSandia sandia)
            {
                obj = base.OnNewOpsObj((m) => GeneratorPhotovoltaic.sandia(m), model);
                var perf = obj.photovoltaicPerformance()?.to_PhotovoltaicPerformanceSandia();
                if (perf.is_initialized())
                    sandia.ApplyAttributesToObj(model, perf.get());

            }
            else if (_performance is IB_PhotovoltaicPerformanceEquivalentOneDiode oneDiode)
            {
                obj = base.OnNewOpsObj((m) => GeneratorPhotovoltaic.equivalentOneDiode(m), model);
                var perf = obj.photovoltaicPerformance()?.to_PhotovoltaicPerformanceEquivalentOneDiode();
                if (perf.is_initialized())
                    oneDiode.ApplyAttributesToObj(model, perf.get());
            }
            else
            {
                throw new NotImplementedException($"Non-supported PV performance type: {_performance.GetType().Name}");
            }

            obj.setSurface(shd);
            if (IsPVT)
                OpsIDMapper.TryAdd(trackingID, obj.handle());
            return obj;
        }

        private GeneratorPhotovoltaic TryGetExisting(Model model)
        {
            var trackingID = this.GetTrackingID();
            var objInModel = this.GetIfInModel<GeneratorPhotovoltaic>(model, trackingID);
            return objInModel;
        }

    }

    public sealed class IB_GeneratorPhotovoltaic_FieldSet
       : IB_FieldSet<IB_GeneratorPhotovoltaic_FieldSet, GeneratorPhotovoltaic>
    {

        private IB_GeneratorPhotovoltaic_FieldSet() { }

    }


}
