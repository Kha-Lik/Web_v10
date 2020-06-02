using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerModel>>> GetAll()
        {
            return Ok( await _ownerService.GetAll());
        }

        [HttpGet("GetByOwnerName/{name}")]
        public async Task<ActionResult<IEnumerable<OwnerModel>>> GetByFullName(string fullName)
        {
            return Ok( await _ownerService.GetByFullName(fullName));
        }
        [HttpGet("GetByPartName/{partName}")]
        public async Task<ActionResult<IEnumerable<OwnerModel>>> GetByPartName(string partName)
        {
            return Ok(await _ownerService.GetByPartName(partName));
        }


        [HttpGet("GetByOrderId/{id}")]
        public async Task<ActionResult<OwnerModel>> GetByOrderId(int id)
        {
            return Ok(await _ownerService.GetByOrderId(id));
        }
        [HttpGet("GetByOrderDate/{date}")]
        public async Task<ActionResult<IEnumerable<OwnerModel>>> GetByOrderDate(DateTime date)
        {
            return Ok(await _ownerService.GetByOrderDate(date));
        }
        [HttpGet("GetByComputerModel/{computerName}")]
        public async Task<ActionResult<IEnumerable<OwnerModel>>> GetByComputerModel(string model)
        {
            return Ok(await _ownerService.GetByComputerModel(model));
        }
    }
}