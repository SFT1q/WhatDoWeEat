using Microsoft.EntityFrameworkCore;
using WDWE.DataBase;
using WDWE.Domain.Entity;
using WDWE.Repositories.Interfaces;
using WDWE.Repositories.Repositories;
using WDWE.Service.Implementations;
using WDWE.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<IBaseRepository<Dish>, DishRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dish}/{action=Index}/{id?}");

app.Run();
