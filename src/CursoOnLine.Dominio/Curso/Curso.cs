using CursoOnLine.Dominio.Enumeration;
using System;

namespace CursoOnLine.Dominio.Curso
{
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

            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome Inválido");
            }

            if (cargaHoraria < 1)
            {
                throw new ArgumentException("Carga Horária Inválida");
            }

            if (valor < 1)
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

       

        public string DadosCurso()
        {
            return $"[Curso => Id: {this._id} , Nome: {this._nome} , PublicoAlvo: {this._publicoAlvo} , Valor: {this._valor} ]";

        }

    }
}
