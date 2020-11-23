using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ada
{
    // TODO: Add Mes -- em renda e sal
    public class Controller
    {
        private CarteiraPessoal[] cp;


        private String[] nomesCarteiras;


        public Controller()
        {
            nomesCarteiras = new string[50];
            cp = new CarteiraPessoal[20];


        }

        // Getts e Setters
        public string[] NomesCarteiras { get => nomesCarteiras; set => nomesCarteiras = value; }
        internal CarteiraPessoal[] Cp { get => cp; set => cp = value; }


        

    }
}
