using System;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleEngineType : IVehicleEngineType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public Guid ModelId { get; set; }
    }
}
