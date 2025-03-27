using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDWE.Domain.Entity;
using WDWE.Domain.Response;
using WDWE.Domain.ViewModels.User;

namespace WDWE.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseReponse<User>> Create(CreateUserViewModel model);
    }
}
