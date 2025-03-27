using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDWE.DataBase;
using WDWE.Domain.Entity;
using WDWE.Repositories.Interfaces;

namespace WDWE.Repositories.Repositories
{
    public class DishRepository : IBaseRepository<Dish>
    {
        private readonly ApplicationContext _applicationContext;

        public DishRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Create(Dish entity)
        {
            await _applicationContext.Dishes.AddAsync(entity);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
