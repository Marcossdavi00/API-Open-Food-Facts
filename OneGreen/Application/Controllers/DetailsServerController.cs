using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Model;
using AutoMapper;
using Domain.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsServerController : ControllerBase
    {
        private readonly IDetailsServerService _service;
        private readonly IMapper _mapper;

        public DetailsServerController(IDetailsServerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int itemsPerPage)
        {
            try
            {
                var result = await _service.DetailsGet();

                var response = _mapper.Map<IList<DetailsModelOutPut>>(result);

                return Ok(await response.ToPagedListAsync(page, itemsPerPage));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
