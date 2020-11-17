﻿using Newtonsoft.Json;
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
            throw new NotImplementedException();
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
            if (IsFull(salarios) == false) {
                for (int i = 0; i < salarios.Length; i++)
                {
                    if (salarios[i] == null)
                    {
                        salarios[i] = g;
                        return true;
                    }
                }
            }// else if (IsFull(salarios) == true) {
             //   expandirSalario();
             //   addSalario(s);
            //}
            return false;
        }

        public bool escreverGasto()
        {
            var json_serializado = JsonConvert.SerializeObject(gastos);
            File.WriteAllText(@"Arquivos/" + nomeCarteira + ".json", json_serializado);
            return (File.Exists(@"Gastos" + nomeCarteira + ".json"));
        }

        public bool lerGasto()
        {
            String st = "";
            using (var sr = new StreamReader(@"Arquivos/Daniel.json"))
            {
                st += sr.ReadToEnd();

            }
            Gasto[] test = JsonConvert.DeserializeObject<Gasto[]>(st);
            return true;
        }

        public bool escreverRenda()
        {
            throw new NotImplementedException();
        }

        public bool lerRenda()
        {
            throw new NotImplementedException();
        }

        public bool escreverSalario()
        {
            throw new NotImplementedException();
        }

        public bool lerSalario()
        {
            throw new NotImplementedException();
        }

        public void expandirGasto()
        {
            throw new NotImplementedException();
        }

        public void expandirRenda()
        {
            throw new NotImplementedException();
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
