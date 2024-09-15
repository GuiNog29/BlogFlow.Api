using AutoMapper;
using BlogFlow.Domain.Entities;
using BlogFlow.Application.Dtos;
using BlogFlow.Domain.Interfaces;
using BlogFlow.Application.Interfaces;

namespace BlogFlow.Application.Services
{
    public class PostagemService : IPostagemService
    {
        private readonly IMapper _mapper;
        private readonly IPostagemRepository _postagemRepository;
        public PostagemService(IMapper mapper, IPostagemRepository postagemRepository)
        {
            _mapper = mapper;
            _postagemRepository = postagemRepository;
        }

        public async Task<PostagemDto> Cadastrar(PostagemDto postagemDto)
        {
            var postagem = await _postagemRepository.Cadastrar(_mapper.Map<Postagem>(postagemDto));
            if (postagem == null)
                throw new PostagemServiceException("Ocorreu um erro ao criar uma nova postagem.");

            return _mapper.Map<PostagemDto>(postagem);
        }

        public async Task<PostagemDto?> Visualizar(int postagemId)
        {
            var postagem = await _postagemRepository.Visualizar(postagemId);
            if (postagem == null)
                throw new PostagemNaoEcontradaException(postagemId);

            return _mapper.Map<PostagemDto>(postagem);
        }

        public async Task<bool> Editar(PostagemDto postagemDto)
        {
            var postagem = _mapper.Map<Postagem>(postagemDto);
            var postagemFoiAtualizada = await _postagemRepository.Editar(postagem);
            if (!postagemFoiAtualizada)
                throw new PostagemServiceException($"Ocorreu um erro ao atualizar postagem com Id:{postagem.Id}.");

            return postagemFoiAtualizada;
        }

        public async Task<bool> Excluir(int postagemId)
        {
            await Visualizar(postagemId);
            return await _postagemRepository.Excluir(postagemId);
        }

        public async Task<IEnumerable<PostagemDto>> Listar()
        {
            return _mapper.Map<IEnumerable<PostagemDto>>(await _postagemRepository.Listar());
        }

        public async Task<IEnumerable<PostagemDto>> ListarPostagensUsuario(int usuarioId)
        {
            return _mapper.Map<IEnumerable<PostagemDto>>(await _postagemRepository.ListarPostagensUsuario(usuarioId));
        }
    }

    public class PostagemNaoEcontradaException : Exception
    {
        public PostagemNaoEcontradaException(int postagemId)
            : base($"Não foi localizado a postagem com Id:{postagemId}.") { }
    }

    public class PostagemServiceException : Exception
    {
        public PostagemServiceException(string message)
            : base(message) { }
    }
}
