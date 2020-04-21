using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CgiMovieApiVue.Data;
using CgiMovieApiVue.Models;
using CgiMovieApiVue.Data.EFCore;

namespace CgiMovieApiVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : MyApiController<Movie, EfCoreMovieRepository>
    {
        public MoviesController(EfCoreMovieRepository repository) : base(repository)
        {

        }

    }
}
