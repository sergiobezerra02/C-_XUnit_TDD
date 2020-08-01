using CursoOnLine.Dominio.Curso;
using CursoOnLine.Dominio.Enumeration;
using System;
using Xunit;
using Moq;
using Xunit.Abstractions;
using Bogus;

namespace CursoOnLine.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest :IDisposable
    {

        private readonly ITestOutputHelper _output;
        private int _id;
        private string _nome;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valor;
        private string _descricao;
        private Mock<ICursoRepositorio> _cursoRepositorioMock;
        private ArmazanadorDeCurso _armazenadorDeCurso;
        private CursoDTO _cursoDTO;

        public ArmazenadorDeCursoTest(ITestOutputHelper output)
        {
            this._output = output;
            this._output.WriteLine("Construtor executado");

            var fake = new Faker();

            _id = fake.Random.Int(1, 2147483647);
            _nome = fake.Person.FullName;
            _cargaHoraria = fake.Random.Double(60, 120);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = fake.Random.Double(60, 1000);
            _descricao = fake.Lorem.Paragraph();

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazanadorDeCurso(_cursoRepositorioMock.Object);

            _cursoDTO = new CursoDTO(_id, _nome, _cargaHoraria, _publicoAlvo, _valor, _descricao);

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
        public void Testar_Deve_Adicionar_Curso()
        {
            //Cenário
            //Biblioteca ExpectedObject
            //Consrutor
           
            var cursoRepositorioMock = new Mock<ICursoRepositorio>();
            var armazenadorDeCurso = new ArmazanadorDeCurso(cursoRepositorioMock.Object);
            
            //Ação
            armazenadorDeCurso.Armazenar(_cursoDTO);

            //Verificação
            cursoRepositorioMock.Verify(x => x.Adicionar(It.Is<Curso>(
                 c => c.Nome == _cursoDTO.Nome &&
                 c.Descricao == _cursoDTO.Descricao
                )), Times.AtLeast(1));
        }

    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
    }

    public class ArmazanadorDeCurso
    {
        private ICursoRepositorio _cursoRepositorio;

        public ArmazanadorDeCurso(){}

        public ArmazanadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            this._cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDTO cursoDTO)
        {
            Curso curso = new Curso(cursoDTO.Id, cursoDTO.Nome, cursoDTO.CargaHoraria,
                cursoDTO.PublicoAlvo, cursoDTO.Valor, cursoDTO.Descricao);

            _cursoRepositorio.Adicionar(curso);

        }
    }

    public class CursoDTO
    {
        private int _id;
        private string _nome;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valor;
        private string _descricao;

        public CursoDTO(int id, string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor, string descricao)
        {
            _id = id;
            _nome = nome;
            _cargaHoraria = cargaHoraria;
            _publicoAlvo = publicoAlvo;
            _valor = valor;
            _descricao = descricao;
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


    }
}
