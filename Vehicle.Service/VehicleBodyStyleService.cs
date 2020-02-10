using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleBodyStyleService:IVehicleBodyStyleService
    {
        #region Constructors

        public VehicleBodyStyleService(IVehicleBodyStyleRepository repository)
        {
            this.Repository = repository;
        }

        #endregion Constructors

        #region Properties

        protected IVehicleBodyStyleRepository Repository { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<List<VehicleBodyStyle>> GetBodyStylesAsync()
        {
            return await Repository.GetBodyStylesAsync();
        }

        public async Task<VehicleBodyStyle> GetBodyStylesByIdAsync(Guid id)
        {
            return await Repository.GetBodyStylesByIdAsync(id);
        }

        public async Task<bool> DeleteBodyStylesByIdAsync(Guid id)
        {
            return await Repository.DeleteBodyStylesByIdAsync(id);
        }

        public async Task<bool> CreateBodyStylesByIdAsync(VehicleBodyStyle newBodyStyle, Guid id)
        {
            return await Repository.CreateBodyStylesByIdAsync(newBodyStyle, id);
        }

        public async Task<bool> UpdateBodyStylesByIdAsync(VehicleBodyStyle updateBodyStyle, Guid id)
        {
            return await Repository.UpdateBodyStylesByIdAsync(updateBodyStyle, id);
        }

       
        #endregion Methods
    }
}
