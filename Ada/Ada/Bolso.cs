using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    interface Bolso
    {

        public void addRenda();

        public void addGasto();

        public void addSalario();

        public void escreverGasto();

        public void lerGasto();

        public void escreverRenda();

        public void lerRenda();

        public void expandirGasto();

        public void expandirRenda();

        public bool IsFull(Object[] dado);

    }
}
