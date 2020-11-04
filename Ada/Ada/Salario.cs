using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ada
{
    public class Salario : Produto
    {

        public object adicionarHoraExtra(float valHora, int numHoras) {

            CarteiraPessoal carteira = new CarteiraPessoal();

            float horaExtra = valHora * numHoras;
            carteira.Budget = carteira.Budget + horaExtra;
            return carteira;
        }

        public void calcComissão() { }
    }
}
