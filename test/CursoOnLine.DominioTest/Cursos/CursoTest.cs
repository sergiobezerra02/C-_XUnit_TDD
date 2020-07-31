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
            string nome = "Ana Maria";
            double cargaHoraria = 80;
            string publicoAlvo = "Estudantes";
            double valor = 950;

            //Ação
            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            //Verificação
            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valor, curso.Valor);


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
