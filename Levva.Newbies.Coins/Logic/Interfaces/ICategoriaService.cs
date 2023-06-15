using Levva.Newbies.Coins.Logic.Dtos;

namespace Levva.Newbies.Coins.Logic.Interfaces
{
    public interface ICategoriaService
    {
        CategoriaDto Create(CreateCategoriaDto categoria);
        CategoriaDto Get(int id);
        List<CategoriaDto> GetAll();
        void Update(CategoriaDto categoria);
        void Delete(int id);
    }
}
