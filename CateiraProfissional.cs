using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Ada
{
    class CarteiraProfissional : Bolso
    {
        private string nomeCarteira;
        private float budget;
        private Mes[] agenda = new Mes[12];

        //Construtor
        public CarteiraProfissional(string nomeCarteira, float buget)
        {
            this.nomeCarteira = nomeCarteira;
            this.budget = buget;
            checkAgenda();
        }
         //GETTS & SETTERS
        public string NomeCarteira { get => nomeCarteira; set => nomeCarteira = value; }
        public float Buget { get => budget; set => budget = value; }
        public Mes[] Agenda { get => agenda; set => agenda = value; }

        public bool addGasto()
        {
            //(string categoria, int importancia, int mes, float valor, int tipo, string nome)
            //TODO: set Importancia
            //TODO: Informe Mes
            //TODO: Informe o Tipo
            Console.WriteLine("Fale o nome do gasto");
            string nomeG = Console.ReadLine();
            Console.WriteLine("Diga o Valor:");
            float valor = float.Parse(Console.ReadLine());
            Console.WriteLine("Reco: ");
            int ti = int.Parse(Console.ReadLine());

            Console.WriteLine("Fala o Mês ai, de 1 a 12 por favor nem vem botar texto");
            int mes = int.Parse(Console.ReadLine());

            Console.WriteLine("Faz o seguinte digita o numero de vezes q vai repetir segue o ex");
            Console.WriteLine(" 1 - Não Repete");
            Console.WriteLine(" 2+  Numero de meses que vai repetir");
            int repete = int.Parse(Console.ReadLine());

            // TODO: Categoria
            Gasto g = new Gasto("Categoria", repete, mes, valor, ti, nomeG);
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

        public bool addRenda()
        {
            // (int mes, float valor, int tipo, string nome)
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
                Mes m = new Mes(i, nomeCarteira, budget);
                agenda[i] = m;
            }
            escreverAgenda();
        }
    }
}