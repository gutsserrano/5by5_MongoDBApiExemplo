using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBApiExemplo.Models;
using MongoDBApiExemplo.Services;

namespace MongoDBApiExemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressesController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            var address = _addressService.Get(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpGet("{cep:length(8)}")]
        public ActionResult<AddressDTO> GetPostOffice(string cep)
        {
            return PostOfficeService.GetAddres(cep).Result;
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);

            return CreatedAtRoute("GetAddress", new { id = address.Id.ToString() }, address);
        }
    }
}
