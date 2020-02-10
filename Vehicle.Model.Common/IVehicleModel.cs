using System;

namespace Vehicle.Model.Common
{
    public interface IVehicleModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        Guid MakeId { get; set; }
    }
}
