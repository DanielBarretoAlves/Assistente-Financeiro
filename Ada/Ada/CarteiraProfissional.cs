﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ada
{
    class CarteiraProfissional : Bolso
    {
        private string nomeCarteira;
        private float buget;
        private static int tipo = 0;
        private Salario[] sarios;
        private Gasto[] gastos;
        private Renda[] rendas;

        //Construtor
        public CarteiraProfissional(string nomeCarteira, float buget, Salario[] sarios, Gasto[] gastos, Renda[] rendas)
        {
            this.nomeCarteira = nomeCarteira;
            this.buget = buget;
            this.sarios = sarios;
            this.gastos = gastos;
            this.rendas = rendas;
        }

        //GETTS & SETTERS
        public string NomeCarteira { get => nomeCarteira; set => nomeCarteira = value; }
        public float Buget { get => buget; set => buget = value; }
        public static int Tipo { get => tipo; set => tipo = value; }
        internal Salario[] Sarios { get => sarios; set => sarios = value; }
        internal Gasto[] Gastos { get => gastos; set => gastos = value; }
        internal Renda[] Rendas { get => rendas; set => rendas = value; }

        //Metodos
        public bool addRenda(Renda r)
        {
            throw new NotImplementedException();
        }

        public bool addGasto(Gasto g)
        {
            throw new NotImplementedException();
        }

        public bool addSalario(Salario s)
        {
            throw new NotImplementedException();
        }

        public bool escreverGasto()
        {
            throw new NotImplementedException();
        }

        public bool lerGasto()
        {
            throw new NotImplementedException();
        }

        public bool escreverRenda()
        {
            throw new NotImplementedException();
        }

        public bool lerRenda()
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
            throw new NotImplementedException();
        }
    }
}
