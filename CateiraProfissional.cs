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
            Console.WriteLine("Informe em quantas parcelas será o pagamento:");
            Console.WriteLine(" 1 - Apenas Um Pagamento");
            Console.WriteLine(" 2 ou +  Numero de meses que ira se repetir");
            int recorrente = int.Parse(Console.ReadLine());
            // TODO: Categoria
            Gasto g = new Gasto(selectCategoria(), generateImportancia(), generateMes(), generateValue(), recorrente, generateNome());
            //Recorrencia
            int goal = g.Mes + g.Tipo;
            int current = g.Mes;
            g.Valor -= calcDesconto(g);
            budget = agenda[current].Budget;
            while (current < goal)
            {
                agenda[current].addGasto(g);
                for (int i = current; i < 12; i++)
                {
                    agenda[i].Budget = agenda[i].Budget - g.Valor;
                }
                current++;
            }

            escreverAgenda();
            return true;
        }
        private float calcDesconto(Gasto g){
            float desconto = 0;
            Console.WriteLine("Informe a quantidade que será comprado");
            int qtt = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe a porcentagem do Desconto por unidade");
            float val = float.Parse(Console.ReadLine());
            float calc = (g.Valor * val)/100;
            desconto = (calc * qtt);
            return desconto;
        }


        private int generateImportancia()
        {
            Console.WriteLine("Escolha um nível de Importancia: de 1 a 5");
            int importancia = int.Parse(Console.ReadLine());
            return importancia;
        }

        private int generateMes()
        {
            Console.WriteLine("Informe o Mês: de 1 a 12");
            int mes = int.Parse(Console.ReadLine());
            mes--;
            return mes;
        }

        private float generateValue()
        {
            Console.WriteLine("Informe o Valor:");
            float valor = float.Parse(Console.ReadLine());
            return valor;
        }

        private string generateNome()
        {
            Console.WriteLine("Informe um nome");
            string nome = Console.ReadLine();
            return nome;
        }

        public bool addRenda()
        {
            Console.WriteLine("Titulo do Aporte:");
            string nome = Console.ReadLine();
            Console.WriteLine("Valor:");
            float valor = float.Parse(Console.ReadLine());
            Console.WriteLine("Mês: de 1 a 12");
            int mes = int.Parse(Console.ReadLine());
            mes--;
            Console.WriteLine("Numero de Parcelas");
            Console.WriteLine(" 1 - Apenas uma");
            Console.WriteLine(" 2+  Numero de meses que vai repetir");
            int repete = int.Parse(Console.ReadLine());
            Renda r = new Renda(mes, valor, repete, nome);
            int goal = r.Mes + r.Tipo;
            int current = r.Mes;
            budget = agenda[current].Budget;
            while (current < goal)
            {
                agenda[current].addRenda(r);
                for (int i = current; i < 12; i++)
                {
                    agenda[i].Budget = agenda[i].Budget + r.Valor;
                }
                current++;
            }
            escreverAgenda();
            return true;
        }

        public bool addSalario()
        {
            Console.WriteLine("Informe o Nome da Empresa");
            String name = Console.ReadLine();
            Console.WriteLine("Informe o Salario");
            float valor = float.Parse(Console.ReadLine());
            Salario s = new Salario(valor, name);
            // vai add os 12 meses do ano
            for (int i = 0; i < 12; i++)
            {
                agenda[i].addSalario(s);
                budget += s.Valor;
                agenda[i].Budget = budget;

            }
            escreverAgenda();
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
            File.WriteAllText(@"Arquivos/agenda" + nomeCarteira + ".json", json_serializado);
            return (File.Exists(@"Arquivos/agenda" + nomeCarteira + ".json"));
        }

        //Verifica se um Array está cheio
        public bool IsFull(object[] dado)
        {
            throw new NotImplementedException();
        }

        public bool lerAgenda()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/agenda" + nomeCarteira + ".json"))
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