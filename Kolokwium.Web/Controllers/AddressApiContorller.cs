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

        private readonly IAddressService _addressService;

        public AddressApiContorller(ILogger logger, IMapper mapper, IAddressService addressService)
        : base(logger, mapper)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var addresses = _addressService.GetAddresses();
                return Ok(addresses);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error Get Adresses");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Get(int id)
        {
            try
            {
                var address = _addressService.GetAddress(a => a.AddressId == id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error Get Address");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            return PostOrPutHelper(addOrUpdateAddressVm);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddOrUpdateAddressVm addOrUpdateAddressVm)
        {
            return PostOrPutHelper(addOrUpdateAddressVm);
        }

        private IActionResult PostOrPutHelper(AddOrUpdateAddressVm addOrUpdateAdressVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(_addressService.AddOrUpdateAddress(addOrUpdateAdressVm));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error Put Helper");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _addressService.DeleteAdress(a => a.AddressId == id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return StatusCode(500, "Error Delete");
            }
        }

    }
}

