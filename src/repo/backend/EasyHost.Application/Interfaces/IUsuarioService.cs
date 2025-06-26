using EasyHost.Application.DTOs.Request.Usuario;
using EasyHost.Application.DTOs.Request.UsuarioRequest;
using EasyHost.Application.DTOs.Response.UsuarioResponse;


namespace EasyHost.Application.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto CadastrarUsuario(CreateUsuarioRequestDto dto);
        string Login(UsuarioLoginDto dto);
        UsuarioDto AtualizarUsuario(UpdateUsuarioRequestDto dto);
        UsuarioDto GetUsuarioByEmail(string usuarioEmail);
    }
}
