using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model.Common
{
    public interface IVehicleBodyStyle
    {
        #region Properties

        Guid Id { get; set; }
        string Name { get; set; }
        Guid ModelId { get; set; }

        #endregion Properties
    }
}
