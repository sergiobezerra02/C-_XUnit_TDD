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
                Id = 1,
                Nome = "Ana Maria",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };
         

            //Ação
            var curso = new Curso(cursoEsperado.Id, cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //Verificação
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Teste_ValidarNome_Invalido(string nomeInvalido)
        {
            //Cenário
            //Biblioteca ExpectedObject
            var cursoEsperado = new
            {
                Id = 1,
                Nome = "Ana Maria",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };


            //Ação e Verificação
            var message = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Id, string.Empty, 
                cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal("Nome Inválido", message);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-5)]
        public void Teste_ValidarCargaHoraria_Invalida(double cargaHorariaInvalida)
        {
            //Cenário
            //Biblioteca ExpectedObject
            var cursoEsperado = new
            {
                Id = 1,
                Nome = "Ana Maria",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };


            //Ação e Verificação
            var message = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Id, cursoEsperado.Nome, 
                cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;

            Assert.Equal("Carga Horária Inválida", message);
        }



        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-5)]
        public void Teste_ValidarValor_Invalido(double valorInvalido)
        {
            //Cenário
            //Biblioteca ExpectedObject
            var cursoEsperado = new
            {
                Id = 1,
                Nome = "Ana Maria",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950
            };


            //Ação e Verificação
            var message = Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Id, cursoEsperado.Nome, 
                cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido))
                .Message;

            Assert.Equal("Valor Inválido", message);
        }




    }


    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        private int id;
        private string nome;
        private double cargaHoraria;
        private PublicoAlvo publicoAlvo;
        private double valor;

        public Curso() { }

        public Curso(int id, string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {

            if(string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome Inválido");
            }

            if(cargaHoraria < 1)
            {
                throw new ArgumentException("Carga Horária Inválida");
            }

            if(valor < 1)
            {
                throw new ArgumentException("Valor Inválido");
            }

            this.id = id;
            this.nome = nome;
            this.cargaHoraria = cargaHoraria;
            this.publicoAlvo = publicoAlvo;
            this.valor = valor;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
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

        public PublicoAlvo PublicoAlvo
        {
            get { return this.publicoAlvo; }
            set { this.publicoAlvo = value; }
        }

        public double Valor
        {
            get { return this.valor; }
            set { this.valor = value; }
        }

        public override bool Equals(object obj)
        {
            return obj is Curso curso &&
                   Id == curso.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public string DadosCurso()
        {
            return $"[Curso => Id: {this.id} , Nome: {this.nome} , PublicoAlvo: {this.publicoAlvo} , Valor: {this.valor} ]";

        }
    }

}
