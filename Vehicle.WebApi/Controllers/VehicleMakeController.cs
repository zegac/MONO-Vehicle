using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Service.Common;
using static Vehicle.WebApi.Controllers.VehicleModelController;

namespace Vehicle.WebApi.Controllers
{
    public class VehicleMakeController : ApiController
    {
        public VehicleMakeController(IVehicleMakeService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        protected IMapper Mapper { get; set; }
        protected IVehicleMakeService Service { get; private set; }

        [HttpGet]
        [Route("api/GetModelsForSpecificMakerrByIdAsync/{id}")]
        public async Task<HttpResponseMessage> GetModelsForSpecificMakerrByIdAsync(Guid id)
        {
            var models = await Service.GetModelsForSpecificMakerrByIdAsync(id);
            var mapModels = Mapper.Map<List<ModelRest>>(models);


            if (models != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapModels);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");

            }
        }

        [HttpGet]
        [Route("api/makers")]
        public async Task<HttpResponseMessage> GetMakersAsync()
        {
            var make = await Service.GetMakersAsync();
            var mapMake = Mapper.Map<List<MakeRest>>(make);

            if (make != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapMake);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Makers not found");
            }
        }

        [HttpGet]
        [Route("api/makers/{id}")]
        public async Task<HttpResponseMessage> GetMakerByIdAsync(Guid id)
        {
            var make = await Service.GetMakerByIdAsync(id);
            var mapMake = Mapper.Map<MakeRest>(make);

            if (make != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapMake);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item doesnt exist");

            }
        }

        [HttpDelete]
        [Route("api/makers/{id}")]
        public async Task<HttpResponseMessage> DeleteMakerByIdAsync(Guid id)
        {
            if (await Service.DeleteMakerByIdAsync(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item doesnt exist");

            }
        }

        [HttpPost]
        [Route("api/makers")]

        public async Task<HttpResponseMessage> CreateMakerByIdAsync(MakeRestCreate newmaker)
        {
            var mapMake = Mapper.Map<VehicleMake>(newmaker);
            if (await Service.CreateMakerByIdAsync(mapMake) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Item is added");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to add item");

            }

        }
        [HttpPut]
        [Route("api/makers/{id}")]
        public async Task<HttpResponseMessage> UpdateMakerByIdAsync(MakeRest updatemaker, Guid id)
        {
            var mapMake = Mapper.Map<VehicleMake>(updatemaker);
            if (await Service.UpdateMakerByIdAsync(mapMake, id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item does not exist");
            }
        }

        public class MakeRest
        {
            public string Name { get; set; }
            //public List<IVehicleModel> Items { get; set; }

        }
        public class MakeRestCreate
        {
            public string Name { get; set; }
            // public Guid Id { get; set; }
        }

    }
}
