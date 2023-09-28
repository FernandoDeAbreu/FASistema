namespace Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int ClienteID { get; set; }

        public int UsuarioID { get; set; }

        public bool Cancelada { get; set; }
    }
}