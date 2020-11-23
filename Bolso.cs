using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    interface Bolso
    {
        //TODO: Um metodo interno que gera o RENDA e retorna um objeto RENDA, OBS: O metodo deve ser entrado como parametro
        public bool addRenda();
        //TODO: Um metodo interno que gera o GASTO e retorna um objeto GASTO, OBS: O metodo deve ser entrado como parametro
        public bool addGasto();

        //TODO: Um metodo interno que gera o SALARIO e retorna um objeto SALARIO, OBS: O metodo deve ser entrado como parametro
        public bool addSalario();
        
        //TODO: Escrever em um arquivo todas as informações necessarias para instanciar o construtor da classe GASTO
        public bool escreverAgenda();

        public bool lerAgenda();

        //TODO: Escrever em um arquivo as informações necessarias para instanciar o construtor da classe RENDA
        public void checkAgenda();

        public bool IsFull(Object[] dado);

        public void limparAgenda();

        

    }
}
