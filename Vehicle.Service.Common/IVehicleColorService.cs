using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IVehicleColorService
    {
        #region Methods

        Task<bool> CreateColorByIdAsync(VehicleColor newcolor, Guid id);

        Task<bool> DeleteColorByIdAsync(Guid id);

        Task<VehicleColor> GetColorByIdAsync(Guid id);

        Task<List<VehicleColor>> GetColorsAsync();

        Task<bool> UpdateColorByIdAsync(VehicleColor updatecolor, Guid id);

        #endregion Methods
    }
}