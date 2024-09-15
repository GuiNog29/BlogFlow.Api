namespace BlogFlow.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public ICollection<PostagemDto>? Postagens { get; set; }
    }
}
