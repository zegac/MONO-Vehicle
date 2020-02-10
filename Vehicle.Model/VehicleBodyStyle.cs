using System;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleBodyStyle : IVehicleBodyStyle
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ModelId { get; set; }

        #endregion Properties


    }
}
