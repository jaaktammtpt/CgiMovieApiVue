using CgiMovieApiVue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CgiMovieApiVue.Data.EFCore
{
    public class EfCoreMovieRepository : EfCoreRepository<Movie, ApiDbContext>
    {
        public EfCoreMovieRepository(ApiDbContext context) : base(context)
        {
        }

        // We can add new methods specific to the movie repository here in the future
    }
}
