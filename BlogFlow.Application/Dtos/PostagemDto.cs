namespace BlogFlow.Application.Dtos
{
    public class PostagemDto
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Conteudo { get; set; }
        public int UsuarioId { get; set; }
        public required UsuarioDto Usuario { get; set; }
    }
}
