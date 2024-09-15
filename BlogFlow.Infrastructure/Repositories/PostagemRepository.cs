using BlogFlow.Domain.Entities;
using BlogFlow.Domain.Interfaces;
using BlogFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogFlow.Infrastructure.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly AppDbContext _dbContext;
        public PostagemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Postagem> Cadastrar(Postagem postagem)
        {
            await _dbContext.Postagens.AddAsync(postagem);
            await _dbContext.SaveChangesAsync();
            return postagem;
        }

        public async Task<Postagem?> Visualizar(int postagemId)
        {
            return await ExistePostagem(postagemId);
        }

        public async Task<bool> Editar(Postagem postagem)
        {
            if (await ExistePostagem(postagem.Id) == null)
                return false;

            var local = _dbContext.Set<Usuario>()
                          .Local
                          .FirstOrDefault(entry => entry.Id.Equals(postagem.Id));

            if (local != null)
                _dbContext.Entry(local).State = EntityState.Detached;

            _dbContext.Postagens.Attach(postagem);
            _dbContext.Entry(postagem).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Excluir(int postagemId)
        {
            var usuario = await ExistePostagem(postagemId);
            if (usuario == null)
                return false;

            _dbContext.Postagens.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Postagem>?> Listar()
        {
            return await _dbContext.Postagens.Include(p => p.Usuario).ToListAsync();
        }

        public async Task<IEnumerable<Postagem>?> ListarPostagensUsuario(int usuarioId)
        {
            return await _dbContext.Postagens.Include(p => p.Usuario).Where(p => p.UsuarioId == usuarioId).ToListAsync();
        }

        private async Task<Postagem?> ExistePostagem(int postagemId)
            => await _dbContext.Postagens
                               .Include(p => p.Usuario)
                               .FirstOrDefaultAsync(p => p.Id == postagemId);
    }
}
