using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    public class Salario : Produto
    {
        //Contrutor
        public Salario(float valor, string nome) : base(valor, nome)
        {
            

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
