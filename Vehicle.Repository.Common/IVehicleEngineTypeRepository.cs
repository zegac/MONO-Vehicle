using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IVehicleEngineTypeRepository
    {
        Task<List<VehicleEngineType>> GetEngineTypesAsync();
        Task<VehicleEngineType> GetEngineTypeByIdAsync(Guid Id);
        Task<bool> DeleteEngineTypeByIdAsync(Guid Id);
        Task<bool> CreateEngineTypeByIdAsync(VehicleEngineType newEngineType, Guid Id);
        Task<bool> UpdateEngineTypeByIdAsync(VehicleEngineType updateEngineType, Guid Id);
    }
}
