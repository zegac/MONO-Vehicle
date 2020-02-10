using Autofac;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class DIModule : Module
    {
        #region Methods
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>();
            builder.RegisterType<VehicleEngineTypeService>().As<IVehicleEngineTypeService>();
            builder.RegisterType<VehicleBodyStyleService>().As<IVehicleBodyStyleService>();
            builder.RegisterType<VehicleColorService>().As<IVehicleColorService>();
            builder.RegisterType<VehicleSeatTypeService>().As<IVehicleSeatTypeService>();
            builder.RegisterType<VehicleAdditionalEquipmentService>().As<IVehicleAdditionalEquipmentService>();
        }
        #endregion Methods
    }
}