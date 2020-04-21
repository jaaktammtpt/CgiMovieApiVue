using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CgiMovieApiVue.Data
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
    }
}
