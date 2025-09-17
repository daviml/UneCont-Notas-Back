using System.ComponentModel.DataAnnotations;

namespace UneCont_Notas_Fiscais.Models
{
    public class NotasFiscais
    {
        public int Id { get; set; } // Adicione esta propriedade
        public int NumeroDaNota { get; set; }
        public string NomeCliente { get; set; }
        public decimal Valor { get; set; }
        public DateOnly DataEmissao { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}