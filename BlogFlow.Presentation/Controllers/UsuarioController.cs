using Microsoft.AspNetCore.Mvc;
using BlogFlow.Application.Dtos;
using BlogFlow.Application.Interfaces;

namespace BlogFlow.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Método para cadastrar um novo usuário
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioCadastrado = await _usuarioService.Cadastrar(usuarioDto);
                return Ok(usuarioCadastrado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro ao cadastrar usuário: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para visualizar dados do usuário
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet("Visualizar/{usuarioId}")]
        public async Task<IActionResult> Visualizar(int usuarioId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = await _usuarioService.Visualizar(usuarioId);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(new ErroDto
                {
                    Mensagem = $"Erro ao visualizar usuário: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para editar e atualizar usuário
        /// </summary>
        /// <param name="usuarioDto"></param>
        /// <returns></returns>
        [HttpPut("Editar")]
        public async Task<IActionResult> Editar(UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioFoiAtualizado = await _usuarioService.Editar(usuarioDto);
                if (usuarioFoiAtualizado)
                    return Ok(usuarioFoiAtualizado);

                return BadRequest(new { mensagem = "Erro ao atualizar usuário." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro ao editar usuário: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para excluir usuário a partir do seu id
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpDelete("Excluir/{usuarioId}")]
        public async Task<IActionResult> Excluir(int usuarioId)
        {
            try
            {
                var usuarioExcluido = await _usuarioService.Excluir(usuarioId);
                if (usuarioExcluido)
                    return Ok(new { mensagem = "Usuário excluído com sucesso." });

                return NotFound(new { mensagem = $"Usuário com Id:{usuarioId} não encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro ao excluir usuário: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        /// <summary>
        /// Método para listar todos os usuários do blog
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var usuarios = await _usuarioService.Listar();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Erro ao listar usuários: {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }
    }
}
