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
    public class VehicleEngineTypeController : ApiController
    {
        public VehicleEngineTypeController(IVehicleEngineTypeService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        protected IMapper Mapper { get; set; }
        protected IVehicleEngineTypeService Service { get; private set; }


        [HttpGet]
        [Route("api/engineType")]
        public async Task<HttpResponseMessage> GetEngineTypesAsync()
        {
            var engineType = await Service.GetEngineTypesAsync();
            var mapEngineType = Mapper.Map<List<EngineTypeRest>>(engineType);

            if (engineType != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapEngineType);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Engine type not found");
            }
        }

        [HttpGet]
        [Route("api/engineType/{id}")]
        public async Task<HttpResponseMessage> GetEngineTypeByIdAsync(Guid id)
        {
            var engineType = await Service.GetEngineTypeByIdAsync(id);
            var mapEngineType = Mapper.Map<EngineTypeRest>(engineType);

            if (engineType != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapEngineType);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Engine tpye doesnt exist");

            }
        }

        [HttpDelete]
        [Route("api/engineType/{id}")]
        public async Task<HttpResponseMessage> DeleteEngineTypeByIdAsync(Guid id)
        {
            if (await Service.DeleteEngineTypeByIdAsync(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item doesnt exist");

            }
        }

        [HttpPost]
        [Route("api/engineType/{id}")]

        public async Task<HttpResponseMessage> CreateEngineTypeByIdAsync(EngineTypeCreate newEngineType, Guid Id)
        {
            var mapEngineType = Mapper.Map<VehicleEngineType>(newEngineType);
            if (await Service.CreateEngineTypeByIdAsync(mapEngineType, Id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Engine type is added");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to add engine type");

            }

        }
        [HttpPut]
        [Route("api/engineType/{id}")]
        public async Task<HttpResponseMessage> UpdateEngineTypeByIdAsync(EngineTypeRest updateEngineType, Guid id)
        {
            var mapEngineType = Mapper.Map<VehicleEngineType>(updateEngineType);
            if (await Service.UpdateEngineTypeByIdAsync(mapEngineType, id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item does not exist");
            }
        }

        public class EngineTypeRest
        {
            public string Name { get; set; }
            public int Power { get; set; }
            //public List<IVehicleModel> Items { get; set; }

        }
        public class EngineTypeCreate
        {
            public string Name { get; set; }
            public int Power { get; set; }

            // public Guid Id { get; set; }
        }
    }
}
