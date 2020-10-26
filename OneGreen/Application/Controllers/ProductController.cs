using Application.Model;
using AutoMapper;
using Domain.Entity;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using X.PagedList;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int itemsPerPage)
        {
            try
            {
                var result = await _service.FindAllGet();
                var response = _mapper.Map<IList<ProductsModelOutPut>>(result);
                return Ok(await response.ToPagedListAsync(page, itemsPerPage));
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetId(int code)
        {
            try
            {
                var result = await _service.GetId(code);
                var response = _mapper.Map<ProductsModelOutPut>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Products products)
        {
            try
            {
                await _service.Create(products);

                return Created("Criado com Sucesso", await _service.GetId(products.code));
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut("products/{code}")]
        public async Task<IActionResult> Put([FromBody] ProductsStatusModelInput Enum, int code)
        {
            try
            {
                var response = await _service.GetId(code);
                response.Status = Enum.status;
                var result = await _service.Update(response, response.id);

                if (result == null)
                    return BadRequest();

                return Ok(result);

            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete("products/{code}")]
        public async Task<IActionResult> Delete(int code)
        {
            try
            {
                var response = await _service.Delete(code);
                if (response == false)
                    return NotFound("Produto não encontrado");

                return Ok("Produto Deletado");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
