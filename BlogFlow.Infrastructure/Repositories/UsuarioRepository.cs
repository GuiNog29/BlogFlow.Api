using BlogFlow.Domain.Entities;
using BlogFlow.Domain.Interfaces;
using BlogFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogFlow.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _dbContext;
        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> Cadastrar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> Visualizar(int usuarioId)
        {
            return await ExisteUsuario(usuarioId);
        }

        public async Task<bool> Editar(Usuario usuario)
        {
            if (await ExisteUsuario(usuario.Id) == null)
                return false;

            var local = _dbContext.Set<Usuario>()
                          .Local
                          .FirstOrDefault(entry => entry.Id.Equals(usuario.Id));

            if (local != null)
                _dbContext.Entry(local).State = EntityState.Detached;

            _dbContext.Usuarios.Attach(usuario);
            _dbContext.Entry(usuario).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Excluir(int usuarioId)
        {
            var usuario = await ExisteUsuario(usuarioId);
            if (usuario == null)
                return false;

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Usuario>> Listar(int usuarioId)
        {
            return await _dbContext.Usuarios.Include(u => u.Postagens).ToListAsync();
        }

        private async Task<Usuario?> ExisteUsuario(int usuarioId)
            => await _dbContext.Usuarios
                               .Include(u => u.Postagens)
                               .FirstOrDefaultAsync(u => u.Id == usuarioId);
    }
}
