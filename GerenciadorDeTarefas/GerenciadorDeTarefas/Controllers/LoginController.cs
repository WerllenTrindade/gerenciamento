using GerenciadorDeTarefas.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        //gerar log
        private readonly ILogger<LoginController> _logger;

        //Instancia o construtor - LoginController
        //LoginController recebe um - (Ilogger)
        //Do tipo <LoginController>
        // com a varivel logger
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto requisicao)
        {
            try
            {
                if(requisicao == null || requisicao.Login == null || requisicao.Senha == null)
                {
                    return BadRequest(new ErroRespostaDto() { 
                    Status = StatusCodes.Status400BadRequest,
                    Erro = "Parametros de entrada inválidos"
                    });
                    // quando usuario mandou algo errado
                };

                return Ok("Usuario autentica com sucesso!");

            }
            catch (Exception excecao)
            {
                _logger.LogError($"Ocorreu o erro ao efetuar Login: {excecao.Message}" + excecao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu erro ao efetuar login"
                });
            }
        }
    }
}
