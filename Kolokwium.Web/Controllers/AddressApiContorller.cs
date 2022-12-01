using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.ViewModels.VM;
using Kolokwium.ViewModels.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Web.Controllers
{
    public class AddressApiContorller : BaseController
    {

        private readonly IAdressService _addressService;

        public AddressApiContorller(ILogger logger, IMapper mapper, IAdressService addressService)
        : base(logger, mapper)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var addresses = _addressService.GetAdresses();
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error present");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            try
            {
                var address = _addressService.GetAdress(a => a.AdressId == id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error present");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AddOrUpdateAdressVm addOrUpdateAddressVm)
        {
            return PostOrPutHelper(addOrUpdateAddressVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateAdressVm addOrUpdateAddressVm)
        {
            return PostOrPutHelper(addOrUpdateAddressVm);
        }

        private IActionResult PostOrPutHelper(AddOrUpdateAdressVm addOrUpdateAdressVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(_addressService.AddOrUpdateAdress(addOrUpdateAdressVm));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error present");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _addressService.DeleteAdress(a => a.AdressId == id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error present");
            }
        }

    }
}

