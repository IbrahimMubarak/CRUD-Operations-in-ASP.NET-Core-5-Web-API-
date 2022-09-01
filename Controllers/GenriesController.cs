using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.DTO;
using WEBAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenriesController : ControllerBase
    {
        private readonly IGenriesReprosatory gen;
        private readonly IMapper mapper;
        public GenriesController(IGenriesReprosatory _gen,IMapper _mapper)
        {
            gen = _gen;
            mapper = _mapper;
        }
        // GET: api/<GenriesController>
        [HttpGet]
        public async Task<IActionResult>GetAllAsync()
        {
            var genries= await gen.GetAll();
            var dto=mapper.Map<IEnumerable<GenrieDTO>>(genries);
            return Ok(dto);
        }

        // GET api/<GenriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var genrie = await gen.GetById(id);
            if (genrie != null)
            {
                var dto = mapper.Map<GenrieDTO>(genrie);
                return Ok(dto);
            }
                

            return NotFound("User Not Found");
            
        }

        //// POST api/<GenriesController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(GenrieDTO dto)
        {
            
            if (dto != null)
            {
                var genrie = mapper.Map<Genrie>(dto);
                await gen.Create(genrie);
                return Created("",dto);
            }

            return BadRequest();

        }

        //// PUT api/<GenriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, GenrieDTO dto)
        {
            var genrie = await gen.GetById(id);
            if (genrie == null)
            {
                return NotFound("Genrie Not Found");
            }
            genrie.Name = dto.Name;
            gen.Update(genrie);
            return Ok(dto);
        }

        //// DELETE api/<GenriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genrie = await gen.GetById(id);
            if (genrie == null)
            {
                return NotFound("Genrie Not Found");
            }
            gen.Delete(genrie);
            return Ok(genrie);
        }
    }
}
