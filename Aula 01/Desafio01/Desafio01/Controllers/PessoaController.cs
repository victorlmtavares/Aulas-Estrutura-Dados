using Desafio01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {      

        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger)
        {
            Pessoa pessoa1 = new Pessoa("Arthur", "Vieira", 25, 4000.23m, "Técnico em redes");
            Pessoa.AdicionarPessoa(pessoa1);
            Pessoa pessoa2 = new Pessoa("João", "Silva", 30, 6028.00m, "Técnico em informática");
            Pessoa.AdicionarPessoa(pessoa2);
            Pessoa pessoa3 = new Pessoa("Maria", "Santos", 35, 5500.00m, "Desenvolvedor Júnior");
            Pessoa.AdicionarPessoa(pessoa3);
            Pessoa pessoa4 = new Pessoa("Pedro", "Álvares", 40, 15000.00m, "Capitão de fragata");
            Pessoa.AdicionarPessoa(pessoa4);
            Pessoa pessoa5 = new Pessoa("José", "Fernandes", 29, 8000.00m, "Pastor de ovelhas");
            Pessoa.AdicionarPessoa(pessoa5);
            _logger = logger;
        }

        [HttpGet("listarPessoas")]
        public IEnumerable<Pessoa> Get()
        {
            return Pessoa.ListarPessoas();
        }
        
        [HttpGet("listarPessoasAcimaDaMedia")]
        public IEnumerable<Pessoa> GetMediaSalarial()
        {
            return Pessoa.ImprimirPessoasComMaiorSalarioMaiorQueAMedia();
        }

        [HttpGet("pessoaComMaiorSalario")]
        public Pessoa GetPessoaComSalarioMaior()
        {
            return Pessoa.ImprimirPessoaComMaiorSalario();
        }
    }
}
