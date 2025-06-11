using EasyHost.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHost.Domain.Entities
{
    public class Usuario
    {
        private Guid _id;
        private string _nome;
        private string _cpf;
        private decimal _salario;
        private bool _ativo;
        private TipoUsuario _tipoUsuario;
        private Guid _hotelId;
        private string _senha;

        public Usuario(string nome, string cpf, decimal salario, bool ativo, TipoUsuario tipoUsuario, Guid hotelId, string senha)
        {
            _id = Guid.NewGuid();
            _nome = nome;
            _cpf = cpf;
            _salario = salario;
            _ativo = ativo;
            _tipoUsuario = tipoUsuario;
            _hotelId = hotelId;
            _senha = senha;
        }

        public void EditarUsuario(string nome, decimal salario, TipoUsuario tipoUsuario)
        {
            //POSSIVEIS EXCEÇÕES
            //if (nome.Count() <= 0)
            //    throw new ArgumentException("Nome inválido");
            //if (salario <= 0)
            //    throw new ArgumentException("Salário inválido");


            _nome = nome;
            _salario = salario;
            _tipoUsuario = tipoUsuario;
        }

        public TipoUsuario GetTipoUsuario()
        {
            return _tipoUsuario;
        }

        public void MudarStatusUsuario(bool ativo)
        {
            _ativo = ativo;
        }


        public void AlterarSenha(string novaSenha)
        {
            if (string.IsNullOrWhiteSpace(novaSenha))
                throw new ArgumentException("Senha não pode ser vazia");

            _senha = novaSenha;
        }
    }
}
