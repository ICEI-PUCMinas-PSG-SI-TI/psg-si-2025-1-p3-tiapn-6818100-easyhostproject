using EasyHost.Domain.Entities;

namespace EasyHost.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void CreateUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void AtualizarUsuarioSenha(Usuario usuario);
        void DeletarUsuario(Guid userId);
        bool HasLogin(string cpf);
        Usuario? GetUserByEmail(string email);
        Usuario? GetUserById(Guid userId);
        IEnumerable<Usuario> GetAllUsuarios();
    }
}
