using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ada
{
    class CarteiraPessoal : Bolso
    {
        private string nomeCarteira;
        private float buget;
        private static int tipo = 1;
        private Salario[] sarios;
        private Gasto[] gastos;
        private Renda[] rendas;

        
        //Construtor
        public CarteiraPessoal(string nomeCarteira, float buget, Salario[] sarios, Gasto[] gastos, Renda[] rendas)
        {
            this.nomeCarteira = nomeCarteira;
            this.buget = buget;
            this.sarios = sarios;
            this.gastos = gastos;
            this.rendas = rendas;
        }

        //GETTS & SETTERS
        public string NomeCarteira { get => nomeCarteira; set => nomeCarteira = value; }
        public float Buget { get => buget; set => buget = value; }
        public static int Tipo { get => tipo; set => tipo = value; }
        internal Salario[] Sarios { get => sarios; set => sarios = value; }
        internal Gasto[] Gastos { get => gastos; set => gastos = value; }
        internal Renda[] Rendas { get => rendas; set => rendas = value; }

        public bool addRenda(Renda r)
        {
            throw new NotImplementedException();
        }

        public bool addGasto(Gasto g)
        {
            throw new NotImplementedException();
        }

        public bool addSalario(Salario s)
        {
            throw new NotImplementedException();
        }

        public bool escreverGasto()
        {
            Gasto g = new Gasto("teste", 2, 7, 200, 1, "PSP");
            var json_serializado = JsonConvert.SerializeObject(g);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\danie\Source\Repos\DanielBarretoAlves\Assistente-Financeiro\Ada\Ada\planilhaGastos.json", true))
            {
                file.WriteLine(json_serializado);
            }
            return true;
            
            //TODO: Criar Arquivo
        }

        public bool lerGasto()
        {
            throw new NotImplementedException();
        }

        public bool escreverRenda()
        {
            throw new NotImplementedException();
        }

        public bool lerRenda()
        {
            throw new NotImplementedException();
        }

        public bool escreverSalario()
        {
            throw new NotImplementedException();
        }

        public bool lerSalario()
        {
            throw new NotImplementedException();
        }

        public void expandirGasto()
        {
            throw new NotImplementedException();
        }

        public void expandirRenda()
        {
            throw new NotImplementedException();
        }

        public bool IsFull(object[] dado)
        {
            throw new NotImplementedException();
        }
    }
}
