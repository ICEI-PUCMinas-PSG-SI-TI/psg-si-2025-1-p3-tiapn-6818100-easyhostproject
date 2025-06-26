using EasyHost.Domain.Enums;

namespace EasyHost.Application.DTOs.Response.UsuarioResponse
{
    public class UsuarioDto
    {
        public string _nome { get;  set; }
        public string _cpf { get;  set; }
        public decimal _salario { get;  set; }
        public bool _ativo { get;  set; }
        public TipoUsuario _tipoUsuario { get;  set; }
        public Guid _hotelId { get;  set; }
        public string _email { get; set; }
    }
}
