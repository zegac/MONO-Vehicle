using System;

namespace Vehicle.Model.Common
{
    public interface IVehicleSeatType
    {
        Guid Id { get; set; }
        string Name { get; set; }
        Guid ModelId { get; set; }
    }
}
