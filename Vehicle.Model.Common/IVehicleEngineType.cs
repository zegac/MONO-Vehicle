using System;

namespace Vehicle.Model.Common
{
    public interface IVehicleEngineType
    {
        Guid Id { get; set; }
        string Name { get; set; }
        int Power { get; set; }
        Guid ModelId { get; set; }
    }
}
