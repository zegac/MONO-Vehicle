using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IVehicleBodyStyleService
    {
        #region Methods

        Task<VehicleBodyStyle> GetBodyStylesByIdAsync(Guid id);
        Task<bool> DeleteBodyStylesByIdAsync(Guid id);
        Task<bool> CreateBodyStylesByIdAsync(VehicleBodyStyle newBodyStyle, Guid id);
        Task<bool> UpdateBodyStylesByIdAsync(VehicleBodyStyle updateBodyStyle, Guid id);


        Task<List<VehicleBodyStyle>> GetBodyStylesAsync();
        #endregion Methods
    }
}
