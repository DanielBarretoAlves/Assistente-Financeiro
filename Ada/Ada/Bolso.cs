using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    interface Bolso
    {

        public bool addRenda(Renda r);

        public bool addGasto(Gasto g);

        public bool addSalario(Salario s);

        public void escreverGasto();

        public void lerGasto();

        public void escreverRenda();

        public void lerRenda();

        public void expandirGasto();

        public void expandirRenda();

        public bool IsFull(Object[] dado);

    }
}
