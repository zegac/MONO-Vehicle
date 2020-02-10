using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IVehicleEngineTypeService
    {
        Task<List<VehicleEngineType>> GetEngineTypesAsync();

        Task<VehicleEngineType> GetEngineTypeByIdAsync(Guid id);
        Task<bool> DeleteEngineTypeByIdAsync(Guid id);
        Task<bool> CreateEngineTypeByIdAsync(VehicleEngineType newEngineType, Guid Id);
        Task<bool> UpdateEngineTypeByIdAsync(VehicleEngineType updateEngineType, Guid id);
    }
}
