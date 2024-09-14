using Microsoft.AspNetCore.Mvc;
using BlogFlow.Application.Dtos;
using BlogFlow.Application.Interfaces;

namespace BlogFlow.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemService _postagemService;

        public PostagemController(IPostagemService postagemService)
        {
            _postagemService = postagemService;
        }

        /// <summary>
        /// Método para cadastrar uma nova postagem
        /// </summary>
        /// <param name="postagemDto"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(PostagemDto postagemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var postagemCadastrada = await _postagemService.Cadastrar(postagemDto);
                return Ok(postagemCadastrada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro ao cadastrar postagem: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para visualizar os detalhes de uma postagem
        /// </summary>
        /// <param name="postagemId"></param>
        /// <returns></returns>
        [HttpGet("Visualizar/{postagemId}")]
        public async Task<IActionResult> Visualizar(int postagemId)
        {
            try
            {
                var postagem = await _postagemService.Visualizar(postagemId);
                return Ok(postagem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro ao visualizar postagem: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para editar uma postagem existente
        /// </summary>
        /// <param name="postagemDto"></param>
        /// <returns></returns>
        [HttpPut("Editar")]
        public async Task<IActionResult> Editar(PostagemDto postagemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var postagemFoiAtualizada = await _postagemService.Editar(postagemDto);
                if (postagemFoiAtualizada)
                    return Ok(new { mensagem = "Postagem atualizada com sucesso." });

                return BadRequest(new { mensagem = "Erro ao atualizar postagem." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro inesperado ao editar postagem: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para excluir uma postagem pelo ID
        /// </summary>
        /// <param name="postagemId"></param>
        /// <returns></returns>
        [HttpDelete("Excluir/{postagemId}")]
        public async Task<IActionResult> Excluir(int postagemId)
        {
            try
            {
                var postagemExcluida = await _postagemService.Excluir(postagemId);
                if (postagemExcluida)
                    return Ok(postagemExcluida);

                return NotFound(new { mensagem = $"Postagem com Id:{postagemId} não encontrada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro inesperado ao excluir postagem: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para listar todas as postagens
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var postagens = await _postagemService.Listar();
                return Ok(postagens);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro ao listar postagens: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para listar todas as postagens de um usuário
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet("ListarPostagensUsuario/{usuarioId}")]
        public async Task<IActionResult> ListarPostagensUsuario(int usuarioId)
        {
            try
            {
                var postagens = await _postagemService.ListarPostagensUsuario(usuarioId);
                return Ok(postagens);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro ao listar postagens do usuário: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }
    }
}
