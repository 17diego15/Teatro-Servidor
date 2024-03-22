using Models;

namespace Data;

public interface IPedidoRepository
{
    List<Pedido> GetAll();
    Pedido? Get(int id);
    void Add(List<Pedido> pedido);
    void Delete(int id);
    void Update(Pedido pedido, int id);
}

