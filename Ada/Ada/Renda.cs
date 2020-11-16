using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class Renda : Produto
    {
        private int mes;

        //Contrutor
        public Renda(int mes, float valor, int tipo, string nome) : base(valor, tipo, nome)
        {
            this.mes = mes;
        }

        //GET & SET
        public int Mes { get => mes; set => mes = value; }
    }
}
