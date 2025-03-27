using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WDWE.Domain.ViewModels.Dish;
using WDWE.Domain.ViewModels.User;
using WDWE.Service.Interfaces;

namespace WhatDoWeEat.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishService _dishService;
        private readonly IUserService _userService;

        public DishController(IDishService dishService, IUserService userService)
        {
            _dishService = dishService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDish(CreateDishViewModel model)
        {
            var response = await _dishService.Create(model);
            if(response.StatusCode == WDWE.Domain.Response.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            var response = await _userService.Create(model);
            if (response.StatusCode == WDWE.Domain.Response.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }
            return BadRequest();
        }
    }
}
