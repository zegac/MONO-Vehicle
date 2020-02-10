using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IVehicleAdditionalEquipmentService
    {
        #region Methods

        Task<List<VehicleAdditionalEquipment>> GetAdditionalEquipmentAsync();

        Task<VehicleAdditionalEquipment> GetAdditionalEquipmentByIdAsync(Guid id);

        #endregion Methods
    }
}