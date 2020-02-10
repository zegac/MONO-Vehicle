using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Service.Common
{
    public interface IVehicleMakeService
    {
        #region Methods

        Task<List<VehicleMake>> GetMakersAsync();
        Task<VehicleMake> GetMakerByIdAsync(Guid id);
        Task<bool> DeleteMakerByIdAsync(Guid id);
        Task<bool> CreateMakerByIdAsync(VehicleMake newmaker);
        Task<bool> UpdateMakerByIdAsync(VehicleMake updatemaker, Guid id);
        Task<List<IVehicleModel>> GetModelsForSpecificMakerrByIdAsync(Guid id);

        #endregion Methods
    }
}