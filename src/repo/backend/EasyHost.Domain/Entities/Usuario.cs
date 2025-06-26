using EasyHost.Domain.Enums;

namespace EasyHost.Domain.Entities
{
    public class Usuario
    {
        public Guid _id { get; private set;}
        public string _nome { get; private set; }
        public string _cpf { get; private set;}
        public decimal _salario { get; private set; }
        public bool _ativo { get; private set; }
        public TipoUsuario _tipoUsuario { get; private set; }
        public Guid _hotelId { get; private set; }
        public string _email { get; private set; }
        public string _senha { get; private set; }

        public Usuario(string nome, string cpf, decimal salario, TipoUsuario tipoUsuario, Guid hotelId, string email, string senha)
        {
            _id = Guid.NewGuid();
            _nome = nome;
            _cpf = cpf;
            _salario = salario;
            _ativo = true;
            _tipoUsuario = tipoUsuario;
            _hotelId = hotelId;
            _email = email;
            _senha = senha;
        }

        public Usuario() { }

        public void AtualizarUsuario(string nome, decimal salario, TipoUsuario tipoUsuario, bool ativo)
        {
            _nome = nome;
            _salario = salario;
            _tipoUsuario = tipoUsuario;
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
