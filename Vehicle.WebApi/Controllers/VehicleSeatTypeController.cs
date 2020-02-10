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
    public class VehicleSeatTypeController : ApiController
    {
        public VehicleSeatTypeController(IVehicleSeatTypeService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        protected IMapper Mapper { get; set; }
        protected IVehicleSeatTypeService Service { get; private set; }

        [HttpGet]
        [Route("api/SeatTypes")]
        public async Task<HttpResponseMessage> GetSeatTypesAsync()
        {
            var seatType = await Service.GetSeatTypesAsync();
            var mapSeatType = Mapper.Map<List<SeatTypeRest>>(seatType);

            if (seatType != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapSeatType);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Models not found");
            }
        }

        [HttpGet]
        [Route("api/SeatType/{id}")]
        public async Task<HttpResponseMessage> GetSeatTypeByIdAsync(Guid id)
        {
            var seatType = await Service.GetSeatTypeByIdAsync(id);
            var mapSeatType = Mapper.Map<SeatTypeRest>(seatType);

            if (seatType != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapSeatType);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Id not found");
        }

        public class SeatTypeRest
        {
            #region Properties
            public string Name { get; set; }
            #endregion Properties
        }
    }
}