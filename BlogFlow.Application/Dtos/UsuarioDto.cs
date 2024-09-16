using System.Text.Json.Serialization;

namespace BlogFlow.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        [JsonIgnore]
        public bool EhAdmin { get; set; } = false;
        [JsonIgnore]
        public ICollection<PostagemDto> Postagens { get; set; } = new List<PostagemDto>();
    }
}
