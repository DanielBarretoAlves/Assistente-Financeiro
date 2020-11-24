using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ada
{
    public class Mes
    {

        // EX De Nomeclatura de Gastos GastosDanielMar.json
        private string nome;

        private float budget;

        private string nomeCarteira;
        private float balanco;
        private Gasto[] gastos; // Verificar se vai armazenar no json
        private Salario[] salarios;
        private Renda[] rendas;
        private float maxRenda; //Salarios englobam nesta conta
        private float maxGasto;

        // check
        // if (File.Exists(@"Arquivos/gastos" + p.NomeCarteira + ".json"))
        //     {
        //         setGastosPE(p);
        //     }


        //Write
        // var json_serializado = JsonConvert.SerializeObject(gastos);
        //     File.WriteAllText(@"Arquivos/" + "gastos" + nomeCarteira + ".json", json_serializado);
        //     return (File.Exists(@"Arquivos/" + "gastos" + nomeCarteira + ".json"));


        // read
        // String st = "";
        //     using (var sr = new StreamReader(@"Arquivos/" + "gastos" + nomeCarteira + ".json"))
        //     {
        //         st += sr.ReadToEnd();

        //     }
        //     Gasto[] newGastos = JsonConvert.DeserializeObject<Gasto[]>(st);
        //     Console.WriteLine(newGastos[0].Nome);
        //     return true;

        // Constructor set
        // public Mes(int num)
        // {
        //     setNameMes(num);
        //     gastos = new Gasto[50];
        //     maxGasto = 0;
        // }
        // Constructor load
        public Mes(int num, string nomeCarteira, float budget)
        {

            this.nomeCarteira = nomeCarteira;
            setNameMes(num);
            gastos = new Gasto[50];
            rendas = new Renda[50];
            salarios = new Salario[3];
            maxGasto = 0;
            maxRenda = 0;
            this.budget = budget;
            // updateGastos();
        }
        
        public string Nome { get => nome; set => nome = value; }
        public string NomeCarteira { get => nomeCarteira; set => nomeCarteira = value; }
        public float Budget { get => budget; set => budget = value; }
        public float Balanco { get => balanco; set => balanco = value; }
        public float MaxRenda { get => maxRenda; set => maxRenda = value; }
        public float MaxGasto { get => maxGasto; set => maxGasto = value; }
        public Gasto[] Gastos { get => gastos; set => gastos = value; }
        public Salario[] Salarios { get => salarios; set => salarios = value; }
        public Renda[] Rendas { get => rendas; set => rendas = value; }
        

        //Metodos

        private void updateGastos()
        {
            // gastos = null;
            if (File.Exists(@"Arquivos/gastos" + nomeCarteira + "" + nome + ".json"))
            {
                readGastos();
            }
            else
            {
                writeGastos();
            }
        }

        private bool writeGastos()
        {
            var json_serializado = JsonConvert.SerializeObject(gastos);
            File.WriteAllText(@"Arquivos/gastos" + nomeCarteira + "" + nome + ".json", json_serializado);
            return (File.Exists(@"Arquivos/gastos" + nomeCarteira + "" + nome + ".json"));
        }
        private bool readGastos()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/gastos" + nomeCarteira + "" + nome + ".json"))
            {
                st += sr.ReadToEnd();

            }
            gastos = JsonConvert.DeserializeObject<Gasto[]>(st);
            return true;
        }

        private void updateRendas()
        {
            // gastos = null;
            if (File.Exists(@"Arquivos/rendas" + nomeCarteira + "" + nome + ".json"))
            {
                readRenda();
            }
            else
            {
                writeRenda();
            }
        }
        private bool writeRenda()
        {
            var json_serializado = JsonConvert.SerializeObject(gastos);
            File.WriteAllText(@"Arquivos/rendas" + nomeCarteira + "" + nome + ".json", json_serializado);
            return (File.Exists(@"Arquivos/rendas" + nomeCarteira + "" + nome + ".json"));
        }
        private bool readRenda()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/rendas" + nomeCarteira + "" + nome + ".json"))
            {
                st += sr.ReadToEnd();

            }
            rendas = JsonConvert.DeserializeObject<Renda[]>(st);
            return true;
        }
        private void setNameMes(int num)
        {
            switch (num)
            {
                case 0:
                    nome = "Jan";
                    break;
                case 1:
                    nome = "Fev";
                    break;
                case 2:
                    nome = "Mar";
                    break;
                case 3:
                    nome = "Abr";
                    break;
                case 4:
                    nome = "Mai";
                    break;
                case 5:
                    nome = "Jun";
                    break;
                case 6:
                    nome = "Jul";
                    break;
                case 7:
                    nome = "Ago";
                    break;
                case 8:
                    nome = "Set";
                    break;
                case 9:
                    nome = "Out";
                    break;
                case 10:
                    nome = "Nov";
                    break;
                case 11:
                    nome = "Des";
                    break;
                default:
                    break;
            }
        }
        public int getGastosTamanho()
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

        public int getRendasTamanho()
        {
            int tamanho = 0;
            for (int i = 0; i < rendas.Length; i++)
            {
                if (rendas[i] != null)
                {
                    tamanho++;
                }
            }
            return tamanho;
        }

        public int getSalariosTamanho()
        {
            int tamanho = 0;
            for (int i = 0; i < salarios.Length; i++)
            {
                if (salarios[i] != null)
                {
                    tamanho++;
                }
            }
            return tamanho;
        }
        public void updateMaxGasto()
        {
            for (int i = 0; i < getGastosTamanho(); i++)
            {
                maxGasto += gastos[i].Valor;
            }
        }

        private void expandirGasto()
        {
            Gasto[] reserva = new Gasto[this.gastos.Length * 2];
            if (IsFull(gastos))
            {
                for (int i = 0; i < gastos.Length; i++)
                {
                    reserva[i] = gastos[i];
                }
                gastos = reserva;
            }

        }
        private bool IsFull(object[] dado)
        {
            int size = 0;
            //Somando a quantidade de casas do array oculpadas
            for (int i = 0; i < dado.Length; i++)
            {
                if (dado[i] != null)
                {
                    // Console.WriteLine("Entrou");
                    size++;
                }
            }
            if (dado.Length == size)
            {
                return true;
            }
            return false;
        }

        public bool addGasto(Gasto g)
        {
            expandirGasto();
            Console.WriteLine("Valor Gasto: " + g.Valor);
            Console.WriteLine("Budget Atual" + budget);
            for (int i = 0; i < gastos.Length; i++)
            {
                if (gastos[i] == null)
                {
                    gastos[i] = g;
                    maxGasto+= g.Valor;
                    // budget = budget - g.Valor;
                    Console.WriteLine("Valor Budget Final" + budget);
                    return true;
                }
            }
            return false;

        }

        public bool addRenda(Renda r)
        
        {
            expandirRenda();
            for (int i = 0; i < rendas.Length; i++)
            {
                if (rendas[i] == null)
                {
                    rendas[i] = r;
                    maxRenda += r.Valor;
                    // budget += r.Valor;
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
                    maxRenda += s.Valor;
                    // budget += s.Valor;
                    Console.WriteLine("Salario: "+ s.Valor);
                    Console.WriteLine("Budget: " + budget);
                    return true;
                }
            }
            return false;

        }

        private void expandirRenda()
        {
            Renda[] reserva = new Renda[this.rendas.Length * 2];
            if (IsFull(rendas))
            {
                for (int i = 0; i < rendas.Length; i++)
                {
                    reserva[i] = rendas[i];
                }
                rendas = reserva;
            }

        }

        private void expandirSalario()
        {
            Salario[] reserva = new Salario[this.rendas.Length * 2];
            if (IsFull(salarios))
            {
                for (int i = 0; i < salarios.Length; i++)
                {
                    reserva[i] = salarios[i];
                }
                salarios = reserva;
            }

        }


        public void stats()
        {
            Console.WriteLine("Gastos do Mês: " + maxGasto);
            Console.WriteLine("Lucro do Mês: " + maxRenda);
            Console.WriteLine("Saldo Final do Mês: " + budget);
        }




    }
}
