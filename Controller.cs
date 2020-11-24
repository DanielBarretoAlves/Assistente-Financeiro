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
        private CarteiraProfissional[] ct;


        private String[] nomesCarteiras;


        public Controller()
        {
            nomesCarteiras = new string[50];
            cp = new CarteiraPessoal[20];
            ct = new CarteiraProfissional[20];
            int callAda = 10;
            Console.WriteLine("Olá sou Ada sua assistente financeira");
            Console.WriteLine("Nem vem querer ser formal comigo não sou uma engomadinha ( -_-)");
            while (callAda != 0)
            {
                Console.WriteLine("Escolhe ai oq vc quer:");
                Console.WriteLine("1 - Carteira Pessoal");
                Console.WriteLine("2 - Carteira Profissional");
                Console.WriteLine("0 - Sair");
                callAda = int.Parse(Console.ReadLine());
                switch (callAda)
                {
                    case 1:
                    updateCP();
                        break;
                    case 2:
                    Console.WriteLine("Aff.. então tá vou tentar ser um pouco mais formal, mas não espere muita coisa");
                    updateCT();
                        break;
                    default:
                        break;
                }
                
            }
            // updateCP();
        }

        // Getts e Setters
        public string[] NomesCarteiras { get => nomesCarteiras; set => nomesCarteiras = value; }
        internal CarteiraPessoal[] Cp { get => cp; set => cp = value; }
        internal CarteiraProfissional[] Ct { get => ct; set => ct = value;}


        //Metodos CP
        private void updateCP()
        {
            // gastos = null;
            if (File.Exists(@"Arquivos/carteirasPessoais.json"))
            {
                readCP();
                Console.WriteLine("Desejá utlizar uma carteira já existente ou criar uma nova?");
                Console.WriteLine("1 - Criar Nova Carteira");
                Console.WriteLine("2 - Procurar Carteira Existente");
                int value = int.Parse(Console.ReadLine());
                switch (value)
                {
                    case 1:
                    menuCP(createCP());
                        break;
                    default:
                    menuCP(selectCP());
                        break;
                }
                
                
            }
            else
            {
                limparCP();
                menuCP(createCP());
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
            Console.WriteLine("Selecione Carteira Pessoal:");
            for (var i = 0; i < cp.Length; i++)
            {
                if (cp[i] != null)
                {
                    Console.WriteLine(i + " - " + cp[i].NomeCarteira);
                }
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
            Console.WriteLine("Informe o Mes que deseja visualizar, de 1 a 12 pelo amor de Deus né!");
            int mes = int.Parse(Console.ReadLine());
            mes--;
            c.Agenda[mes].stats();
        }

        public void menuCP(int p)
        {

            int escolha = 10;
            while (escolha != 0)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("1 - Cadastrar Emprego");
                Console.WriteLine("2 - Add um Gasto");
                Console.WriteLine("3 - Add uma Renda");
                Console.WriteLine("4 - Ver Gastos de Um Mês");
                Console.WriteLine("5 - Apagar todas as Carteiras");
                Console.WriteLine("-----------------------");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("-----------------------");
                escolha = int.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        addSalarioCP(cp[p]);
                        break;
                    case 2:
                        addGastoCP(cp[p]);
                        break;
                    case 3:
                        addRendaCP(cp[p]);
                        break;
                    case 4:
                        statsCP(cp[p]);
                        break;
                    case 5:
                        limparCP();
                        escolha = 0;
                        break;
                    default:
                        break;
                }
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
                    cp[i] = c;
                    writeCP();
                    return i;
                }
            }
            return 0;
        }

        //Metodos CT -------------------------------------------------------------

        private void updateCT()
        {
            // gastos = null;
            if (File.Exists(@"Arquivos/carteirasProfissionais.json"))
            {
                readCT();
                Console.WriteLine("Desejá utlizar uma carteira já existente ou criar uma nova?");
                Console.WriteLine("1 - Criar Nova Carteira");
                Console.WriteLine("2 - Procurar Carteira Existente");
                int value = int.Parse(Console.ReadLine());
                switch (value)
                {
                    case 1:
                    menuCT(createCT());
                        break;
                    default:
                    menuCT(selectCT());
                        break;
                }
                
                
            }
            else
            {
                limparCT();
                menuCT(createCT());
            }
        }

        private bool writeCT()
        {
            var json_serializado = JsonConvert.SerializeObject(ct);
            File.WriteAllText(@"Arquivos/carteirasProfissionais.json", json_serializado);
            return (File.Exists(@"Arquivos/carteirasProfissionais.json"));
        }
        private bool readCT()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/carteirasProfissionais.json"))
            {
                st += sr.ReadToEnd();

            }
            ct = JsonConvert.DeserializeObject<CarteiraProfissional[]>(st);
            return true;
        }

        public void limparCT()
        {
            ct = new CarteiraProfissional[20];
            writeCT();
        }

        public bool addCarteiraT()
        {
            expandirCT();
            Console.WriteLine("Fala seu nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe quanto você já tem guardado");
            float money = float.Parse(Console.ReadLine());
            CarteiraProfissional c = new CarteiraProfissional(nome, money);
            for (int i = 0; i < cp.Length; i++)
            {
                if (ct[i] == null)
                {
                    ct[i] = c;
                    writeCT();
                    return true;
                }
            }

            return false;
        }


        private void expandirCT()
        {
            CarteiraProfissional[] reserva = new CarteiraProfissional[this.cp.Length * 2];
            if (IsFull(ct))
            {
                for (int i = 0; i < ct.Length; i++)
                {
                    reserva[i] = ct[i];
                }
                ct = reserva;
            }

        }
        

        private int selectCT()
        {
            Console.WriteLine("Selecione Carteira Profissional:");
            for (var i = 0; i < ct.Length; i++)
            {
                if (ct[i] != null)
                {
                    Console.WriteLine(i + " - " + ct[i].NomeCarteira);
                }
            }
            int escolha = int.Parse(Console.ReadLine());
            return escolha;

        }

        private void addGastoCT(CarteiraProfissional c)
        {
            c.addGasto();
            writeCT();
        }

        private void addRendaCT(CarteiraProfissional c)
        {
            c.addRenda();
            writeCT();
        }

        private void addSalarioCT(CarteiraProfissional c)
        {
            c.addSalario();
            writeCT();
        }

        private void statsCT(CarteiraProfissional c)
        {
            Console.WriteLine("Informe o Mes que deseja visualizar, de 1 a 12 pelo amor de Deus né!");
            int mes = int.Parse(Console.ReadLine());
            mes--;
            c.Agenda[mes].stats();
        }

        public void menuCT(int p)
        {

            int escolha = 10;
            while (escolha != 0)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("1 - Cadastrar Emprego");
                Console.WriteLine("2 - Add um Gasto");
                Console.WriteLine("3 - Add uma Renda");
                Console.WriteLine("4 - Ver Gastos de Um Mês");
                Console.WriteLine("5 - Apagar todas as Carteiras");
                Console.WriteLine("-----------------------");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("-----------------------");
                escolha = int.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        addSalarioCT(ct[p]);
                        break;
                    case 2:
                        addGastoCT(ct[p]);
                        break;
                    case 3:
                        addRendaCT(ct[p]);
                        break;
                    case 4:
                        statsCT(ct[p]);
                        break;
                    case 5:
                        limparCT();
                        escolha = 0;
                        break;
                    default:
                        break;
                }
            }

        }

        private int createCT()
        {
            Console.WriteLine("Fala o Nome");
            string name = Console.ReadLine();
            Console.WriteLine("Informe quanto você já tem guardado");
            float bud = float.Parse(Console.ReadLine());
            CarteiraProfissional c = new CarteiraProfissional(name, bud);
            expandirCT();
            for (var i = 0; i < ct.Length; i++)
            {
                if (ct[i] == null)
                {
                    ct[i] = c;
                    writeCT();
                    return i;
                }
            }
            return 0;
        }










    }
}
