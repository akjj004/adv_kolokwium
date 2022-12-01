using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.ViewModels.Interfaces;
using Kolokwium.ViewModels.VM;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Web.Controllers
{
    public class StoreApiController : BaseController
    {
        // impl filed from interface
        private readonly IStoreService _storeService;
        public StoreApiController(ILogger logger, IMapper mapper, IStoreService storeService) : base(logger, mapper)
        {
            _storeService = storeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var stationaryStores = _storeService.GetStores();
                return Ok(stationaryStores);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occured");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            try
            {
                var stationaryStore = _storeService.GetStores(s => s.StationaryStoreId == id);
                return Ok(stationaryStore);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occured");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AddOrUpdateStoreVm addOrUpdateStoreVm)
        {
            return PostOrPutHelper(addOrUpdateStoreVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateStoreVm addOrUpdateStoreVm)
        {
            return PostOrPutHelper(addOrUpdateStoreVm);
        }

        private IActionResult PostOrPutHelper(AddOrUpdateStoreVm addOrUpdateStoreVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(_storeService.AddOrUpdateStore(addOrUpdateStoreVm));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occured");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _storeService.DeleteStore(p => p.StationaryStoreId == id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error occured");
            }
        }
    }
}