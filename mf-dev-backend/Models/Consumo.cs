using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório! ")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório! ")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório! ")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório! ")]
        public int Km { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório! ")]
        public TipoCombustivel Tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório! ")]
        [Display(Name = "Veículo")]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }
    }

    public enum TipoCombustivel
    {
        Gasolina,
        Etanol,
        Diesel,
    }
}
