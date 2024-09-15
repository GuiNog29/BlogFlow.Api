using BlogFlow.Application.Dtos;

namespace BlogFlow.Application.Interfaces
{
    public interface IPostagemService
    {
        Task<PostagemDto> Cadastrar(PostagemDto postagemDto);
        Task<PostagemDto?> Visualizar(int postagemId);
        Task<bool> Editar(PostagemDto postagemDto);
        Task<bool> Excluir(int postagemId);
        Task<IEnumerable<PostagemDto>> Listar();
        Task<IEnumerable<PostagemDto>> ListarPostagensUsuario(int usuarioId);
    }
}
