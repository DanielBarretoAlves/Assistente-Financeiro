using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class CarteiraProfissional : Bolso
    {
        private float budget;
        private Gasto[] gastos;
        private Renda[] rendas;
        private Salario[] salarios;
        private string nome;
        private static int tipo = 0;
        //Atributos
        public void addGasto()
        {
            throw new NotImplementedException();
        }

        public void addRenda()
        {
            throw new NotImplementedException();
        }

        public void addSalario()
        {
            throw new NotImplementedException();
        }

        public void escreverGasto()
        {
            throw new NotImplementedException();
        }

        public void escreverRenda()
        {
            throw new NotImplementedException();
        }

        public void expandir(object[] dado)
        {
            throw new NotImplementedException();
        }

        public void expandirGasto()
        {
            throw new NotImplementedException();
        }

        public void expandirRenda()
        {
            throw new NotImplementedException();
        }

        public bool IsFull(object[] dado)
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
            if (dado.Length == size)
            {
                return true;
            }
            return false;
        }

        public void lerGasto()
        {
            throw new NotImplementedException();
        }

        public void lerRenda()
        {
            throw new NotImplementedException();
        }
    }
}
