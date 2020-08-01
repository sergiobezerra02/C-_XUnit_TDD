using Bogus;
using CursoOnLine.Dominio.Enumeration;
using CursoOnLine.DominioTest._Builder;
using CursoOnLine.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;
using CursoOnLine.Dominio.Curso;

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

            var fake = new Faker();

            _id = fake.Random.Int(1,2147483647);
            _nome = fake.Person.FullName;
            _cargaHoraria = fake.Random.Double(60,120);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = fake.Random.Double(60, 1000);
            _descricao = fake.Lorem.Paragraph();

            this._output.WriteLine(_id.ToString());
            this._output.WriteLine(_nome);
            this._output.WriteLine(_cargaHoraria.ToString());
            this._output.WriteLine(_publicoAlvo.ToString());
            this._output.WriteLine(_valor.ToString());
            this._output.WriteLine(_descricao);
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
                Nome = "Curso A",
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


}
