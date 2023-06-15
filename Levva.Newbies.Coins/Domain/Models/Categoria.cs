namespace Levva.Newbies.Coins.Domain.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual List<Transacao> Transactions { get; set; }
    }
}
