using CgiMovieApiVue.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CgiMovieApiVue.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Name { get; set; }

        [IgnoreDataMember]
        public virtual List<Movie> Movies { get; set; }

        public Category()
        {
        }

    }
}
