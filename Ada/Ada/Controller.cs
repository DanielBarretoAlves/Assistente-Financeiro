using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ada
{
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
            loadCarteirasPE();
            loadCarteirasPR();

        }

        // Getts e Setters
        public string[] NomesCarteiras { get => nomesCarteiras; set => nomesCarteiras = value; }
        internal CarteiraPessoal[] Cp { get => cp; set => cp = value; }
        internal CarteiraProfissional[] Ct { get => ct; set => ct = value; }

        public void newCarteira()
        {

            Console.WriteLine("Me fala seu nome:");
            String nome = Console.ReadLine();
            Console.WriteLine("Prazer em te conhecer " + nome + ", vamos ser bons amigos!");
            if (validadeName(nome))
            {
                Console.WriteLine("Fala " + nome + " Vamos lembra que eu sou um Robo kkkkk escolhe ai pra mim");
                Console.WriteLine("1 - Para escolher criar uma Conta Pessoal");
                Console.WriteLine("2 - Para escolher um Conta do Trabalho");
                Console.WriteLine("Se escolher errado vai se 1 e pronto, mas vc n é tão burro assim ou será que é? kk");
                int e1 = int.Parse(Console.ReadLine());
                if (e1 == 2)
                {
                    gerarPR(nome);
                    escreverNomesPR();
                }
                else
                {
                    gerarPE(nome);
                    escreverNomesPE();

                }
            }


        }

        private bool gerarPE(string nome)
        {
            Gasto[] g = new Gasto[50];
            Renda[] r = new Renda[10];
            Console.WriteLine("Você já tem algum tustão no bolso, fala ai tem quanto?");
            Console.WriteLine("Valor:");
            float valor = float.Parse(Console.ReadLine());
            CarteiraPessoal c = new CarteiraPessoal(nome, valor, gerarSalario(), g, r);
            addPE(c);
            return true;
        }
        private bool gerarPR(string nome)
        {
            Gasto[] g = new Gasto[50];
            Renda[] r = new Renda[10];
            Console.WriteLine("Você já tem algum tustão no bolso, fala ai tem quanto?");
            Console.WriteLine("Valor:");
            float valor = float.Parse(Console.ReadLine());
            CarteiraProfissional c = new CarteiraProfissional(nome, valor, gerarSalario(), g, r);
            addPR(c);
            return true;
        }

        private bool validadeName(String nome)
        {
            int s1 = 0;
            int s2 = 0;
            //Conta o numero de PE que não é null
            for (int i = 0; i < cp.Length; i++)
            {
                if (cp[i] != null)
                {
                    s1++;
                }
            }
            // Conta o numero de PR que não é null
            for (int i = 0; i < ct.Length; i++)
            {
                if (ct[i] != null)
                {
                    s2++;
                }

            }


            if (s1 == 0)
            {
                return true;
            }

            if (s2 == 0)
            {
                return true;
            }

            //Valida PE
            for (int i = 0; i < s1; i++)
            {
                if (cp[i].NomeCarteira == nome)
                {
                    return false;
                }
            }


            //Valida PR
            for (int i = 0; i < s2; i++)
            {
                if (ct[i] == null || ct[i].NomeCarteira == nome)
                {
                    return false;
                }

            }
            return true;
        }

        //TODO: assim que for settar o mes vai olhar todos os gastos daquele mes todos os lucors, salario e somar um balanço
        private Salario[] gerarSalario()
        {
            Console.WriteLine("Fala meu Rei quantos empregos você tem?");
            int qtt = int.Parse(Console.ReadLine());
            if (qtt > 1)
            {
                Console.WriteLine("Caramba melhor que o pai do Chris!");
            }
            Salario[] salarios = new Salario[qtt];
            for (int i = 0; i < salarios.Length; i++)
            {
                Console.WriteLine("Quanto você rebe nesse emprego?");
                float valor = float.Parse(Console.ReadLine());

                Console.WriteLine("Qual o Nome do Lugar onde Você Trampa");
                String nome = Console.ReadLine();
                // float valor, int tipo, string nome)
                Salario s = new Salario(valor, 1, nome);
                salarios[i] = s;

            }

            return salarios;
        }

        private bool addPE(CarteiraPessoal c)
        {
            //TODO: Expandir Array

            for (var i = 0; i < cp.Length; i++)
            {
                if (cp[i] == null)
                {
                    cp[i] = c;
                    return true;
                }
            }
            return false;
        }

        private bool addPR(CarteiraProfissional c)
        {
            //TODO: Expandir Array

            for (var i = 0; i < ct.Length; i++)
            {
                if (ct[i] == null)
                {
                    ct[i] = c;
                    return true;
                }
            }
            return false;
        }

        private Gasto addGasto()
        {
            // Gasto.Gasto(string categoria, int importancia, int mes, float valor, int tipo, string nome)
            Console.WriteLine("Fala a Categoria");
            string categoria = Console.ReadLine();
            Console.WriteLine("De 1 a 5 sendo 5 o mais importante fala aí qual o nivel de importancia dessa despesa");
            int imp = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o mes desse gasto, obs: de 1 a 12");
            int mes = int.Parse(Console.ReadLine());
            mes--;
            Console.WriteLine("Fala ai Gastou quanto nisso");
            Console.WriteLine("Valor:");
            float valor = float.Parse(Console.ReadLine());
            Console.WriteLine("Fala em quantos meses esse gasto vai se repetirm, obs: 1 Para não repetir");
            int tipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Fala ai no que vc gastou?");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Gasto g = new Gasto(categoria, imp, mes, valor, tipo, nome);
            return g;
        }
        
        private Renda addRenda(){
            Console.WriteLine("Fala o numero do mes");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Fala ai quanto tu ganhou");
            float valor = float.Parse(Console.ReadLine());
            Console.WriteLine("Me fala quantos meses tu vai receber, obs: 1 para não repetir");
            int tipo = int.Parse(Console.ReadLine());
            Console.WriteLine("Agora um nome:");
            string nome = Console.ReadLine();
            Renda r = new Renda(mes, valor, tipo, nome);
            return r;
        }
        private void escreverNomesPE()
        {
            var json_serializado = JsonConvert.SerializeObject(cp);
            File.WriteAllText(@"Arquivos/CarteirasPessoais.json", json_serializado);
        }

        private void escreverNomesPR()
        {
            var json_serializado = JsonConvert.SerializeObject(ct);
            File.WriteAllText(@"Arquivos/CarteirasProfissionais.json", json_serializado);
        }

        private void loadCarteirasPE()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/CarteirasPessoais.json"))
            {
                st += sr.ReadToEnd();

            }
            cp = JsonConvert.DeserializeObject<CarteiraPessoal[]>(st);
        }

        private void loadCarteirasPR()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/CarteirasProfissionais.json"))
            {
                st += sr.ReadToEnd();

            }
            ct = JsonConvert.DeserializeObject<CarteiraProfissional[]>(st);
        }

        private void menuPE(CarteiraPessoal p)
        {
            float key = 1;
            Console.WriteLine("Entramos " + p.NomeCarteira);
            while (key != 0)
            {
                Console.WriteLine("Como Posso te Ajudar:");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Paguei ou vou pagar uma parada");
                Console.WriteLine("2- Ganhei ou vou ganhar uma grana");
                Console.WriteLine("3 - Arrumei  outro trampo");
                Console.WriteLine("4 - Vou ser Demitido \\O/");
                Console.WriteLine("5 - Verificar por mes");
                key = float.Parse(Console.ReadLine());
                switch (key)
                {
                    case 0:
                        break;
                    case 1:
                        p.addGasto(addGasto());
                        break;
                    default:
                        break;
                }


            }
        }



    }
}
