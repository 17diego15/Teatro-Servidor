using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class ReservaService
{
    private readonly IReservaRepository _reservaRepository;

    public ReservaService(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public List<ReservaDto> GetAll()
    {
        var reserva = _reservaRepository.GetAll();

        var reservaDto = reserva.Select(r => new ReservaDto
        {
            ReservaID = r.ReservaID,
            FuncionID = r.FunciónID ?? 0,
            NumeroFila = r.NumeroFila ?? 0,
            NumeroColumna = r.NumeroColumna ?? 0,
            // Sala = r.Sala == null ? null : new SalaDto
            // {
            //     SalaID = r.Sala.SalaID,
            //     Nombre = r.Sala.Nombre,
            //     NumeroFilas = r.Sala.NumeroFilas ?? 0,
            //     NumeroColumnas = r.Sala.NumeroColumnas ?? 0
            // }
        }).ToList();

        return reservaDto;
    }

    public Reserva? Get(int id)
    {
        return _reservaRepository.Get(id);
    }

    public List<ReservaDto> GetFuncion(int id)
    {
        var reservas = _reservaRepository.GetFuncion(id);
        if (reservas == null) return null;

        var reservaDtos = reservas.Select(r => new ReservaDto
        {
            ReservaID = r.ReservaID,
            FuncionID = r.FunciónID ?? 0,
            NumeroFila = r.NumeroFila ?? 0,
            NumeroColumna = r.NumeroColumna ?? 0,
            // Sala = r.Sala == null ? null : new SalaDto
            // {
            //     SalaID = r.Sala.SalaID,
            //     Nombre = r.Sala.Nombre,
            //     NumeroFilas = r.Sala.NumeroFilas ?? 0,
            //     NumeroColumnas = r.Sala.NumeroColumnas ?? 0
            // }
        }).ToList();

        return reservaDtos;

    }

    public List<int> Add(List<ReservaDto> reservasDto)
    {
        var reservas = reservasDto.Select(reservaDto => new Reserva
        {
            ReservaID = reservaDto.ReservaID,
            FunciónID = reservaDto.FuncionID,
            //SalaID = reservaDto.SalaID,
            NumeroFila = reservaDto.NumeroFila,
            NumeroColumna = reservaDto.NumeroColumna
        }).ToList();
        _reservaRepository.Add(reservas);
        return reservas.Select(r => r.ReservaID).ToList();
    }

    public void Delete(int id)
    {
        _reservaRepository.Delete(id);
    }

    public void Update(Reserva reserva, int id)
    {
        _reservaRepository.Update(reserva, id);
    }
}