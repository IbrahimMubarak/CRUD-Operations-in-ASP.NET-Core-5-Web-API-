using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100,MinimumLength =3)]
        public string Title { get; set; }
        [Required]
        public double Rate { get; set; }
        public byte[] Poster { get; set; }
        [ForeignKey("Genrie")]
        public int GenrieId { get; set; }
        public virtual Genrie Genrie { get; set; }

    }
}
