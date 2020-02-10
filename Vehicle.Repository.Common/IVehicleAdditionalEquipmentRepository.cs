using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IVehicleAdditionalEquipmentRepository
    {
        #region Methods

        Task<List<VehicleAdditionalEquipment>> GetAdditionalEquipmentAsync();

        Task<VehicleAdditionalEquipment> GetAdditionalEquipmentByIdAsync(Guid id);

        #endregion Methods
    }
}