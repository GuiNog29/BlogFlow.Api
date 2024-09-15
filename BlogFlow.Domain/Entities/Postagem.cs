using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogFlow.Domain.Entities
{
    public class Postagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
    }
}
