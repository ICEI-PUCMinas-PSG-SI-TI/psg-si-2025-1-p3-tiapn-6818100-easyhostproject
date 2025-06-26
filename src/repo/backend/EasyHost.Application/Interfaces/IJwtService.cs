using EasyHost.Domain.Entities;

public interface IJwtService
{
  string GenerateToken(Usuario user);
}