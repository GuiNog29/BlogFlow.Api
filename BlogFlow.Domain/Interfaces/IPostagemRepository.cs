using BlogFlow.Domain.Entities;

namespace BlogFlow.Domain.Interfaces
{
    public interface IPostagemRepository
    {
        Task<Postagem> Cadastrar(Postagem postagem);
        Task<Postagem?> Visualizar(int postagemId);
        Task<bool> Editar(Postagem postagem);
        Task<bool> Excluir(int postagemId);
        Task<IEnumerable<Postagem>?> Listar();
        Task<IEnumerable<Postagem>?> ListarPostagensUsuario(int usuarioId);
    }
}
