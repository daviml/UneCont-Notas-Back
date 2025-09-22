using System.ComponentModel.DataAnnotations;

namespace UneCont_Notas_Fiscais.DTOs
{
    public class NotasFiscaisDto
    {
        [Required(ErrorMessage = "O número da nota é obrigatório.")]
        public int NumeroDaNota { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do cliente não pode exceder 100 caracteres.")]
        public required string NomeCliente { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que 0.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data de emissão é obrigatória.")]
        public DateOnly DataEmissao { get; set; }
    }
}