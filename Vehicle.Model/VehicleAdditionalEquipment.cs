using System;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleAdditionalEquipment : IVehicleAdditionalEquipment
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public string Name { get; set; }

        #endregion Properties
    }
}