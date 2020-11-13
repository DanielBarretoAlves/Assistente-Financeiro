using System;

namespace Ada
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Salario[] s = new Salario[2];
            Gasto[] g = new Gasto[5];
            Renda[] r = new Renda[3];
            CarteiraPessoal c = new CarteiraPessoal("Daniel", 3500, s, g, r);
            Console.WriteLine(c.escreverGasto());
        }
    }
}
