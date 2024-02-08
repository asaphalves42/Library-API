using Microsoft.EntityFrameworkCore;
using TrabalhoFinalDOS.Services;
using TrabalhoFinalDOS.Repository;
using TrabalhoFinalDOS.Controllers;
using TrabalhoFinalDOS._2___Services.Excepcoes;
using TrabalhoFinalDOS._2_Services.Interfaces;
using TrabalhoFinalDOS._2_Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//ligar base de dados
builder.Services.AddDbContext<BaseDados>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("database");
    options.UseSqlServer(connectionString);
});

// injectar os servišos
builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<ILivrosService, LivrosService>();
builder.Services.AddScoped<IReservasService, ReservasService>();
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerTrabalhoFinal v1");
});


app.UseAuthorization();

app.MapControllers();

app.Run();