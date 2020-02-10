using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IVehicleSeatTypeService
    {
        Task<List<VehicleSeatType>> GetSeatTypesAsync();
        Task<VehicleSeatType> GetSeatTypeByIdAsync(Guid id);
    }
}
