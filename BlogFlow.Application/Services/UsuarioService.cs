using AutoMapper;
using BlogFlow.Domain.Entities;
using BlogFlow.Application.Dtos;
using BlogFlow.Domain.Interfaces;
using BlogFlow.Application.Interfaces;

namespace BlogFlow.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> Cadastrar(UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.Cadastrar(_mapper.Map<Usuario>(usuarioDto));
            if (usuario == null)
                throw new UsuarioServiceException("Ocorreu um erro ao criar uma novo usuário.");

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto?> Visualizar(int usuarioId)
        {
            var usuario = await _usuarioRepository.Visualizar(usuarioId);
            if (usuario == null)
                throw new UsuarioNaoEcontradoException(usuarioId);

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<bool> Editar(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var usuarioFoiAtualizado = await _usuarioRepository.Editar(usuario);
            if (!usuarioFoiAtualizado)
                throw new UsuarioServiceException($"Ocorreu um erro ao atualizar usuário com Id:{usuario.Id}.");

            return usuarioFoiAtualizado;
        }

        public async Task<bool> Excluir(int usuarioId)
        {
            await Visualizar(usuarioId);
            return await _usuarioRepository.Excluir(usuarioId);
        }

        public async Task<IEnumerable<UsuarioDto>> Listar()
        {
            return _mapper.Map<IEnumerable<UsuarioDto>>(await _usuarioRepository.Listar());
        }
    }

    public class UsuarioNaoEcontradoException : Exception
    {
        public UsuarioNaoEcontradoException(int postagemId)
            : base($"Não foi localizado a usuário com Id:{postagemId}.") { }
    }

    public class UsuarioServiceException : Exception
    {
        public UsuarioServiceException(string message)
            : base(message) { }
    }
}
