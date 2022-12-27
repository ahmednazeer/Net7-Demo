using Core;
using Core.contracts;
using Dal;
using Dal.contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWatchDogServices(opt => {
    opt.SetExternalDbConnString = builder.Configuration.GetConnectionString("heroDBConnection");
    opt.SqlDriverOption = WatchDog.src.Enums.WatchDogSqlDriverEnum.MSSQL;

});
//core services
builder.Services.AddScoped<ISuperHeroCoreService, SuperHeroCoreService>();
builder.Services.AddDbContext<SuperHeroContext>(options => options.UseSqlServer(""));
//DAL services
builder.Services.AddScoped<IHeroServiceDal, HeroServiceDal>();

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
app.UseWatchDogExceptionLogger();
app.UseWatchDog(opt => {
    opt.WatchPageUsername= builder.Configuration.GetSection("appSettings:wtachDogUsername").Value;
    opt.WatchPagePassword = builder.Configuration.GetSection("appSettings:wtachDogPassword").Value;
});

app.Run();
