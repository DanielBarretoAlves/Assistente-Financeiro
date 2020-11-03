using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class CarteiraPessoal:Bolso
    {
        private float budget;
        private Gasto[] gastos;
        private Renda[] rendas;
        



        public void addRenda()
        {
            throw new NotImplementedException();
        }

        public void addGasto()
        {
            throw new NotImplementedException();
        }

        public void escreverGasto()
        {
            throw new NotImplementedException();
        }

        public void lerGasto()
        {
            throw new NotImplementedException();
        }

        public void escreverRenda()
        {
            throw new NotImplementedException();
        }

        public void lerRenda()
        {
            throw new NotImplementedException();
        }

        public void expandirGasto()
        {
            if(gastos[0] == null)
            {
                Console.WriteLine("É Vazio");
            }
        }

        public void expandirRenda()
        {
            throw new NotImplementedException();
        }
    }
}
