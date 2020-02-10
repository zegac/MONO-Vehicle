using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        #region Constructors

        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Properties

        protected IVehicleModelRepository Repository { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<List<VehicleModel>> GetModelsAsync()
        {
            return await Repository.GetModelsAsync();
        }
        public async Task<List<VehicleModel>> GetModelsByMakerAsync(Guid id)
        {
            return await Repository.GetModelsByMakerAsync(id);
        }

        public async Task<VehicleModel> GetModelByIdAsync(Guid id)
        {
            return await Repository.GetModelByIdAsync(id);
        }

        public async Task<bool> DeleteModelByIdAsync(Guid id)
        {
            return await Repository.DeleteModelByIdAsync(id);
        }

        public async Task<bool> CreateModelByIdAsync(VehicleModel newmodel, Guid id)
        {
            return await Repository.CreateModelByIdAsync(newmodel, id);
        }

        public async Task<bool> UpdateModelByIdAsync(VehicleModel updatemodel, Guid id)
        {
            return await Repository.UpdateModelByIdAsync(updatemodel, id);
        }
        #endregion Methods
    }
}