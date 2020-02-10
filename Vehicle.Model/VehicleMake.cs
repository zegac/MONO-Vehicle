using System;
using System.Collections.Generic;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleMake : IVehicleMake
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }

        #endregion Properties
        public List<IVehicleModel> Items { get; set; }
    }
}