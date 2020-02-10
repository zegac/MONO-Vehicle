using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleSeatTypeService : IVehicleSeatTypeService
    {
        public VehicleSeatTypeService(IVehicleSeatTypeRepository repository)
        {
            this.Repository = repository;
        }

        protected IVehicleSeatTypeRepository Repository { get; private set; }


        public async Task<List<VehicleSeatType>> GetSeatTypesAsync()
        {
            return await Repository.GetSeatTypesAsync();
        }
        public async Task<VehicleSeatType> GetSeatTypeByIdAsync(Guid id)
        {
            return await Repository.GetSeatTypeByIdAsync(id);
        }
    }
}
