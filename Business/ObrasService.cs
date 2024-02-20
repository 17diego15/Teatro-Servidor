using Models;
using Data;
using System.Collections.Generic;

namespace Business;

public class ObrasService
{
    private readonly IObraRepository _obrasRepository;

    public ObrasService(IObraRepository obrasRepository)
    {
        _obrasRepository = obrasRepository;
    }

    public List<Obras> GetAll()
    {
        return _obrasRepository.GetAll();
    }

    public Obras? Get(int id)
    {
        return _obrasRepository.Get(id);
    }

    public void Add(Obras obras)
    {
        _obrasRepository.Add(obras);
    }

    public void Delete(int id)
    {
        _obrasRepository.Delete(id);
    }

    public void Put(Obras obras)
    {
        _obrasRepository.Put(obras);
    }
}
