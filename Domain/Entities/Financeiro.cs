using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Financeiro
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime DataVencimento{ get; set; }
        public DateTime DataCompetencia{ get; set; }
        public DateTime DataPagamento{ get; set; }
        public float ValorOriginal { get; set; }
        public float ValorDesconto { get; set; }
        public float ValorAcrescimo { get; set; }
        public float ValorPago { get; set; }

    }
}
