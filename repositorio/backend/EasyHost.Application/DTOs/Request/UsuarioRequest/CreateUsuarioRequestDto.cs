using EasyHost.Domain.Enums;
using System;

namespace EasyHost.Application.DTOs.Request.Usuario
{
    public class CreateUsuarioRequestDto
    {
        public string nome { get;  set; }
        public string cpf { get;  set; }
        public decimal salario { get;  set; }
        public TipoUsuario tipoUsuario { get;  set; }
        public Guid hotelId { get;  set; }
        public string email { get; set; }
        public string senha { get;  set; }
    }
}
