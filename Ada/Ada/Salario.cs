using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class Salario : Produto
    {
        //Contrutor
        public Salario(int valor, int tipo, string nome) : base(valor, tipo, nome)
        {
        }

        //Metodos

        public override void calcJuros()
        {
            //TODO: Code..
        }

        public void addHoraExtra(float valHora, float numHoras)
        {
            //TODO: Code..
        }
        public void calcComissao()
        {
            //TODO: Code..
        }
    }
}
