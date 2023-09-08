using APIforPI.Actions;
using APIforPI.Actions.Contracts;
using APIforPI.Configuration;
using APIforPI.Data;
using APIforPI.DbServices;
using APIforPI.Infrastracture.Interfaces;
using APIforPI.Seed;
using APIforPI.Services;
using APIforPI.Services.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<IDbSushiService, SushiSetsRepository>();
builder.Services.AddScoped<ISushiService, SushiService>();
builder.Services.AddScoped<ISetService, SetService>();
builder.Services.AddScoped<IDbProductService, SushiSetsRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDbSetsService, SushiSetsRepository>();
builder.Services.AddScoped<ITimeApi, TimeClientApi>();
builder.Services.AddScoped<IWorldApiService, WorldApiService>();
builder.Services.AddScoped<IDbCartItemService, CartItemRepository>();
builder.Services.AddScoped<ICartService, CartService>();
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

app.UseCors(pol =>
pol.WithOrigins("http://localhost:7292", "https://localhost:7292")
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
