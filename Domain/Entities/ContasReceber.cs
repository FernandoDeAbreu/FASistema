namespace Domain.Entities
{
    public class ContasReceber : Financeiro
    {
        public int ClienteId { get; set; }

        public int VendaId { get; set; }
        public virtual Venda Venda { get; set; }
    }
}