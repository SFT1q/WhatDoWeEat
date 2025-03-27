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
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Create(User entity)
        {
            await _applicationContext.Users.AddAsync(entity);
            await _applicationContext.SaveChangesAsync();   
        }
    }
}
