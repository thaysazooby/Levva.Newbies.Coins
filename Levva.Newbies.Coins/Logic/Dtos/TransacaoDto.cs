using Levva.Newbies.Coins.Domain.Enums;
using Levva.Newbies.Coins.Logic.Dtos;

namespace Levva.Newbies.Coins.Logic.Dtos
{
    public class TransacaoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoTransacaoEnum Tipo { get; set;}
        public int CategoriaId { get; set; }
        public virtual CategoriaDto? Categoria { get; set; }
        public int UsuarioId { get; set; }
        public virtual UsuarioDto? Usuario { get; set; }
    }
}
