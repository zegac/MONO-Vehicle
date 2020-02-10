using Autofac;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class DIModule : Module
    {
        #region Methods

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>();
            builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>();
            builder.RegisterType<VehicleEngineTypeRepository>().As<IVehicleEngineTypeRepository>();
            builder.RegisterType<VehicleColorRepository>().As<IVehicleColorRepository>();
            builder.RegisterType<VehicleBodyStyleRepository>().As<IVehicleBodyStyleRepository>();
            builder.RegisterType<VehicleSeatTypeRepository>().As<IVehicleSeatTypeRepository>();
            builder.RegisterType<VehicleAdditionalEquipmentRepository>().As<IVehicleAdditionalEquipmentRepository>();
        }

        #endregion Methods
    }
}