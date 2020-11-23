using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class Produto
    {
        private float valor;
        private int tipo;
        private string nome;
  
        //Construtor
        public Produto(float valor, int tipo, string nome)
        {
            this.valor = valor;
            //TIP: TIPO = X é o numero de meses em que o valor se repete, Se Tipo for igual a 1 o produto não se repete
            this.tipo = tipo;
            this.nome = nome;
        }

        //Getters & Setters
        public float Valor { get => valor; set => valor = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public string Nome { get => nome; set => nome = value; }

        //Metodos
        public virtual void calcJuros() { }
    }
}
