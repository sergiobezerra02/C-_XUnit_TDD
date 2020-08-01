using CursoOnLine.Dominio.Enumeration;
using CursoOnLine.Dominio.Curso;


namespace CursoOnLine.DominioTest._Builder
{
    public class CursoBuilder
    {
        private int _id = 1;
        private string _nome = "Ana Maria";
        private double _cargaHoraria = 80;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 950;
        private string _descricao = "Curso Informática";

        public static CursoBuilder GetCursoBuilder()
        {
            return new CursoBuilder();
        }


        public CursoBuilder ComId(int id)
        {
            this._id = id;
            return this;
        }

        public CursoBuilder ComNome(string nome)
        {
            this._nome = nome;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            this._cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            this._publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            this._valor = valor;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            this._descricao = descricao;
            return this;
        }


        public Curso Build()
        {
            return new Curso(_id, _nome, _cargaHoraria, _publicoAlvo, _valor, _descricao);
        }


    }
}
