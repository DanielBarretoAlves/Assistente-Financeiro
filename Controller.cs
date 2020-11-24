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
            limparCP();
            updateCP();


        }

        // Getts e Setters
        public string[] NomesCarteiras { get => nomesCarteiras; set => nomesCarteiras = value; }
        internal CarteiraPessoal[] Cp { get => cp; set => cp = value; }


        //Metodos CP
        private void updateCP()
        {
            // gastos = null;
            if (File.Exists(@"Arquivos/carteiras.json"))
            {
                readCP();
            }
            else
            {
                limparCP();
                menuCP(cp[createCP()]);
            }
        }

        private bool writeCP()
        {
            var json_serializado = JsonConvert.SerializeObject(cp);
            File.WriteAllText(@"Arquivos/carteirasPessoais.json", json_serializado);
            return (File.Exists(@"Arquivos/carteirasPessoais.json"));
        }
        private bool readCP()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/carteirasPessoais.json"))
            {
                st += sr.ReadToEnd();

            }
            cp = JsonConvert.DeserializeObject<CarteiraPessoal[]>(st);
            return true;
        }

        public void limparCP()
        {
            cp = new CarteiraPessoal[20];
            writeCP();
        }

        public bool addCarteira()
        {
            expandirCP();
            Console.WriteLine("Fala seu nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe quanto você já tem guardado");
            float money = float.Parse(Console.ReadLine());
            CarteiraPessoal c = new CarteiraPessoal(nome, money);
            for (int i = 0; i < cp.Length; i++)
            {
                if (cp[i] == null)
                {
                    cp[i] = c;
                    writeCP();
                    return true;
                }
            }

            return false;
        }


        private void expandirCP()
        {
            CarteiraPessoal[] reserva = new CarteiraPessoal[this.cp.Length * 2];
            if (IsFull(cp))
            {
                for (int i = 0; i < cp.Length; i++)
                {
                    reserva[i] = cp[i];
                }
                cp = reserva;
            }

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
            if (dado.Length == size)
            {
                return true;
            }
            return false;
        }

        private int selectCP()
        {
            Console.WriteLine("Selecione Carteira Pessoal");
            for (var i = 0; i < cp.Length; i++)
            {
                Console.WriteLine(i + " - " + cp[i].NomeCarteira);
            }
            int escolha = int.Parse(Console.ReadLine());
            return escolha;

        }

        private void addGastoCP(CarteiraPessoal c)
        {
            c.addGasto();
            writeCP();
        }

        private void addRendaCP(CarteiraPessoal c)
        {
            c.addRenda();
            writeCP();
        }

        private void addSalarioCP(CarteiraPessoal c)
        {
            c.addSalario();
            writeCP();
        }

        private void statsCP(CarteiraPessoal c)
        {
            Console.WriteLine("Informe o Mes que deseja visualizar");
            int mes = int.Parse(Console.ReadLine());
            c.Agenda[mes].calcGastos();
            c.Agenda[mes].calcRenda();
        }

        public void menuCP(CarteiraPessoal c)
        {
            Console.WriteLine("1 - Cadastrar Emprego");
            Console.WriteLine("2 - Add um Gasto");
            Console.WriteLine("3 - Add uma Renda");
            Console.WriteLine("4 - Ver Gastos de Um Mês");
            Console.WriteLine("5 - Ver Rendas de Um Mês");
            Console.WriteLine("6 - Analisar Dados de Um Mês");
            Console.WriteLine("0 - Sair");
            int escolha = int.Parse(Console.ReadLine());
            switch (escolha)
            {
                case 1:
                    addSalarioCP(c);
                    break;
                case 2:
                    addGastoCP(c);
                    break;
                case 3:
                    addRendaCP(c);
                    break;
                case 4:
                    statsCP(c);
                    break;
                case 5:
                    addSalarioCP(c);
                    break;
                case 6:
                    addSalarioCP(c);
                    break;
                default:
                    break;
            }

        }

        private int createCP()
        {
            Console.WriteLine("Fala o Nome");
            string name = Console.ReadLine();
            Console.WriteLine("Informe quanto você já tem guardado");
            float bud = float.Parse(Console.ReadLine());
            CarteiraPessoal c = new CarteiraPessoal(name, bud);
            expandirCP();
            for (var i = 0; i < cp.Length; i++)
            {
                if (cp[i] == null)
                {
                    Console.WriteLine("entrou");
                    cp[i] = c;
                    writeCP();
                    return i;
                }
            }
            return 0;
        }






    }
}
