using Levva.Newbies.Coins.Logic.Dtos;

namespace Levva.Newbies.Coins.Logic.Interfaces
{
    public interface ITransacaoService
    {
        TransacaoDto Create(int userId, CreateTransacaoDto transacao);
        TransacaoDto Get(int Id);
        List<TransacaoDto> GetAll();
        void Update(TransacaoDto transacao);
        void Delete(int Id);

        List<TransacaoDto> SearchDescription(string search);
    }
}
