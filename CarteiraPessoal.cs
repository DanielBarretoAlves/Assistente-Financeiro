﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Ada
{
    public class CarteiraPessoal : Bolso
    {
        private string nomeCarteira;
        private float buget;
        private Mes[] agenda = new Mes[12];


        //Construtor
        public CarteiraPessoal(string nomeCarteira, float buget)
        {
            this.nomeCarteira = nomeCarteira;
            this.buget = buget;
            checkAgenda();


        }

        //GETTS & SETTERS
        public string NomeCarteira { get => nomeCarteira; set => nomeCarteira = value; }
        public float Buget { get => buget; set => buget = value; }
        public Mes[] Agenda { get => agenda; set => agenda = value; }

        public bool addGasto()
        {
            // (string categoria, int importancia, int mes, float valor, int tipo, string nome)
            

            

            

            Console.WriteLine("Faz o seguinte digita o numero de vezes q vai repetir segue o ex");
            Console.WriteLine(" 1 - Não Repete");
            Console.WriteLine(" 2 ou +  Numero de meses que vai repetir");
            int recorrente = int.Parse(Console.ReadLine());

            // TODO: Categoria
            Gasto g = new Gasto(selectCategoria(), generateImportancia(), generateMes(), generateValue(), recorrente, generateNome());
            //Recorrencia
            int goal = g.Mes + g.Tipo;
            int current = g.Mes;
            while (current < goal)
            {
                agenda[current].addGasto(g);
                current++;
            }
            escreverAgenda();
            return true;
        }

        private int generateImportancia()
        {
            Console.WriteLine("De 1 a 5 qual sendo 1 o mais baixo, qual o nivel de importancia desse gasto? ");
            int importancia = int.Parse(Console.ReadLine());
            return importancia;
        }

        private int generateMes()
        {
            Console.WriteLine("Fala o Mês ai, de 1 a 12 por favor nem vem botar texto");
            int mes = int.Parse(Console.ReadLine());
            mes--;
            return mes;
        }

        private float generateValue()
        {
            Console.WriteLine("Diga o Valor:");
            float valor = float.Parse(Console.ReadLine());
            return valor;
        }

        private string generateNome()
        {
            Console.WriteLine("de um nome");
            string nome = Console.ReadLine();
            return nome;
        }

        public bool addRenda()
        {
            Console.WriteLine("Me Fala o Titulo da Renda");
            Console.WriteLine("Algo tipo.. sei lá poem um nome ai");
            string nome = Console.ReadLine();
            Console.WriteLine("Fala o valor q tu vai ganhar");
            float valor = float.Parse(Console.ReadLine());
            Console.WriteLine("Fala o Mês ai, de 1 a 12 por favor nem vem botar texto");
            int mes = int.Parse(Console.ReadLine());
            mes--;
            Console.WriteLine("Faz o seguinte digita o numero de vezes q vai repetir segue o ex");
            Console.WriteLine(" 1 - Não Repete");
            Console.WriteLine(" 2+  Numero de meses que vai repetir");
            int repete = int.Parse(Console.ReadLine());
            Renda r = new Renda(mes, valor, repete, nome);
            int goal = r.Mes + r.Tipo;
            int current = r.Mes;
            while (current < goal)
            {
                agenda[current].addRenda(r);
                current++;
            }
            escreverAgenda();
            return true;
        }

        public bool addSalario()
        {
            // (float valor, int tipo, string nome)
            Console.WriteLine("Onde ou com o que voce trampa põe um titulo ai");
            // Salario s = new Salario()
            return true;
        }

        // Verifica se a agenda existe caso sim ele manda ler, caso não ele cria e escrever
        public void checkAgenda()
        {
            if (File.Exists(@"Arquivos/agenda" + NomeCarteira + ".json"))
            {
                lerAgenda();
            }
            else
            {
                limparAgenda();
            }
        }

        // Printa as informações da agenda em um arquivo json
        public bool escreverAgenda()
        {
            var json_serializado = JsonConvert.SerializeObject(agenda);
            File.WriteAllText(@"Arquivos/agenda" + nomeCarteira+".json", json_serializado);
            return (File.Exists(@"Arquivos/agenda" + nomeCarteira+".json"));
        }

        public bool IsFull(object[] dado)
        {
            throw new NotImplementedException();
        }

        public bool lerAgenda()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/agenda" + nomeCarteira+".json"))
            {
                st += sr.ReadToEnd();

            }
            agenda = JsonConvert.DeserializeObject<Mes[]>(st);
            return true;
        }

        // Percorre a agenda, limpa todos seu atributos e em seguida manda escrever
        public void limparAgenda()
        {
            for (var i = 0; i < agenda.Length; i++)
            {
                Mes m = new Mes(i, nomeCarteira);
                agenda[i] = m;
            }
            escreverAgenda();
        }

        private Mes[] callCategoria()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/Categorias.json"))
            {
                st += sr.ReadToEnd();

            }
            Mes[] categorias = JsonConvert.DeserializeObject<Mes[]>(st);
            return categorias;
        }


        private string selectCategoria()
        {
            Console.WriteLine("Escolha a Categoria");
            for (int i = 0; i < callCategoria().Length; i++)
            {
                Console.WriteLine(i + " - " + callCategoria()[i].Nome);
            }
            int cat = int.Parse(Console.ReadLine());
            return callCategoria()[cat].Nome;
        }






    }
}