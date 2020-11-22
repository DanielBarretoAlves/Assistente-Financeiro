using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//ERROR:  não está setando nada no array 
//TODO: Settar o array e testar o metodo
// Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
//    at Ada.CarteiraPessoal.agendarGasto(Gasto g) in C:\Users\danie\Desktop\VSC\CarteiraPessoal.cs:line 81
//    at Ada.CarteiraPessoal.addGasto(Gasto g) in C:\Users\danie\Desktop\VSC\CarteiraPessoal.cs:line 142
//    at Ada.Controller.menuPE(CarteiraPessoal p) in C:\Users\danie\Desktop\VSC\Controller.cs:line 378
//    at Ada.Controller..ctor() in C:\Users\danie\Desktop\VSC\Controller.cs:line 27
//    at Ada.Program.Main(String[] args) in C:\Users\danie\Desktop\VSC\Program.cs:line 13
// PS C:\Users\danie\Desktop\VSC> 
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
        private Mes[] agenda = new Mes[12];

        
        //Construtor
        public CarteiraPessoal(string nomeCarteira, float buget, Salario[] salarios, Gasto[] gastos, Renda[] rendas)
        {
            this.nomeCarteira = nomeCarteira;
            this.buget = buget;
            this.salarios = salarios;
            this.gastos = gastos;
            this.rendas = rendas;
            
            //Se der ruim apaga Meses

            for (int i = 0; i < agenda.Length; i++)
            {
                //TODO: Needs Work But Work just Fine :-)
                Mes m = new Mes(i);
                Gasto[] g = new Gasto[50];
                m.Gastos = g;
                agenda[i] = m;
                
                
            }
            Console.WriteLine("ENtrou");

            escreverAgenda();

            // FIm------------------
            
        }

        //GETTS & SETTERS
        public string NomeCarteira { get => nomeCarteira; set => nomeCarteira = value; }
        public float Buget { get => buget; set => buget = value; }
        public static int Tipo { get => tipo; set => tipo = value; }
        internal Salario[] Salarios { get => salarios; set => salarios = value; }
        internal Gasto[] Gastos { get => gastos; set => gastos = value; }
        internal Renda[] Rendas { get => rendas; set => rendas = value; }


        public void loadAgenda()
        {
            //Agenda =  i /    i = 12
            //AgendaTempo = z /  = z 12
            // gastos p/mes e joga dentro de cada mes masi bate no tipo
            // Um array chamo next q armazena só os proximos uma fila de gastos
            Mes[] tempo = new Mes[12];
        
            for (int i = 0; i < agenda.Length; i++)
            {
                tempo[i].Gastos = getGastoMes(i); // Add todos os Gastos por todos os Meses
                
            }

        }

        public bool agendarGasto(Gasto g)
        {
            
            int goal = g.Mes + g.Tipo;
            if (g.Tipo <= 1)
            {
                goal = 0;
                agenda[g.Mes].Gastos[agenda[g.Mes].GastoValidPOS()] = g;
            }

            //Aqui é para recorencia
            for (int i = g.Mes; i < goal; i++)
            {
                Console.WriteLine(agenda[g.Mes].GastoValidPOS());
                agenda[g.Mes].Gastos[agenda[g.Mes].GastoValidPOS()] = g;
            }
            var json_serializado = JsonConvert.SerializeObject(agenda);
            File.WriteAllText(@"Arquivos/" + "agenda"+nomeCarteira + ".json", json_serializado);
            return (File.Exists(@"Arquivos/" + "agenda"+nomeCarteira + ".json"));

        }
        private Gasto[]  getGastoMes(int m)
        {
            Gasto[] g = new Gasto[50];
            for (int i = 0; i < getGastosTamanho(); i++)
            {
                if (gastos[i].Mes == m)
                {
                    g[i] = gastos[i];
                }
            }
            return g;
        }
        private int getGastosTamanho()
        {
            int tamanho = 0;
            for (int i = 0; i < gastos.Length; i++)
            {
                if (gastos[i] != null)
                {
                    tamanho++;
                }
            }
            return tamanho;
        }


        public bool addRenda(Renda r)
        {
            expandirRenda();

            for (int i = 0; i < rendas.Length; i++)
            {
                if (rendas[i] == null)
                {
                    rendas[i] = r;
                    escreverRenda();
                    return true;
                }
            }
            return false;
        }

        public bool addGasto(Gasto g)
        {
            expandirGasto();
    
            for (int i = 0; i < gastos.Length; i++)
            {
                if (gastos[i] == null)
                {
                    gastos[i] = g;
                    //ADD na Agenda
                    //Agenda get gasto pega o gasto g e põe ele em todos os meses que ele se encontra
                    agendarGasto(g);
                    return true;
                }
            }
            return false;
        }

        public bool addSalario(Salario s)
        {
            expandirSalario();

            for (int i = 0; i < salarios.Length; i++)
            {
                if (salarios[i] == null)
                {
                    salarios[i] = s;
                    escreverSalario();
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

        public bool escreverAgenda()
        {
            var json_serializado = JsonConvert.SerializeObject(agenda);
            File.WriteAllText(@"Arquivos/" + "agenda"+nomeCarteira + ".json", json_serializado);
            return (File.Exists(@"Arquivos/" + "agenda"+nomeCarteira + ".json"));
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

        // public bool escreverCarteria(){
        //     var json_serializado = JsonConvert.SerializeObject(nomeCarteira);
        //     //  using (StreamWriter sw = File.AppendText("Arquivo/Carteiras.json")){
        //     //      sw.WriteLine(json_serializado);
        //     //  }
        //     File.WriteAllText(@"Arquivos/" + "Carteiras.json", json_serializado);
        //     return true;
        // }
        public void expandirGasto()
        {
            Gasto[] reserva = new Gasto[this.gastos.Length * 2];
            if(IsFull(gastos))
            {
                for(int i = 0; i < gastos.Length; i++)
                {
                    reserva[i] = gastos[i];
                }
                gastos = reserva;
            }
            
        }

        public void expandirRenda()
        {
            Renda[] reserva = new Renda[this.rendas.Length * 2];
            if(IsFull(rendas))
            {
                for(int i = 0; i < gastos.Length; i++)
                {
                    reserva[i] = rendas[i];
                }
                rendas = reserva;
            }
        }

        public void expandirSalario(){
        
            Salario[] reserva = new Salario[this.salarios.Length * 2];
            if(IsFull(salarios))
            {
                for(int i = 0; i < gastos.Length; i++)
                {
                    reserva[i] = salarios[i];
                }
                salarios = reserva;
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
                    Console.WriteLine("Entrou");
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
