using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class Gasto : Produto
    {
        private string categoria;
        private int importancia;
        private int mes;


        public Gasto(string categoria, int importancia, int mes, int valor, int tipo, string nome)
            : base(valor, tipo, nome)
        {
            this.categoria = categoria;
            this.importancia = importancia;
            this.mes = mes;

        }

        //Construtor
    }
}
//Vai ter que ler um txt das informações