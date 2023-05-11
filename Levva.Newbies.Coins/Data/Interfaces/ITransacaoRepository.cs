using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Interfaces
{
    public interface ITransacaoRepository
    {
        void Create(Transacao transacao);
        Transacao Get(int Id);
        List<Transacao> GetAll();
        void Update(Transacao transacao);
        void Delete(int Id);
    }
}
