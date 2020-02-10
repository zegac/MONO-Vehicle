using System;
using System.Collections.Generic;

namespace Vehicle.Model.Common
{
    public interface IVehicleMake
    {
        #region Properties

        Guid Id { get; set; }
        string Name { get; set; }

        #endregion Properties

        List<IVehicleModel> Items { get; set; }
    }
}