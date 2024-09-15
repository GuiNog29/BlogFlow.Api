using BlogFlow.Domain.Entities;

namespace BlogFlow.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Cadastrar(Usuario usuario);
        Task<Usuario?> Visualizar(int usuarioId);
        Task<bool> Editar(Usuario usuario);
        Task<bool> Excluir(int usuarioId);
        Task<IEnumerable<Usuario>> Listar();
    }
}
