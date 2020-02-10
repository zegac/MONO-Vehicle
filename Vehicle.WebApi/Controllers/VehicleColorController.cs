using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vehicle.Model;
using Vehicle.Service.Common;

namespace Vehicle.WebApi.Controllers
{
    public class VehicleColorController : ApiController
    {
        #region Constructors

        public VehicleColorController(IVehicleColorService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        protected IMapper Mapper { get; set; }
        protected IVehicleColorService Service { get; private set; }

        #endregion Properties

        #region Methods

        [HttpPost]
        [Route("api/color")]
        public async Task<HttpResponseMessage> CreateColorByIdAsync(ColorRestCreate newcolor, Guid Id)
        {
            var mapMake = Mapper.Map<VehicleColor>(newcolor);
            if (await Service.CreateColorByIdAsync(mapMake, Id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Item is added");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to add color");
            }
        }

        [HttpDelete]
        [Route("api/color/{id}")]
        public async Task<HttpResponseMessage> DeleteColorByIdAsync(Guid id)
        {
            if (await Service.DeleteColorByIdAsync(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Color doesnt exist");
            }
        }

        [HttpGet]
        [Route("api/color/{id}")]
        public async Task<HttpResponseMessage> GetColorByIdAsync(Guid id)
        {
            var color = await Service.GetColorByIdAsync(id);
            var mapMake = Mapper.Map<ColorRest>(color);

            if (color != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapMake);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Color doesnt exist");
            }
        }

        [HttpGet]
        [Route("api/colors")]
        public async Task<HttpResponseMessage> GetColorsAsync()
        {
            var color = await Service.GetColorsAsync();
            var mapMake = Mapper.Map<List<ColorRest>>(color);

            if (color != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapMake);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Colors not found");
            }
        }

        [HttpPut]
        [Route("api/color/{id}")]
        public async Task<HttpResponseMessage> UpdateColorByIdAsync(ColorRest updatecolor, Guid id)
        {
            var mapMake = Mapper.Map<VehicleColor>(updatecolor);
            if (await Service.UpdateColorByIdAsync(mapMake, id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Color does not exist");
            }
        }

        #endregion Methods

        #region Classes

        public class ColorRest
        {
            #region Properties

            public string Name { get; set; }

            #endregion Properties
        }

        public class ColorRestCreate
        {
            #region Properties

            public string Name { get; set; }

            #endregion Properties
        }

        #endregion Classes
    }
}