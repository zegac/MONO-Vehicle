using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IVehicleModelRepository
    {
        #region Methods

        Task<List<VehicleModel>> GetModelsByMakerAsync(Guid Id);

        Task<VehicleModel> GetModelByIdAsync(Guid id);
        Task<bool> DeleteModelByIdAsync(Guid id);
        Task<bool> CreateModelByIdAsync(VehicleModel newmodel, Guid id);
        Task<bool> UpdateModelByIdAsync(VehicleModel updatemodel, Guid id);
        Task<List<VehicleModel>> GetModelsAsync();



        #endregion Methods
    }
}