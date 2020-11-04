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
        private Salario[] salarios;
        private string nome;
        private static int tipo = 1;

        public CarteiraPessoal
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
        //AQUI
        //public void expandirGasto()
        //{
        //    Gasto[] reserva = new Gasto[this.gastos.Length * 2];
        //    if(IsFull(gastos))
        //    {
        //        for(int i = 0; i < gastos.Length; i++)
        //        {
        //            reserva[i] = gastos[i];
        //        }
        //        gastos = reserva;
        //    }
            
        //}

        

        public bool  IsFull(Object[] dado)
        {
            int size = 0;
            //Somando a quantidade de casas do array oculpadas
            for (int i = 0; i < dado.Length; i++)
            {
                if (dado[i] != null)
                {
                    size++;
                }
            }
            if(dado.Length == size)
            {
                return true;
            }
            return false;
        }

        public void expandir(object[] dado)
        {
            Object[] reserva = new Object[dado.Length * 2];
            if (IsFull(dado))
            {
                for (int i = 0; i < dado.Length; i++)
                {
                    reserva[i] = dado[i];
                }
                dado = reserva;
            }
        }
    }
}
