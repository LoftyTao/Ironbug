namespace Ironbug.HVAC
{
    public class IB_Model
    {
        public IB_HVACSystem HVACSystem { get; set; }
        public IB_EnergyManagementSystem EnergyManagementSystem { get; set; }
        public IB_ElectricLoadCenter ElectricLoadCenter { get; set; }
        public IB_Model()
        {
        }

        public IB_Model(IB_HVACSystem hvac = default, IB_EnergyManagementSystem ems = default, IB_ElectricLoadCenter elc = default)
        {
            HVACSystem = hvac;
            EnergyManagementSystem = ems;
            ElectricLoadCenter = elc;
        }

        public bool SaveToOSM(string osmFile)
        {
            return IB_Utility.SaveToOSM(this, osmFile);
        }

    }
}
