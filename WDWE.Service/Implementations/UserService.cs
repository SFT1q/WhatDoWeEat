using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDWE.Domain.Entity;
using WDWE.Domain.Response;
using WDWE.Domain.ViewModels.User;
using WDWE.Repositories.Interfaces;
using WDWE.Service.Interfaces;

namespace WDWE.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private ILogger<UserService> _logger;

        public UserService(IBaseRepository<User> userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IBaseReponse<User>> Create(CreateUserViewModel model)
        {
            try
            {
                _logger.LogInformation($"Запрос на создание пользователя: {model.Name}");
                if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Email)) 
                {
                    return new BaseResponse<User>
                    {
                        Description = "Имя и Email не могут быть пустыми",
                        StatusCode = StatusCode.IsHasAlready
                    };
                }
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email
                };

                await _userRepository.Create(user);
                
                return new BaseResponse<User>
                {
                    Description = "Пользователь успешно добавлен",
                    StatusCode = StatusCode.Ok,
                    Data = user
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании пользователя");

                return new BaseResponse<User>
                {
                    Description = "Произошла ошибка при создании пользователя",
                    StatusCode = StatusCode.InternalServerEror
                };
            }
        }
    }
}
