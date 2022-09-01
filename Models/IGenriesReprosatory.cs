using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.DTO;

namespace WEBAPI.Models
{
    public interface IGenriesReprosatory
    {
        public Task<IEnumerable<Genrie>> GetAll();
        public Task<Genrie> GetById(int id);
        public Task<Genrie> Create(Genrie dto);
        public Genrie Update (Genrie genrie);
        public Genrie Delete (Genrie genrie);



    }
}
