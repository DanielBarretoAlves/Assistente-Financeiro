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

        //Construtor
        public Gasto(string categoria, int importancia, int mes, float valor, int tipo, string nome)
            : base(valor, tipo, nome)
        {
            this.categoria = categoria;
            this.importancia = importancia;
            this.mes = mes;

        }

        //Getts E Setters
        public string Categoria { get => categoria; set => categoria = value; }
        public int Importancia { get => importancia; set => importancia = value; }
        public int Mes { get => mes; set => mes = value; }

        
    }
}
//Vai ter que ler um txt das informações
