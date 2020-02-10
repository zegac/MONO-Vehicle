using System;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleSeatType : IVehicleSeatType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ModelId { get; set; }
    }
}
