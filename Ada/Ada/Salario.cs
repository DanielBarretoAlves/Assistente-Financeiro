using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class Salario : Produto
    {
        //Contrutor
        public Salario(float valor, int tipo, string nome) : base(valor, tipo, nome)
        {
            // int escolha = 0;
            // Console.WriteLine("Qual tipo de carteira? \n 1 - Carteira Pessoal \n 2 - Carteira Profissional");
            // escolha = int.Parse(Console.ReadLine());
            // if(escolha == 1) { } else if(escolha == 2) { } else { }
            Console.WriteLine("Calcular hora extra? \n 1 - sim \n 2 - não");
            int escolha = int.Parse(Console.ReadLine());
            if (escolha == 1) {
                Console.WriteLine("Quanto o valor a hora?");
                float valorHora = float.Parse(Console.ReadLine());
                Console.WriteLine("Quantas horas?");
                float numeroHoras = float.Parse(Console.ReadLine());
                addHoraExtra(valorHora, numeroHoras);
            }
            Console.WriteLine("Calcular comissão? \n 1 - sim \n 2 - não");
            escolha = int.Parse(Console.ReadLine());
            if (escolha == 1)
            {
                Console.WriteLine("Qual a porcentagem da comissão de 0 a 1? \n ex:0.5 que é igual a 50%");
                float porcento = float.Parse(Console.ReadLine());
                Console.WriteLine("Qual o valor total em que a comissão será aplicada?");
                float valorEmCima = float.Parse(Console.ReadLine());
                calcComissao(porcento, valorEmCima);
            }

        }

        //Metodos

        public override void calcJuros()
        {
            //TODO: Code..
        }

        public void addHoraExtra(float valHora, float numHoras)
        {     
                float total = valHora * numHoras;
                Valor += total; 
        }
         public void calcComissao(float porcentagem, float valorTotal)
        {
                float total = valorTotal * porcentagem;
                Valor += total; 
        }
    }
}
