using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    public abstract class Produto
    {

        int valor;
        int tipo;

        public virtual void calcJuros() { }
    }
}
