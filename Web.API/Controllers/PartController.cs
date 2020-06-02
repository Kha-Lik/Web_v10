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
    public class PartController : Controller
    {
        private readonly IPartService _partService;


        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartModel>>> Get()
        {
            return Ok(await _partService.GetAll());
        }

        [HttpGet("GetByPartName/{name}")]
        public async Task<ActionResult<IEnumerable<PartModel>>> GetByPartName(string name)
        {
            return Ok(await _partService.GetByName(name));
        }


        [HttpGet("GetPartByOrderId/{id}")]
        public async Task<ActionResult<IEnumerable<OwnerModel>>> GetPartByOrderId(int id)
        {
            return Ok(await _partService.GetByOrderId(id));
        }

        [HttpGet("GetByPartDate/{date}")]
        public async Task<ActionResult<IEnumerable<OwnerModel>>> GetByPartDate(DateTime date)
        {
            return Ok(await _partService.GetByDate(date));
        }
    }
}