using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ada
{
    public class Salario : Produto
    {
        public Salario(int valor, int tipo) : base(valor, tipo)
        {
        }

        public void adicionarHoraExtra(float valHora, int numHoras, Object cart) {

           
            CarteiraPessoal carteira1 = new CarteiraPessoal();
            CarteiraProfissional carteira2 = new CarteiraProfissional();

            if (cart == carteira1)
            {
                float horaExtra = valHora * numHoras;
                carteira1.Budget = carteira1.Budget + horaExtra;
            } else {
                float horaExtra = valHora * numHoras;
                carteira2.Budget = carteira2.Budget + horaExtra;

            }
            
        }

        public void calcComissão() { }
    }
}
