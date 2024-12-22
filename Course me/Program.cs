using System.Reflection;
using BusinessLogic.Services;
using Course_me.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MecourselaContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionString"]));

// Add services to the container.
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
