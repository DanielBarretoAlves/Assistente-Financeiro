using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    public abstract class Bolso
    {
        private int valor;
        private int tipo;


        public virtual void calcJuros() { }
    }
}
