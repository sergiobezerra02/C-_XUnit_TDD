using CursoOnLine.DominioTest._Builder;
using CursoOnLine.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnLine.DominioTest.Cursos
{
    public class CursoTest :IDisposable
    {

        private readonly ITestOutputHelper _output;
        private int _id;
        private string _nome;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valor;
        private string _descricao;

        public CursoTest(ITestOutputHelper output)
        {
            this._output = output;
            this._output.WriteLine("Construtor executado");

            _id = 1;
            _nome = "Ana Maria";
            _cargaHoraria = 80;
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = 950;
            _descricao = "Curso Informática";
        }

        public void Dispose()
        {
            this._output.WriteLine("Dispose() executado");
        }
    

        [Fact]
        public void Teste_Dominio_Curso()
        {
            //Cenário
            //Biblioteca ExpectedObject
            //Construtor
            var cursoEsperado = new
            {
                Id = 1,
                Nome = "Ana Maria",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950,
                Descricao = "Curso Informática"
            };
         

            //Ação
            var curso = new Curso(cursoEsperado.Id, cursoEsperado.Nome, 
                cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor, cursoEsperado.Descricao);

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
            //Construtor
  
            //Ação e Verificação
            Assert.Throws<ArgumentException>(() => CursoBuilder.GetCursoBuilder().ComNome(nomeInvalido).Build()).ComMensagem("Nome Inválido");        
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-5)]
        public void Teste_ValidarCargaHoraria_Invalida(double cargaHorariaInvalida)
        {
            //Cenário
            //Biblioteca ExpectedObject
            //Construtor

            //Ação e Verificação
            Assert.Throws<ArgumentException>(() => CursoBuilder.GetCursoBuilder().ComCargaHoraria(cargaHorariaInvalida).Build()).ComMensagem("Carga Horária Inválida");

        }



        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-5)]
        public void Teste_ValidarValor_Invalido(double valorInvalido)
        {
            //Cenário
            //Biblioteca ExpectedObject
            //Construtor

            //Ação e Verificação
            Assert.Throws<ArgumentException>(() => CursoBuilder.GetCursoBuilder().ComValor(valorInvalido).Build()).ComMensagem("Valor Inválido");

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
        private int _id;
        private string _nome;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valor;
        private string _descricao;

        public Curso() { }

        public Curso(int id, string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor, string descricao)
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

            this._id = id;
            this._nome = nome;
            this._cargaHoraria = cargaHoraria;
            this._publicoAlvo = publicoAlvo;
            this._valor = valor;
            this._descricao = descricao;
        }

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }

        public double CargaHoraria
        {
            get { return this._cargaHoraria; }
            set { this._cargaHoraria = value; }
        }

        public PublicoAlvo PublicoAlvo
        {
            get { return this._publicoAlvo; }
            set { this._publicoAlvo = value; }
        }

        public double Valor
        {
            get { return this._valor; }
            set { this._valor = value; }
        }

        public string Descricao
        {
            get { return this._descricao; }
            set { this._descricao = value; }
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
            return $"[Curso => Id: {this._id} , Nome: {this._nome} , PublicoAlvo: {this._publicoAlvo} , Valor: {this._valor} ]";

        }
    }

}
