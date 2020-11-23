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
            updateCP();


        }

        // Getts e Setters
        public string[] NomesCarteiras { get => nomesCarteiras; set => nomesCarteiras = value; }
        internal CarteiraPessoal[] Cp { get => cp; set => cp = value; }

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

        public void addCarteira()
        {
            CarteiraPessoal c = new CarteiraPessoal("Test", 1000);
            cp[0] = c;
            writeCP();
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
            if(dado.Length == size)
            {
                return true;
            }
            return false;
        }

        

    }
}
