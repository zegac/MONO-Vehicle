using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        #region Constructors

        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Properties

        protected IVehicleMakeRepository Repository { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<List<IVehicleModel>> GetModelsForSpecificMakerrByIdAsync(Guid id)
        {
            return await Repository.GetModelsForSpecificMaker(id);
        }
        public async Task<List<VehicleMake>> GetMakersAsync()
        {
            return await Repository.GetMakersAsync();
        }

        public async Task<VehicleMake> GetMakerByIdAsync(Guid id)
        {
            return await Repository.GetMakerByIdAsync(id);
        }

        public async Task<bool> DeleteMakerByIdAsync(Guid id)
        {
            return await Repository.DeleteMakerByIdAsync(id);
        }

        public async Task<bool> CreateMakerByIdAsync(VehicleMake newmaker)
        {
            return await Repository.CreateMakerByIdAsync(newmaker);
        }

        public async Task<bool> UpdateMakerByIdAsync(VehicleMake updatemaker, Guid id)
        {
            return await Repository.UpdateMakerByIdAsync(updatemaker, id);
        }
        #endregion Methods
    }
}