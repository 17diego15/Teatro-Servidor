using Models;

namespace Data;

public interface IPedidoRepository
{
    List<Pedido> GetAll(int UsuarioID);
    Pedido? Get(int id);
    void Add(Pedido pedido);
}

