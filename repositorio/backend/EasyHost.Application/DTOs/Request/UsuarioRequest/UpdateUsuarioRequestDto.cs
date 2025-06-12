using EasyHost.Domain.Enums;

namespace EasyHost.Application.DTOs.Request.UsuarioRequest
{
    public class UpdateUsuarioRequestDto
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public decimal salario { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        public bool ativo { get; set; }
    }
}
