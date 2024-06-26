using Serilog;
using Serilog.Events;
using Data;
using Business;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/application.log", rollingInterval: RollingInterval.Day)
    .WriteTo.Debug()
    .CreateLogger();
builder.Host.UseSerilog();


var keyString = "ServerDB";
var connectionString = builder.Configuration.GetConnectionString(keyString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TeatroContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ObraService>();
builder.Services.AddScoped<IObraRepository, ObraRepository>();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<ActorService>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();

builder.Services.AddScoped<FuncionService>();
builder.Services.AddScoped<IFuncionRepository, FuncionRepository>();

builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();

builder.Services.AddScoped<SalaService>();
builder.Services.AddScoped<ISalaRepository, SalaRepository>();

builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        policy => policy
            .WithOrigins("*") 
            .AllowAnyMethod() 
            .AllowAnyHeader()); 
});


var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();
app.UseCors("MyCorsPolicy");
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
