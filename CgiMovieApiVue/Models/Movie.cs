using CgiMovieApiVue.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CgiMovieApiVue.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Description { get; set; }

        public string Rating { get; set; }

        [IgnoreDataMember]
        public int CategoryId { get; set; }

        
        public virtual Category Category { get; set; }

        public Movie()
        {

        }

    }
}
