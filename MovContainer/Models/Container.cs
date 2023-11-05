using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovContainer.Models
{
    public enum Tipo { Vinte_Pes, Quarenta_Pes }
    public enum Status { Cheio, Vazio }
    public enum Categoria { Importacao, Exportacao }

    [Table("Containers")]
    public class Container
    {
        public int ContainerId { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]{4}\\d{7}$",
        ErrorMessage = "O N° do container deverá ter 4 letras e 7 números.")]
        [MaxLength(11)]
        public string Numero { get; set; }

        [Required]
        public Tipo TipoSelecionado { get; set; }

        [Required]
        public Status StatusSelecionado { get; set; }

        [Required]
        public Categoria CategoriaSelcionada { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public List<Movimentacao> Movimentacoes { get; set; }
    }
}
