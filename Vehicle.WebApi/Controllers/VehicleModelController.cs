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
    public class VehicleModelController : ApiController
    {
        #region Constructors

        public VehicleModelController(IVehicleModelService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        protected IMapper Mapper { get; set; }
        protected IVehicleModelService Service { get; private set; }

        #endregion Properties

        #region Methods


        [HttpGet]
        [Route("api/models")]
        public async Task<HttpResponseMessage> GetModelsAsync()
        {
            var model = await Service.GetModelsAsync();
            var mapModel = Mapper.Map<List<ModelRest>>(model);

            if (model != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapModel);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Models not found");
            }
        }
        [HttpGet]
        [Route("api/models/{id}")]
        public async Task<HttpResponseMessage> GetModelsByMakerAsync(Guid id)
        {
            var models = await Service.GetModelsByMakerAsync(id);
            var mapModel = Mapper.Map<List<ModelRest>>(models);

            if (models != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapModel);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Models not found");
            }
        }

        [HttpGet]
        [Route("api/model/{id}")]
        public async Task<HttpResponseMessage> GetModelByIdAsync(Guid id)
        {
            var model = await Service.GetModelByIdAsync(id);
            var mapModel = Mapper.Map<ModelRest>(model);

            if (model != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, mapModel);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Id not found");
        }

        [HttpDelete]
        [Route("api/model/{id}")]
        public async Task<HttpResponseMessage> DeleteModelByIdAsync(Guid id)
        {
            if (await Service.DeleteModelByIdAsync(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item doesnt exist");
            }
        }

        [HttpPost]
        [Route("api/model/{id}")]

        public async Task<HttpResponseMessage> CreateModelByIdAsync(ModelRestCreate newmodel, Guid id)
        {
            var mapModel = Mapper.Map<VehicleModel>(newmodel);

            if (await Service.CreateModelByIdAsync(mapModel, id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Item is added");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Failed to add item");

            }

        }
        [HttpPut]
        [Route("api/model/{id}")]
        public async Task<HttpResponseMessage> UpdateModelByIdAsync(ModelRest updatemodel, Guid id)
        {
            var mapModel = Mapper.Map<VehicleModel>(updatemodel);
            if (await Service.UpdateModelByIdAsync(mapModel, id) == true)
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

        public class ModelRest
        {
            #region Properties

            public string Name { get; set; }

            #endregion Properties
        }

        public class ModelRestCreate
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
        }
        #endregion Classes
    }
}