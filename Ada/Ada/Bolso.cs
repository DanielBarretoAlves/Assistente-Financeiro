using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    interface Bolso
    {

        public void addRenda();
        public void addGasto();

        public void escreverGasto();
        public void lerGasto();
        public void escreverRenda();
        public void lerRenda();
        public void expandir(Object[] dado);

        public bool IsFull(Object[] dado);

    }
}
