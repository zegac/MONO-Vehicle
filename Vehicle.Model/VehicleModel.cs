using System;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleModel : IVehicleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MakeId { get; set; }
    }
}
