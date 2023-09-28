namespace Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string TipoPessoa { get; set; }
        public byte Foto { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string CNPJ_CPF { get; set; }
        public string IE_RG { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Celular { get; set; }
        public string WhatsApp { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool ativo { get; set; }
    }
}