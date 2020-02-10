using System;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleColor : IVehicleColor
    {
        #region Properties

        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public string Name { get; set; }

        #endregion Properties
    }
}