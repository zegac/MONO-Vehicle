using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vehicle.Service.Common;

namespace Vehicle.WebApi.Controllers
{
    public class VehicleAdditionalEquipment : ApiController
    {
        #region Constructors

        public VehicleAdditionalEquipment(IVehicleAdditionalEquipmentService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        protected IMapper Mapper { get; set; }
        protected IVehicleAdditionalEquipmentService Service { get; private set; }

        #endregion Properties

        #region Methods

        [HttpGet]
        [Route("api/AdditionalEquipment")]
        public async Task<HttpResponseMessage> GetAdditionalEquipmentAsync()
        {
            var AdditionalEquipment = await Service.GetAdditionalEquipmentAsync();
            var mapMake = Mapper.Map<List<AdditionalEquipmentRest>>(AdditionalEquipment);

            if (AdditionalEquipment != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapMake);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "AdditionalEquipment not found");
            }
        }

        [HttpGet]
        [Route("api/AdditionalEquipment/{id}")]
        public async Task<HttpResponseMessage> GetAdditionalEquipmentByIdAsync(Guid id)
        {
            var AdditionalEquipment = await Service.GetAdditionalEquipmentByIdAsync(id);
            var mapMake = Mapper.Map<AdditionalEquipmentRest>(AdditionalEquipment);

            if (AdditionalEquipment != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapMake);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "AdditionalEquipment doesnt exist");
            }
        }

        #endregion Methods

        #region Classes

        public class AdditionalEquipmentRest
        {
            #region Properties

            public string Name { get; set; }

            #endregion Properties
        }

        #endregion Classes
    }
}