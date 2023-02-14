using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2;
using WebApplication2.Contract;
using WebApplication2.Models;
using WebApplication2.Repository;
/*using WebApplication2.Service;
*/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICoinRepository,CoinRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
/*builder.Services.AddScoped<ICoinService, CoinService>();
builder.Services.AddScoped<IWalletService, WalletService>();*/
builder.Services.AddScoped<ApiResponse>();
builder.Services.AddScoped<SResponse>();
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
