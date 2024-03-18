using Models;
using Data;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Business;

public class FuncionService
{
    private readonly IFuncionRepository _funcionRepository;
    private readonly ILogger<ObraService> _logger;

    public FuncionService(IFuncionRepository funcionRepository, ILogger<ObraService> logger)
    {
        _funcionRepository = funcionRepository;
        _logger = logger;
    }

    public List<FuncionDto> GetAll()
    {
        _logger.LogInformation("Obteniendo todas las funciones.");
        try
        {
            var funciones = _funcionRepository.GetAll();
            var funcionDtos = new List<FuncionDto>();

            foreach (var f in funciones)
            {
                var totalAsientosInicial = (f.Sala.NumeroFilas ?? 0) * (f.Sala.NumeroColumnas ?? 0);
                var totalAsientosAjustados = SitiosCorrectos(f.SalaID, totalAsientosInicial);
                var reservas = _funcionRepository.GetFunciones(f.FuncionID);
                var asientosRestantes = totalAsientosAjustados - reservas;
                _logger.LogInformation($"Función ID: {f.FuncionID} - Total asientos inicial: {totalAsientosInicial}, Total asientos ajustados: {totalAsientosAjustados}, Reservas: {reservas}, Asientos restantes: {asientosRestantes}");

                var funcionDto = new FuncionDto
                {
                    FuncionID = f.FuncionID,
                    ObraID = f.ObraID,
                    SalaID = f.SalaID,
                    Fecha = f.Fecha,
                    Hora = f.Hora,
                    Disponibilidad = f.Disponibilidad,
                    AsientosDisponibles = totalAsientosAjustados,
                    AsientosRestantes = asientosRestantes,

                    Obra = new ObraDto
                    {
                        ObraID = f.Obra.ObraID,
                        Titulo = f.Obra.Titulo,
                        Director = f.Obra.Director,
                        Sinopsis = f.Obra.Sinopsis,
                        Duración = f.Obra.Duración,
                        Precio = f.Obra.Precio,
                        Imagen = f.Obra.Imagen,
                        Actores = f.Obra.ObraActores.Select(oa => new ActorDto
                        {
                            ActorId = oa.ActorId,
                            Nombre = oa.Actor.Nombre
                        }).ToList()
                    },
                    Sala = new SalaDto
                    {
                        SalaID = f.Sala.SalaID,
                        Nombre = f.Sala.Nombre,
                        NumeroFilas = f.Sala.NumeroFilas ?? 0,
                        NumeroColumnas = f.Sala.NumeroColumnas ?? 0,
                    }
                };

                funcionDtos.Add(funcionDto);
            }

            _logger.LogInformation($"Retornadas {funciones.Count} funciones.");
            return funcionDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todas las funciones.");
            throw;
        }
    }

    public FuncionDto? Get(int id)
    {
        _logger.LogInformation($"Buscando funcion con ID: {id}");
        try
        {
            var funcion = _funcionRepository.Get(id);
            if (funcion == null)
            {
                _logger.LogWarning($"Funcion con ID: {id} no encontrada.");
                return null;
            }

            var totalAsientosInicial = (funcion.Sala.NumeroFilas ?? 0) * (funcion.Sala.NumeroColumnas ?? 0);
            var totalAsientosAjustados = SitiosCorrectos(funcion.SalaID, totalAsientosInicial);
            var reservas = _funcionRepository.GetFunciones(id);
            var asientosRestantes = totalAsientosAjustados - reservas;
            _logger.LogInformation($"Función ID: {id} - Total asientos inicial: {totalAsientosInicial}, Total asientos ajustados: {totalAsientosAjustados}, Reservas: {reservas}, Asientos restantes: {asientosRestantes}");

            var funcionDto = new FuncionDto
            {
                FuncionID = funcion.FuncionID,
                ObraID = funcion.ObraID,
                SalaID = funcion.SalaID,
                Fecha = funcion.Fecha,
                Hora = funcion.Hora,
                Disponibilidad = funcion.Disponibilidad,
                AsientosDisponibles = totalAsientosAjustados,
                AsientosRestantes = asientosRestantes,

                Obra = new ObraDto
                {
                    ObraID = funcion.Obra.ObraID,
                    Titulo = funcion.Obra.Titulo,
                    Director = funcion.Obra.Director,
                    Sinopsis = funcion.Obra.Sinopsis,
                    Duración = funcion.Obra.Duración,
                    Precio = funcion.Obra.Precio,
                    Imagen = funcion.Obra.Imagen,
                    Actores = funcion.Obra.ObraActores.Select(oa => new ActorDto
                    {
                        ActorId = oa.ActorId,
                        Nombre = oa.Actor.Nombre
                    }).ToList() ?? new List<ActorDto>()
                },

                Sala = new SalaDto
                {
                    SalaID = funcion.Sala.SalaID,
                    Nombre = funcion.Sala.Nombre,
                    NumeroFilas = funcion.Sala.NumeroFilas ?? 0,
                    NumeroColumnas = funcion.Sala.NumeroColumnas ?? 0,
                }
            };
            _logger.LogInformation($"Funcion con ID: {id} encontrada.");
            return funcionDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener la funcion con ID: {id}.");
            throw;
        }
    }

    public int Add(FuncionPostDto funcionPostDto)
    {
        try
        {
            _logger.LogInformation($"Intentando agregar una nueva funcion: {JsonSerializer.Serialize(funcionPostDto)}");
            var funcion = new Funcion
            {
                FuncionID = funcionPostDto.FuncionID,
                ObraID = funcionPostDto.ObraID,
                SalaID = funcionPostDto.SalaID,
                Fecha = funcionPostDto.Fecha ?? throw new InvalidOperationException("La fecha es requerida"),
                Hora = funcionPostDto.Hora,
                Disponibilidad = funcionPostDto.Disponibilidad,
            };
            _funcionRepository.Add(funcion);
            _logger.LogInformation($"Funcion agregada con éxito con ID {funcion.FuncionID}");
            return funcion.FuncionID;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar una nueva funcion");
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            _logger.LogInformation($"Intentando eliminar la funcion con ID: {id}");
            _funcionRepository.Delete(id);
            _logger.LogInformation($"Funcion con ID: {id} eliminada correctamente.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al eliminar la funcion con ID: {id}");
            throw;
        }
    }

    public void Update(FuncionPostDto funcionPostDto, int id)
    {
        try
        {
            _logger.LogInformation($"Intentando actualizar la funcion con ID: {id}");
            var funcion = _funcionRepository.Get(id);
            if (funcion == null)
            {
                _logger.LogWarning($"No se encontró la funcion con ID: {id} para actualizar.");
                return;
            }

            funcion.FuncionID = funcionPostDto.FuncionID;
            _logger.LogInformation($"Cambiando FuncionID de '{funcion.FuncionID}' a '{funcionPostDto.FuncionID}'.");
            funcion.ObraID = funcionPostDto.ObraID;
            _logger.LogInformation($"Cambiando ObraID de '{funcion.ObraID}' a '{funcionPostDto.ObraID}'.");
            funcion.SalaID = funcionPostDto.SalaID;
            _logger.LogInformation($"Cambiando SalaID de '{funcion.SalaID}' a '{funcionPostDto.SalaID}'.");
            funcion.Fecha = funcionPostDto.Fecha ?? throw new InvalidOperationException("La fecha es requerida");
            _logger.LogInformation($"Cambiando Fecha de '{funcion.Fecha}' a '{funcionPostDto.Fecha}'.");
            funcion.Hora = funcionPostDto.Hora;
            _logger.LogInformation($"Cambiando Hora de '{funcion.Hora}' a '{funcionPostDto.Hora}'.");
            funcion.Disponibilidad = funcionPostDto.Disponibilidad;
            _logger.LogInformation($"Cambiando Disponibilidad de '{funcion.Disponibilidad}' a '{funcionPostDto.Disponibilidad}'.");
            _funcionRepository.Update(funcion, id);
            _logger.LogInformation($"Funcion con ID: {id} actualizada correctamente.");

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al actualizar la funcion con ID: {id}");
            throw;
        }
    }

    public List<FuncionDto> GetObras(int id)
    {
        try
        {
            var obras = _funcionRepository.GetObras(id);
            if (obras == null || !obras.Any())
            {
                _logger.LogWarning($"Obra con ID: {id} no encontrada.");
                return null;
            }

            var funcionDtos = obras.Select(obra =>
            {
                var totalAsientosInicial = (obra.Sala.NumeroFilas ?? 0) * (obra.Sala.NumeroColumnas ?? 0);
                var totalAsientosAjustados = SitiosCorrectos(obra.SalaID, totalAsientosInicial);
                var reservas = _funcionRepository.GetFunciones(obra.FuncionID);
                var asientosRestantes = totalAsientosAjustados - reservas;
                _logger.LogInformation($"Función ID: {id} - Total asientos inicial: {totalAsientosInicial}, Total asientos ajustados: {totalAsientosAjustados}, Reservas: {reservas}, Asientos restantes: {asientosRestantes}");

                return new FuncionDto
                {
                    FuncionID = obra.FuncionID,
                    ObraID = obra.ObraID,
                    SalaID = obra.SalaID,
                    Fecha = obra.Fecha,
                    Hora = obra.Hora,
                    Disponibilidad = obra.Disponibilidad,
                    AsientosDisponibles = totalAsientosAjustados,
                    AsientosRestantes = asientosRestantes,
                    Obra = new ObraDto
                    {
                        ObraID = obra.Obra.ObraID,
                        Titulo = obra.Obra.Titulo,
                        Director = obra.Obra.Director,
                        Sinopsis = obra.Obra.Sinopsis,
                        Duración = obra.Obra.Duración,
                        Precio = obra.Obra.Precio,
                        Imagen = obra.Obra.Imagen,
                        Actores = obra.Obra.ObraActores.Select(oa => new ActorDto
                        {
                            ActorId = oa.ActorId,
                            Nombre = oa.Actor.Nombre
                        }).ToList()
                    }
                };
            }).ToList();
            _logger.LogInformation($"Obra con ID: {id} encontrada con información de asientos incluida.");
            return funcionDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener las obras con ID: {id} y la información de asientos.");
            throw;
        }
    }
    private int SitiosCorrectos(int salaID, int totalAsientosInicial)
    {
        const int sala1 = 7;
        const int sala2 = 3;
        const int sala3 = 6;
        const int sala4 = 5;
        const int sala5 = 9;
        const int sala6 = 9;

        switch (salaID)
        {
            case 1:
                totalAsientosInicial = totalAsientosInicial - sala1;
                break;
            case 2:
                totalAsientosInicial = totalAsientosInicial - sala2;
                break;
            case 3:
                totalAsientosInicial = totalAsientosInicial - sala3;
                break;
            case 4:
                totalAsientosInicial = totalAsientosInicial - sala4;
                break;
            case 5:
                totalAsientosInicial = totalAsientosInicial - sala5;
                break;
            case 6:
                totalAsientosInicial = totalAsientosInicial - sala6;
                break;
            default:
                break;
        }
        return totalAsientosInicial;
    }
}