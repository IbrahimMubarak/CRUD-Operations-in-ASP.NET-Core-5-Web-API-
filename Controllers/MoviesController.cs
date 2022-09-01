using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.DTO;
using WEBAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesReprosatory mov;
        public MoviesController(IMoviesReprosatory _mov)
        {
            mov = _mov;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<IActionResult>GetAllAsync()
        {
            var movies =await mov.GetAll();
            return Ok(movies);
        }
        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var movie =await mov.GetById(id);
            if(movie!=null)
            return Ok(movie);

            return NotFound("Movie Not Found");
        }

        //POST api/<MoviesController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]MovieDTO movieDTO)
        {

            if (movieDTO == null)
                return BadRequest();
            
            var stream = new MemoryStream();
            var movie = new Movie();
            if (movieDTO.Poster != null)
            {
                await movieDTO.Poster.CopyToAsync(stream);
                movie.Poster = stream.ToArray();
                
            }
            else
            {
                movie.Poster = null;
            }


            movie.Title = movieDTO.Title;
                movie.Rate = movieDTO.Rate;
            movie.GenrieId = movieDTO.GenrieId;
            
            await mov.Create(movie);
            return Created("", movie);

        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromForm] MovieDTO movieDTO)
        {
            if (movieDTO == null)
                return BadRequest();

            var movie = await mov.GetById(id);
            if (movie == null)
                return NotFound("Movie Not Found");
            var stream = new MemoryStream();
            if (movieDTO.Poster != null)
            {
                await movieDTO.Poster.CopyToAsync(stream);
                movie.Poster = stream.ToArray();
            }
            movie.Title = movieDTO.Title;
            movie.Rate = movieDTO.Rate;
            movie.GenrieId = movieDTO.GenrieId;          
            mov.Update(movie);
            return Ok(movie);

        }
        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var movie = await mov.GetById(id);
            if (movie == null)
                return NotFound();
            mov.Delete(movie);
            return Ok(movie);

        }

    }
}
