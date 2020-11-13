using System;

namespace Ada
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello Daniel!");
            Salario[] s = new Salario[2];
            Salario s1 = new Salario(150, 1, "SSD");
            Salario s2 = new Salario(200, 1, "PSP");
            s[0] = s1;
            // s[1] = s2;
            Gasto[] g = new Gasto[5];
            Renda[] r = new Renda[3];
            CarteiraPessoal c = new CarteiraPessoal("Daniel", 3500, s, g, r);
            Gasto psp = new Gasto("Jogos", 1, 3, 280, 1, "PSP");
            Gasto facu = new Gasto("Educação", 5, 3, 540, 1, "Faculdade");
            c.Gastos[0] = psp;
            c.Gastos[1] = facu;
            // CarteiraPessoal c1 = new CarteiraPessoal("Joao", 4300, s, g, r);
            Console.WriteLine("Salarios é cheio: " + c.IsFull(c.Sarios));
            Console.WriteLine(c.escreverGasto());
            // Console.WriteLine(c1.escreverGasto()); 
        }
        }
    }