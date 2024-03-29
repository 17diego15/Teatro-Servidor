using Data;
using Business;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var keyString = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
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

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
