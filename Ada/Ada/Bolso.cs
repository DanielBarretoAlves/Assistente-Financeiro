using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    interface Bolso
    {
        //TODO: Um metodo interno que gera o RENDA e retorna um objeto RENDA, OBS: O metodo deve ser entrado como parametro
        public bool addRenda(Renda r);
        //TODO: Um metodo interno que gera o GASTO e retorna um objeto GASTO, OBS: O metodo deve ser entrado como parametro
        public bool addGasto(Gasto g);

        //TODO: Um metodo interno que gera o SALARIO e retorna um objeto SALARIO, OBS: O metodo deve ser entrado como parametro
        public bool addSalario(Salario s);

        public bool escreverGasto();

        public bool lerGasto();

        public bool escreverRenda();

        public bool lerRenda();

        public void expandirGasto();

        public void expandirRenda();

        public bool IsFull(Object[] dado);

    }
}
