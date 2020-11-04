using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    public abstract class Produto
    {

        private int valor;
        private int tipo;

        public virtual void calcJuros() { }

        protected Produto(int valor, int tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
        }


    }


}
