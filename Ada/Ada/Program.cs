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
            CarteiraPessoal c = new CarteiraPessoal("Pedro", 3500, s, g, r);
            Gasto PSP = new Gasto("Jogos", 3, 3, 250, 1, "PSP");
            c.addGasto(PSP);
            Console.WriteLine(c.escreverGasto());
            Console.WriteLine(c.lerGasto());

        }
    }
}
