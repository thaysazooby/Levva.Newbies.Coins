using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;
        public UsuarioRepository(Context context)
        {
            _context = context;
        }
        public void Create(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var usuario = _context.Usuario.Find(Id);
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public Usuario Get(int Id)
        {
            return _context.Usuario.Find(Id);
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            return _context.Usuario.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(senha));
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }
    }
}
