using System.Collections.Generic;
using System.Diagnostics;

namespace Desafio01.Models
{
    public class Pessoa
    {
        private static readonly Pessoa[] _pessoas = new Pessoa[5];
        public static Pessoa[] Pessoas = _pessoas;
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public decimal Salario { get; set; }
        public string Profissao { get; set; }
        public Pessoa(string nome, string sobrenome, int idade, decimal salario, string profissao)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Idade = idade;
            this.Salario = salario;
            this.Profissao = profissao;
        }
        public static void AdicionarPessoa(Pessoa pessoa)
        {
            for (int i = 0; i < _pessoas.Length; i++)
            {
                if (_pessoas[i] == null)
                {
                    _pessoas[i] = pessoa;
                    break;
                }
            }
        }
        public static void AdicionarPessoa(Pessoa[] array, Pessoa pessoa)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    array[i] = pessoa;
                    break;
                }
            }
        }
        public static Pessoa[] ListarPessoas()
        {
            foreach (var pessoa in Pessoas)
            {
                if (pessoa != null)
                {
                    Debug.WriteLine($"Nome: {pessoa.Nome}");
                    Debug.WriteLine($"Sobrenome: {pessoa.Sobrenome}");
                    Debug.WriteLine($"Idade: {pessoa.Idade}");
                    Debug.WriteLine($"Salário: {pessoa.Salario}");
                    Debug.WriteLine($"Profissão: {pessoa.Profissao}");
                }
            }
            return Pessoas;
        }
        public static decimal CalcularMediaSalarial()
        {
            decimal mediaSalarial = 0;
            foreach (var pessoa in Pessoas)
            {
                if (pessoa != null)
                {
                    mediaSalarial += pessoa.Salario;
                }
            }
            mediaSalarial = mediaSalarial / Pessoas.Length;
            Debug.WriteLine($"Média salarial: {mediaSalarial}");
            return mediaSalarial;
        }
        
        public static Pessoa[] ImprimirPessoasComMaiorSalarioMaiorQueAMedia()
        {
            decimal mediaSalarial = CalcularMediaSalarial();
            Pessoa[] pessoasComMaiorSalario = new Pessoa[5];
            foreach (var pessoa in Pessoas)
            {
                if (pessoa != null)
                {
                    if (pessoa.Salario > mediaSalarial)
                    {
                        Debug.WriteLine($"Nome: {pessoa.Nome}");
                        Debug.WriteLine($"Sobrenome: {pessoa.Sobrenome}");
                        Debug.WriteLine($"Idade: {pessoa.Idade}");
                        Debug.WriteLine($"Salário: {pessoa.Salario}");
                        Debug.WriteLine($"Profissão: {pessoa.Profissao}");
                        AdicionarPessoa(pessoasComMaiorSalario, pessoa);
                    }
                }
            }
            return pessoasComMaiorSalario;
        }

        public static Pessoa ImprimirPessoaComMaiorSalario()
        {
            Pessoa pessoaComMaiorSalario = null;
            foreach(var pessoa in Pessoas)
            {
                if (pessoa != null)
                {
                    if (pessoaComMaiorSalario == null)
                    {
                        pessoaComMaiorSalario = pessoa;
                    }
                    else if (pessoa.Salario > pessoaComMaiorSalario.Salario)
                    {
                        pessoaComMaiorSalario = pessoa;
                    }
                }
            }
            return pessoaComMaiorSalario;
        }
    }
}
