using CursoOnLine.Dominio.Curso;
using CursoOnLine.Dominio.Enumeration;
using System;
using Xunit;
using Moq;

namespace CursoOnLine.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {

        [Fact]
        public void Testar_Deve_Adicionar_Curso()
        {
            //Cenário
            //Biblioteca ExpectedObject
            var cursoDTO = new CursoDTO
            {
                Id = 1,
                Nome = "Ana Maria",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)950,
                Descricao = "Curso Informática"
            };
           
            var cursoRepositorioMock = new Mock<ICursoRepositorio>();
            var armazenadorDeCurso = new ArmazanadorDeCurso(cursoRepositorioMock.Object);
            
            //Ação
            armazenadorDeCurso.Armazenar(cursoDTO);

            //Verificação
            cursoRepositorioMock.Verify(x => x.Adicionar(It.IsAny<Curso>()));
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
