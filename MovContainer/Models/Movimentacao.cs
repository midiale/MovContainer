using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovContainer.Models
{
    public enum TipoDeMovimetacao
    {
        Embarque, Descarga, Gate_In,
        Gate_Out, Reposicionamento,
        Pesagem, Scanner
    }

    [Table("Movimentacoes")]
    public class Movimentacao
    {
        public int MovimentacaoId { get; set; }

        [Display(Name = "Tipo de Movimentação")]
        public TipoDeMovimetacao MovimentacaoSelecionada { get; set; }

        [Display(Name = "Inicio da Movimentação")]
        public DateTime DataHoraInicio { get; set; }

        [Display(Name = "Fim da Movimentação")]
        public DateTime DataHoraFim { get; set; }
        public int ContainerId { get; set; }
        public virtual Container Container { get; set; }

    }
}
