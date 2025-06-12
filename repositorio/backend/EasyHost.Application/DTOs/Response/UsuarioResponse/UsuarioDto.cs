using EasyHost.Domain.Enums;

namespace EasyHost.Application.DTOs.Response.UsuarioResponse
{
    public class UsuarioDto
    {
        public Guid _id { get; private set; }
        public string _nome { get; private set; }
        public string _cpf { get; private set; }
        public decimal _salario { get; private set; }
        public bool _ativo { get; private set; }
        public TipoUsuario _tipoUsuario { get; private set; }
        public Guid _hotelId { get; private set; }
    }
}
