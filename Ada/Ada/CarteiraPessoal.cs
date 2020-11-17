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
        private Salario[] salarios;
        private Gasto[] gastos;
        private Renda[] rendas;

        
        //Construtor
        public CarteiraPessoal(string nomeCarteira, float buget, Salario[] salarios, Gasto[] gastos, Renda[] rendas)
        {
            this.nomeCarteira = nomeCarteira;
            this.buget = buget;
            this.salarios = salarios;
            this.gastos = gastos;
            this.rendas = rendas;
        }

        //GETTS & SETTERS
        public string NomeCarteira { get => nomeCarteira; set => nomeCarteira = value; }
        public float Buget { get => buget; set => buget = value; }
        public static int Tipo { get => tipo; set => tipo = value; }
        internal Salario[] Salarios { get => salarios; set => salarios = value; }
        internal Gasto[] Gastos { get => gastos; set => gastos = value; }
        internal Renda[] Rendas { get => rendas; set => rendas = value; }

        public bool addRenda(Renda r)
        {
            if (IsFull(rendas))
            {
                //TODO: Implementar ExpandirRenda();
                expandirRenda();


            }
            //TODO: Expandir Salarios

            for (int i = 0; i < rendas.Length; i++)
            {
                if (rendas[i] == null)
                {
                    rendas[i] = r;
                    return true;
                }
            }
            return false;
        }

        public bool addGasto(Gasto g)
        {
            if (IsFull(gastos))
            {
                expandirGasto();


            }
            //TODO: Expandir Salarios

            for (int i = 0; i < gastos.Length; i++)
            {
                if (gastos[i] == null)
                {
                    gastos[i] = g;
                    return true;
                }
            }
            return false;
        }

        public bool addSalario(Salario s)
        {
            if (IsFull(salarios))
            {
                //TODO: Implementar ExpandirRenda();
                expandirSalario();


            }
            //TODO: Expandir Salarios

            for (int i = 0; i < salarios.Length; i++)
            {
                if (salarios[i] == null)
                {
                    salarios[i] = s;
                    return true;
                }
            }
            return false;
        }

        public bool escreverGasto()
        {
            var json_serializado = JsonConvert.SerializeObject(gastos);
            File.WriteAllText(@"Arquivos/" + "gastos"+nomeCarteira + ".json", json_serializado);
            return (File.Exists(@"Arquivos/" + "gastos"+nomeCarteira + ".json"));
        }

        public bool lerGasto()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/" + "gastos"+nomeCarteira + ".json"))
            {
                st += sr.ReadToEnd();

            }
            Gasto[] newGastos = JsonConvert.DeserializeObject<Gasto[]>(st);
            Console.WriteLine(newGastos[0].Nome);
            return true;
        }

        public bool escreverRenda()
        {
            var json_serializado = JsonConvert.SerializeObject(rendas);
            File.WriteAllText(@"Arquivos/" + "rendas"+nomeCarteira + ".json", json_serializado);
            return (File.Exists(@"Arquivos/" + "rendas"+nomeCarteira + ".json"));
        }

        public bool lerRenda()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/" + "rendas"+nomeCarteira + ".json"))
            {
                st += sr.ReadToEnd();

            }
            Renda[] newRendas = JsonConvert.DeserializeObject<Renda[]>(st);
            Console.WriteLine(newRendas[0].Nome);
            return true;
        }

        public bool escreverSalario()
        {
            var json_serializado = JsonConvert.SerializeObject(salarios);
            File.WriteAllText(@"Arquivos/" + "salarios"+nomeCarteira + ".json", json_serializado);
            return (File.Exists(@"Arquivos/" + "salarios"+nomeCarteira + ".json"));
        }

        public bool lerSalario()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/" + "salarios"+nomeCarteira + ".json"))
            {
                st += sr.ReadToEnd();

            }
            Salario[] newSalarios = JsonConvert.DeserializeObject<Salario[]>(st);
            Console.WriteLine(newSalarios[0].Nome);
            return true;
        }

        public void expandirGasto()
        {
            throw new NotImplementedException();
        }

        public void expandirRenda()
        {
            throw new NotImplementedException();
        }

        public void expandirSalario(){

        }
        
        
        public bool IsFull(object[] dado)
        {
            int size = 0;
            //Somando a quantidade de casas do array oculpadas
            for (int i = 0; i < dado.Length; i++)
            {
                if (dado[i] != null)
                {
                    size++;
                }
            }
            if(dado.Length == size)
            {
                return true;
            }
            return false;
        }
    }
}
