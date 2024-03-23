using Models;

namespace Data;

public interface IPedidoRepository
{
    List<Pedido> GetAll();
    Pedido? Get(int id);
    void Add(Pedido pedido);
}

