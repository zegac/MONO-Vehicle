using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleColorService : IVehicleColorService
    {
        #region Constructors

        public VehicleColorService(IVehicleColorRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Properties

        protected IVehicleColorRepository Repository { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<bool> CreateColorByIdAsync(VehicleColor newcolor, Guid id)
        {
            return await Repository.CreateColorByIdAsync(newcolor, id);
        }

        public async Task<bool> DeleteColorByIdAsync(Guid id)
        {
            return await Repository.DeleteColorByIdAsync(id);
        }

        public async Task<VehicleColor> GetColorByIdAsync(Guid id)
        {
            return await Repository.GetColorByIdAsync(id);
        }

        public async Task<List<VehicleColor>> GetColorsAsync()
        {
            return await Repository.GetColorsAsync();
        }

        public async Task<bool> UpdateColorByIdAsync(VehicleColor updatecolor, Guid id)
        {
            return await Repository.UpdateColorByIdAsync(updatecolor, id);
        }

        #endregion Methods
    }
}