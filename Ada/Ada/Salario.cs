﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class Salario : Produto
    {
        //Contrutor
        public Salario(float valor, int tipo, string nome) : base(valor, tipo, nome)
        {
        }

        //Metodos

        public override void calcJuros()
        {
            //TODO: Code..
        }

        public void addHoraExtra(float valHora, float numHoras, Object carteira)
        {
            //CarteiraPessoal carteirapessoal = new CarteiraPessoal();
            //CarteiraProfissional carteiraprofissional = new CarteiraProfissional();
            
            //if(carteira == carteirapessoal){
            //    float total = valHora * numHoras;
            //    Valor += total; 
            //}else if (carteira == carteiraprofissional){
            //    float total = valHora * numHoras;
            //    Valor += total; 
            //}

        }
         public void calcComissao(float porcentagem, float valorTotal, Object carteira)
        {
            //CarteiraPessoal carteirapessoal = new CarteiraPessoal();
            //CarteiraProfissional carteiraprofissional = new CarteiraProfissional()
            
            //if(carteira == carteirapessoal){
            //    float total = valorTotal * porcentagem;
            //    Valor += total; 
            //}else if (carteira == carteiraprofissional){
            //    float total = valorTotal * porcentagem;
            //    Valor += total; 
            //}
        }
    }
}
