using System;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace Ada
{
    class Program
    {
        static void Main(string[] args)
        {

            // Controller ada = new Controller();
            CarteiraPessoal p = new CarteiraPessoal("Daniel", 4600);
            p.limparAgenda();
            // p.addGasto();
            p.addRenda();         
         
            // Console.WriteLine(p.Agenda[0].Gastos[0].Nome);
        }
    }
}