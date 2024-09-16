using System.Text.Json.Serialization;

namespace BlogFlow.Application.Dtos
{
    public class PostagemDto
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public UsuarioDto? Usuario { get; set; }
    }
}
