using AutoMapper;
using Vehicle.Model;
using Vehicle.Model.Common;
using static Vehicle.WebApi.Controllers.VehicleEngineTypeController;
using static Vehicle.WebApi.Controllers.VehicleColorController;
using static Vehicle.WebApi.Controllers.VehicleBodyStyleController;
using static Vehicle.WebApi.Controllers.VehicleMakeController;
using static Vehicle.WebApi.Controllers.VehicleModelController;
using static Vehicle.WebApi.Controllers.VehicleSeatTypeController;
using static Vehicle.WebApi.Controllers.VehicleAdditionalEquipment;

namespace Vehicle.WebApi
{
    public class MappingProfile : Profile
    {
        #region Constructors

        public MappingProfile()
        {
            CreateMap<MakeRest, VehicleMake>().ReverseMap();
            CreateMap<MakeRest, IVehicleMake>().ReverseMap();
            CreateMap<ModelRest, VehicleModel>().ReverseMap();
            CreateMap<ModelRest, IVehicleModel>().ReverseMap();
            CreateMap<EngineTypeRest, VehicleEngineType>().ReverseMap();
            CreateMap<EngineTypeRest, IVehicleEngineType>().ReverseMap();
            CreateMap<MakeRestCreate, VehicleMake>().ReverseMap();
            CreateMap<MakeRestCreate, IVehicleMake>().ReverseMap();
            CreateMap<ModelRestCreate, VehicleModel>().ReverseMap();
            CreateMap<ModelRestCreate, IVehicleModel>().ReverseMap();
            CreateMap<EngineTypeCreate, VehicleEngineType>().ReverseMap();
            CreateMap<EngineTypeCreate, IVehicleEngineType>().ReverseMap();
            CreateMap<ColorRest, VehicleColor>().ReverseMap();
            CreateMap<ColorRest, IVehicleColor>().ReverseMap();
            CreateMap<ColorRestCreate, VehicleColor>().ReverseMap();
            CreateMap<ColorRestCreate, IVehicleColor>().ReverseMap();
            CreateMap<BodyStyleRestCreate, VehicleBodyStyle>().ReverseMap();
            CreateMap<BodyStyleRestCreate, IVehicleBodyStyle>().ReverseMap();
            CreateMap<BodyStyleRest, VehicleBodyStyle>().ReverseMap();
            CreateMap<BodyStyleRest, IVehicleBodyStyle>().ReverseMap();
            CreateMap<SeatTypeRest, VehicleSeatType>().ReverseMap();
            CreateMap<SeatTypeRest, IVehicleSeatType>().ReverseMap();
            CreateMap<AdditionalEquipmentRest, VehicleAdditionalEquipment>().ReverseMap();
            CreateMap<AdditionalEquipmentRest, IVehicleAdditionalEquipment>().ReverseMap();
        }

        #endregion Constructors
    }
}