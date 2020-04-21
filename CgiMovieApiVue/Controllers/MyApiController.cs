using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CgiMovieApiVue.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CgiMovieApiVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyApiController<TEntity, TRepository> : ControllerBase
         where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MyApiController(TRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var result = await repository.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
    }
}