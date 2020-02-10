using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleEngineTypeService : IVehicleEngineTypeService
    {
        public VehicleEngineTypeService(IVehicleEngineTypeRepository repository)
        {
            this.Repository = repository;
        }

        protected IVehicleEngineTypeRepository Repository { get; private set; }


        public async Task<List<VehicleEngineType>> GetEngineTypesAsync()
        {
            return await Repository.GetEngineTypesAsync();
        }
        public async Task<VehicleEngineType> GetEngineTypeByIdAsync(Guid id)
        {
            return await Repository.GetEngineTypeByIdAsync(id);
        }

        public async Task<bool> DeleteEngineTypeByIdAsync(Guid id)
        {
            return await Repository.DeleteEngineTypeByIdAsync(id);
        }

        public async Task<bool> CreateEngineTypeByIdAsync(VehicleEngineType newEngineType, Guid Id)
        {
            return await Repository.CreateEngineTypeByIdAsync(newEngineType, Id);
        }

        public async Task<bool> UpdateEngineTypeByIdAsync(VehicleEngineType updateEngineType, Guid id)
        {
            return await Repository.UpdateEngineTypeByIdAsync(updateEngineType, id);
        }
    }
}


