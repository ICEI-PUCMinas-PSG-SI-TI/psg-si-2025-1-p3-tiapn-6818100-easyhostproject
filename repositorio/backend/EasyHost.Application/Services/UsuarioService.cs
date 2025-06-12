using EasyHost.Application.DTOs.Request.Usuario;
using EasyHost.Application.DTOs.Request.UsuarioRequest;
using EasyHost.Application.DTOs.Response.UsuarioResponse;
using EasyHost.Application.Interfaces;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher<Usuario> _hasher;
    private readonly IJwtService  _jwt;


    public UsuarioService(IUsuarioRepository usuarioRepository,  IPasswordHasher<Usuario> hasher, IJwtService jwt)
    {
        _usuarioRepository = usuarioRepository;
        _hasher = hasher;
        _jwt    = jwt;
    }

    public UsuarioDto CadastrarUsuario(CreateUsuarioRequestDto dto)
    {
        var hasLogin = _usuarioRepository.HasLogin(dto.cpf);
        if (hasLogin) throw new ArgumentException("CPF ja em uso");

        Usuario user = new Usuario(dto.nome, dto.cpf, dto.salario, dto.tipoUsuario, dto.hotelId, dto.email, "");
        var hash = _hasher.HashPassword(user, dto.senha);

        user.AlterarSenha(hash);

        _usuarioRepository.CreateUsuario(user);

        var usuarioDto = user.Adapt<UsuarioDto>();

        return usuarioDto;
    }

    public string Login(UsuarioLoginDto dto)
    {
        var user = _usuarioRepository
            .GetUserByEmail(dto.email)
            ?? throw new UnauthorizedAccessException("Email não encontrado");

        var result = _hasher.VerifyHashedPassword(user, user._senha, dto.senha);
        if (result == PasswordVerificationResult.Failed)
            throw new UnauthorizedAccessException("Senha inválida");

        if (result == PasswordVerificationResult.SuccessRehashNeeded)
        {
            var newHash = _hasher.HashPassword(user, dto.senha);
            user.AlterarSenha(newHash);
            _usuarioRepository.AtualizarUsuarioSenha(user);
        }

        return _jwt.GenerateToken(user);
    }
    
    public UsuarioDto AtualizarUsuario(UpdateUsuarioRequestDto dto)
    {
        var user = _usuarioRepository.GetUserById(dto.id)
                      ?? throw new KeyNotFoundException("Usuário não encontrado");

        user.AtualizarUsuario(dto.nome, dto.salario, dto.tipoUsuario, dto.ativo);
        _usuarioRepository.AtualizarUsuario(user);

        return user.Adapt<UsuarioDto>();
    }

    public void MudarSenha(UsuarioChangePasswordDto dto)
    {
        var user = _usuarioRepository.GetUserByEmail(dto.email)
                      ?? throw new KeyNotFoundException("Não tem um usuário com esse email");

        var hash = _hasher.HashPassword(user, dto.newSenha);

        user.AlterarSenha(hash);

        _usuarioRepository.AtualizarUsuarioSenha(user);
    }
}
