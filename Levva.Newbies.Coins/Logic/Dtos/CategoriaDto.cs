namespace Levva.Newbies.Coins.Logic.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual List<TransacaoDto>? Transacoes { get; set; }
    }
}
