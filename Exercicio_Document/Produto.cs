using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_Document
{
    internal class Produto
    {
        public string Nome { get; set; }
        public int Qtd { get; set; }
        public double Valor { get; set; }

        public Produto()
        {
        }

        public Produto(string nome, double valor, int qtd)
        {
            Nome = nome;
            Valor = valor;
            Qtd = qtd;  
        }


        public double Totalizar()
        {
            return Valor * Qtd;
        }
    }
}
