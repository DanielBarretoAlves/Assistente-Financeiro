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
        
        //TODO: Escrever em um arquivo todas as informações necessarias para instanciar o construtor da classe GASTO
        public bool escreverGasto();

        public bool lerGasto();

        //TODO: Escrever em um arquivo as informações necessarias para instanciar o construtor da classe RENDA
        public bool escreverRenda();

        public bool lerRenda();

        //TODO: Escrever em um arquivo as informações necessarias para instanciar o construtor da classe RENDA
        public bool escreverSalario();

        public bool lerSalario();

        public void expandirGasto();

        public void expandirRenda();

        public void expandirSalario();

        public bool IsFull(Object[] dado);

        

    }
}
