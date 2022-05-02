using Desafio01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilhaController : ControllerBase
    {
        private static PilhaModel _pilha;
        public PilhaController()
        {

        }
        [HttpGet]
        public IActionResult CriarPilha(int tamanho)
        {
            _pilha = new PilhaModel(tamanho);
            return Ok($"Pilha criada com sucesso! Tamanho: {tamanho}");
        }
        [HttpPost("empilhar")]
        public IActionResult Empilhar(char valor)
        {
            if (_pilha == null)
            {
                return BadRequest("Pilha não criada!");
            }
            if (_pilha.EstaCheia())
            {
                return BadRequest("Pilha cheia!");
            }
            _pilha.Empilhar(valor);
            return Ok($"Valor {valor} inserido com sucesso!");
        }

        [HttpPost("desempilhar")]
        public IActionResult Desempilhar()
        {
            if (_pilha == null)
            {
                return BadRequest("Pilha não criada!");
            }
            if (_pilha.EstaVazia())
            {
                return BadRequest("Pilha vazia!");
            }
            char valor = _pilha.Desempilhar();
            return Ok($"Valor {valor} removido com sucesso!");
        }
        [HttpPost("consultar")]
        public IActionResult Consultar()
        {
            if (_pilha == null)
            {
                return BadRequest("Pilha não criada!");
            }
            if (_pilha.EstaVazia())
            {
                return BadRequest("Pilha vazia!");
            }
            char valor = _pilha.Consultar();
            return Ok($"Valor do topo: {valor}");
        }

        [HttpPost("avaliarExpressao")]
        public IActionResult AvaliarExpressao(string expressao)
        {
            if (expressao == null || expressao.Length == 0)
            {
                return BadRequest("Expressão vazia!");
            }
            PilhaModel pilha = new PilhaModel(expressao.Length);
            return Ok(pilha.AvaliarExpressao(expressao));
            
        }
    }
}
