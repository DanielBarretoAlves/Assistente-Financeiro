using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    public class Gasto : Produto
    {
        private string categoria;
        private int importancia;
        private int incremental;

        public Gasto(string categoria, int importancia, int incremental, int valor, int tipo) : base(valor, tipo)
        {
            this.categoria = categoria;
            this.importancia = importancia;
            this.incremental = incremental;
        }
    }
}
