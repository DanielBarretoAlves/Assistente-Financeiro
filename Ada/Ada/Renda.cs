using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class Renda : Produto
    {

        float incremental;

        public Renda(float incremental, int valor, int tipo) : base(int valor, int tipo)
        {
            this.incremental = incremental;
        }
    }
}
