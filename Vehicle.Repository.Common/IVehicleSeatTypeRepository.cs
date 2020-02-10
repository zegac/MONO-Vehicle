using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IVehicleSeatTypeRepository
    {
        Task<List<VehicleSeatType>> GetSeatTypesAsync();
        Task<VehicleSeatType> GetSeatTypeByIdAsync(Guid Id);
    }
}
