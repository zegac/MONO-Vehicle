using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IVehicleColorRepository
    {
        #region Methods

        Task<bool> CreateColorByIdAsync(VehicleColor newcolor, Guid id);

        Task<bool> DeleteColorByIdAsync(Guid id);

        Task<VehicleColor> GetColorByIdAsync(Guid id);

        Task<List<VehicleColor>> GetColorsAsync();

        Task<bool> UpdateColorByIdAsync(VehicleColor newcolor, Guid id);

        #endregion Methods
    }
}