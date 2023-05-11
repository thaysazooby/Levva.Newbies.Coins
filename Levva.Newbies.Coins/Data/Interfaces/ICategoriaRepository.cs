using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Interfaces
{
    public interface ICategoriaRepository
    {
        void Create(Categoria categoria);
        Categoria Get(int Id);
        List<Categoria> GetAll();
        void Update(Categoria categoria);
        void Delete(int Id);
    }
}
