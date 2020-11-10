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

        public CarteiraPessoal()
        {
            gastos = new Gasto[5];
        }

        public float Budget { get => budget; set => budget = value; }
        public Gasto[] Gastos { get => gastos; set => gastos = value; }


        public void addRenda()
        {
            throw new NotImplementedException();
        }

        public bool addGasto(Gasto g)
        {
            Gasto gt = new Gasto();

            if (IsFull(gastos) == false) {
                for (int i = 0; i < gastos.Length; i++)
                {
                    gastos[i] = g;

                }
                return true;
                } else {

                Gasto[] reserva = new Renda[this.gastos.Length * 2];
                if (IsFull(rendas))
                {
                    for (int i = 0; i < rendas.Length; i++)
                    {
                        reserva[i] = rendas[i];
                    }
                    rendas = reserva;
                }
            }
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
        public void expandirGasto()
        {
            Gasto[] reserva = new Gasto[this.gastos.Length * 2];
            if(IsFull(gastos))
            {
                for(int i = 0; i < gastos.Length; i++)
                {
                    reserva[i] = gastos[i];
                }
                gastos = reserva;
            }
            
        }

        public void expandirRenda()
        {
            Renda[] reserva = new Renda[this.gastos.Length * 2];
            if(IsFull(rendas))
            {
                for(int i = 0; i < rendas.Length; i++)
                {
                    reserva[i] = rendas[i];
                }
                rendas = reserva;
            }
        
        }

        public void expandirSalarios()
        {
            Salario[] reserva = new Salario[this.salarios.Length * 2];
            if (IsFull(rendas))
            {
                for (int i = 0; i < salarios.Length; i++)
                {
                    reserva[i] = salarios[i];
                }
                salarios = reserva;
            }

        }
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

        public bool addSalario(Salario s)
        {
            if (IsFull(salarios))
            {
                expandirSalarios();


            }
            //TODO: Expandir Salarios

            for (int i = 0; i < salarios.Length; i++)
            {
                if (salarios[i] == null)
                {
                    salarios[i] = s;
                    return true;
                }
            }
            return false;
        }

        public void addSalario()
        {
            throw new NotImplementedException();
        }
    }   
}
