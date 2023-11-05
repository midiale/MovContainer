using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovContainer.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        public string Empresa { get; set; }

        public DateTime DataCadastro { get; set; }

        public List<Container> Containers { get; set; }

    }
}
