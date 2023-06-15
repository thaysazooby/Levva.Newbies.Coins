using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Data;

namespace Levva.Newbies.Coins.Data.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly Context _context;
        public TransacaoRepository(Context context)
        {
            _context = context;
        }
        public Transacao Create(Transacao transacao)
        {
            transacao.CreatedAt = DateTime.Now;
            _context.Transacao.Add(transacao);
            _context.SaveChanges();

            return transacao;
        }

        public void Delete(int Id)
        {
            var transacao = _context.Transacao.Find(Id);
            _context.Transacao.Remove(transacao);
            _context.SaveChanges();
        }

        public Transacao Get(int id)
        {
            return _context.Transacao.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<Transacao> GetAll()
        {
            return _context.Transacao.Include(x => x.Category).OrderByDescending(x => x.CreatedAt).ToList();
        }

        public ICollection<Transacao> SearchByDescription(string search)
        {
            return _context.Transacao.Include(x => x.Category)
                .Where(x => EF.Functions.Like(x.Description, $"%{search}%") || EF.Functions.Like(x.Category.Description, $"%{search}%"))
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }

        public void Update(Transacao transacao)
        {
            _context.Transacao.Update(transacao);
            _context.SaveChanges();
        }
    }
}
