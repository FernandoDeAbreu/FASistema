namespace Domain.Entities
{
    public class VendaItens
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public virtual Venda Venda { get; set; }
        public int ProdutoId { get; set; }
        public float Quantidade { get; set; }
        public float ValorOriginal { get; set; }
        public float ValorDesconto { get; set; }
        public float ValorAcrescimo { get; set; }
        public float ValorPago { get; set; }
    }
}