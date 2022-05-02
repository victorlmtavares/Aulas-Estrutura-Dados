namespace Desafio01.Models
{
    public class PilhaModel
    {
        private int Topo { get; set; }
        private char[] Pilha { get; set; }
        public PilhaModel(int tamanho)
        {
            Pilha = new char[tamanho];
        }
        public void Empilhar(char valor)
        {
            if (Topo < Pilha.Length)
            {
                Pilha[Topo] = valor;
                Topo++;
            }
        }
        public char Desempilhar()
        {
            if (Topo > 0)
            {
                Topo--;
                return Pilha[Topo];
            }
            throw new System.Exception("Pilha vazia!");
        }
        public char Consultar()
        {
            return Pilha[Topo - 1];
        }
        public bool EstaVazia()
        {
            return Topo == 0;
        }
        public bool EstaCheia()
        {
            return Topo == Pilha.Length;
        }

        public bool AvaliarExpressao(string expressao)
        {
            foreach (char c in expressao)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    Empilhar(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (EstaVazia())
                    {
                        return false;
                    }
                    else
                    {
                        if (c == ')' && Consultar() == '(')
                        {
                            Desempilhar();
                        }
                        else if (c == '}' && Consultar() == '{')
                        {
                            Desempilhar();
                        }
                        else if (c == ']' && Consultar() == '[')
                        {
                            Desempilhar();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return EstaVazia();
        }
    }
}
