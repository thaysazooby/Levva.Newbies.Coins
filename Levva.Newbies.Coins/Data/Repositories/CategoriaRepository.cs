using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Levva.Newbies.Coins.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Context _context;
        public CategoriaRepository(Context context)
        {
            _context = context;
        }
        public Categoria Create(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public void Delete(int Id)
        {
            var categoria = _context.Categoria.Find(Id);
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
        }

        public Categoria Get(int Id)
        {
            return _context.Categoria.Find(Id);
        }

        public List<Categoria> GetAll()
        {
            return _context.Categoria.ToList();
        }

        public void Update(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            _context.SaveChanges();
        }
    }
}
