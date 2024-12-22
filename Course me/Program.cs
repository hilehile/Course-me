using System.Reflection;
using BusinessLogic.Services;
using Course_me.Models;
using DataAccess.Repositories;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Регистрация контекста базы данных
builder.Services.AddDbContext<MecourselaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

// Регистрация репозиториев
builder.Services.AddScoped<IAnalyticRepository, AnalyticRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IDietRepository, DietRepository>();
builder.Services.AddScoped<IDietGoalRepository, DietGoalRepository>();
builder.Services.AddScoped<IDietTypeRepository, DietTypeRepository>();
builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IDishProductRepository, DishProductRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseGoalRepository, ExerciseGoalRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDetailRepository, UserDetailRepository>();
builder.Services.AddScoped<IWaterIntakeRepository, WaterIntakeRepository>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

// Регистрация сервисов
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnalyticService, AnalyticService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IDietService, DietService>();
builder.Services.AddScoped<IDietGoalService, DietGoalService>();
builder.Services.AddScoped<IDietTypeService, DietTypeService>();
builder.Services.AddScoped<IDishProductService, DishProductService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IExerciseGoalService, ExerciseGoalService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IUserDetailService, UserDetailService>();
builder.Services.AddScoped<IWaterIntakeService, WaterIntakeService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();