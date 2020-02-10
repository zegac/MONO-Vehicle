using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Vehicle.Model;
using Vehicle.Service.Common;
namespace Vehicle.WebApi.Controllers
{
    public class VehicleBodyStyleController: ApiController
    {
        #region Constructors

        public VehicleBodyStyleController(IVehicleBodyStyleService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        protected IMapper Mapper { get; set; }
        protected IVehicleBodyStyleService Service { get; private set; }

        #endregion Properties

        #region Methods


        [HttpGet]
        [Route("api/BodyStyles")]
        public async Task<HttpResponseMessage> GetBodyStylesAsync()
        {
            var BodyStyle = await Service.GetBodyStylesAsync();
            var mapBodyStyle = Mapper.Map<List<BodyStyleRest>>(BodyStyle);

            if (BodyStyle != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapBodyStyle);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Models not found");
            }
        }
        

        [HttpGet]
        [Route("api/BodyStyles/{id}")]
        public async Task<HttpResponseMessage> GetBodyStylesByIdAsync(Guid id)
        {
            var BodyStyle = await Service.GetBodyStylesByIdAsync(id);
            var mapBodyStyle = Mapper.Map<BodyStyleRest>(BodyStyle);

            if (BodyStyle != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapBodyStyle);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Id not found");
        }

        [HttpDelete]
        [Route("api/BodyStyles/{id}")]
        public async Task<HttpResponseMessage> DeleteBodyStylesByIdAsync(Guid id)
        {
            if (await Service.DeleteBodyStylesByIdAsync(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item doesnt exist");
            }
        }

        [HttpPost]
        [Route("api/BodyStyle/{id}")]

        public async Task<HttpResponseMessage> CreateBodyStyleByIdAsync(BodyStyleRestCreate newBodyStyle, Guid id)
        {
            var mapBodyStyle = Mapper.Map<VehicleBodyStyle>(newBodyStyle);

            if (await Service.CreateBodyStylesByIdAsync(mapBodyStyle, id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Item is added");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to add item");

            }

        }
        [HttpPut]
        [Route("api/BodyStyles/{id}")]
        public async Task<HttpResponseMessage> UpdateBodyStyleByIdAsync(BodyStyleRest updateBodyStyle, Guid id)
        {
            var mapBodyStyle = Mapper.Map<VehicleBodyStyle>(updateBodyStyle);
            if (await Service.UpdateBodyStylesByIdAsync(mapBodyStyle, id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item does not exist");
            }
        }
        #endregion Methods

        #region Classes

        public class BodyStyleRest
        {
            #region Properties

            public string Name { get; set; }

            #endregion Properties
        }

        public class BodyStyleRestCreate
        {
            public string Name { get; set; }
            
        }
        #endregion Classes
    }
}