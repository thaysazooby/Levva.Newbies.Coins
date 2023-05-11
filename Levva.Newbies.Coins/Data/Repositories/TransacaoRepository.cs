using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using SQLitePCL;

namespace Levva.Newbies.Coins.Data.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly Context _context;
        public TransacaoRepository(Context context)
        {
            _context = context;
        }
        public void Create(Transacao transacao)
        {
            _context.Transacao.Add(transacao);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var transacao = _context.Transacao.Find(Id);
            _context.Transacao.Remove(transacao);
            _context.SaveChanges();
        }

        public Transacao Get(int Id)
        {
            return _context.Transacao.Find(Id);
        }

        public List<Transacao> GetAll()
        {
            return _context.Transacao.ToList();
        }

        public void Update(Transacao transacao)
        {
            _context.Transacao.Update(transacao);
            _context.SaveChanges();
        }
    }
}
