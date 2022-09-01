using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.DTO
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public double Rate { get; set; }
        public IFormFile Poster { get; set; }
        public int GenrieId { get; set; }
        public string GenrieName { get; set; }

    }
}
