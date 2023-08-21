using APIforPI.Actions;
using APIforPI.Configuration;
using APIforPI.Data;
using APIforPI.Infrastracture.Interfaces;
using APIforPI.Interfaces;
using APIforPI.Seed;
using APIforPI.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IDbSushiService, DatabaseService>();
builder.Services.AddScoped<ISushiService, SushiService>();
builder.Services.AddScoped<ISetService, SetService>();
builder.Services.AddScoped<IDbSetsService, DatabaseService>();
builder.Services.AddScoped<ITimeApi, TimeClientApi>();
builder.Services.AddScoped<IWorldApiService, WorldApiService>();
builder.Services.AddTransient<SeedDataToDb>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<Mapper>(provider => AutoMapperConfiguration.CreateMapper());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("APIforPI"));
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDataToDb>();
        service.SeedDataContext();
    }
}

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
