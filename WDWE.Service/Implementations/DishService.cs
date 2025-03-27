using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDWE.Domain.Entity;
using WDWE.Domain.Response;
using WDWE.Domain.ViewModels.Dish;
using WDWE.Repositories.Interfaces;
using WDWE.Service.Interfaces;

namespace WDWE.Service.Implementations
{
    public class DishService : IDishService
    {
        private readonly IBaseRepository<Dish> _dishRepository;
        private readonly ILogger<DishService> _logger;

        public DishService(IBaseRepository<Dish> dishRepository, ILogger<DishService> logger)
        {
            _dishRepository = dishRepository;
            _logger = logger;
        }

        public async Task<IBaseReponse<Dish>> Create(CreateDishViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return new BaseResponse<Dish>
                    {
                        Description = "Название блюда не может быть пустым",
                        StatusCode = StatusCode.IsHasAlready
                    };
                }

                var dish = new Dish
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Created = DateTime.Now,
                    Description = model.Description,
                    IsExist = true,
                };

                await _dishRepository.Create(dish);

                return new BaseResponse<Dish>
                {
                    Description = "Блюдо успешно создано",
                    StatusCode = StatusCode.Ok,
                    Data = dish
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при создании блюда");

                return new BaseResponse<Dish>
                {
                    Description = "Произошла ошибка при создании блюда",
                    StatusCode = StatusCode.InternalServerEror
                };
            }
        }
    }
}
