using System;

namespace Vehicle.Model.Common
{
    public interface IVehicleAdditionalEquipment
    {
        #region Properties

        Guid Id { get; set; }
        Guid ModelId { get; set; }
        string Name { get; set; }

        #endregion Properties
    }
}