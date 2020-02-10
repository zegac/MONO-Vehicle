using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleAdditionalEquipmentService : IVehicleAdditionalEquipmentService
    {
        #region Constructors

        public VehicleAdditionalEquipmentService(IVehicleAdditionalEquipmentRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Properties

        protected IVehicleAdditionalEquipmentRepository Repository { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<List<VehicleAdditionalEquipment>> GetAdditionalEquipmentAsync()
        {
            return await Repository.GetAdditionalEquipmentAsync();
        }

        public async Task<VehicleAdditionalEquipment> GetAdditionalEquipmentByIdAsync(Guid id)
        {
            return await Repository.GetAdditionalEquipmentByIdAsync(id);
        }

        #endregion Methods
    }
}