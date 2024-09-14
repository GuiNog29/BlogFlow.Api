using BlogFlow.Application.Dtos;

namespace BlogFlow.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> Cadastrar(UsuarioDto usuarioDto);
        Task<UsuarioDto?> Visualizar(int usuarioId);
        Task<bool> Editar(UsuarioDto usuarioDto);
        Task<bool> Excluir(int usuarioId);
        Task<IEnumerable<UsuarioDto>> Listar();
    }
}
