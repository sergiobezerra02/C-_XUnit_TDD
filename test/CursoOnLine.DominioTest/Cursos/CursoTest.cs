using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Xunit;

namespace CursoOnLine.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void Teste_Dominio_Curso()
        {
            //Cenário
            //Biblioteca ExpectedObject
            var cursoEsperado = new
            {
                Nome = "Ana Maria",
                CargaHoraria = (double)80,
                PublicoAlvo = "Estudantes",
                Valor = (double)950
            };

            

            //Ação
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //Verificação
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }
    }

    public class Curso
    {

        private string nome;
        private double cargaHoraria;
        private string publicoAlvo;
        private double valor;

        public Curso() { }

        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valor)
        {
            this.nome = nome;
            this.cargaHoraria = cargaHoraria;
            this.publicoAlvo = publicoAlvo;
            this.valor = valor;
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public double CargaHoraria
        {
            get { return this.cargaHoraria; }
            set { this.cargaHoraria = value; }
        }

        public string PublicoAlvo
        {
            get { return this.publicoAlvo; }
            set { this.publicoAlvo = value; }
        }

        public double Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }


    }

}
