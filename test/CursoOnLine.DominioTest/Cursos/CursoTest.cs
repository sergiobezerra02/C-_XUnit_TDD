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
