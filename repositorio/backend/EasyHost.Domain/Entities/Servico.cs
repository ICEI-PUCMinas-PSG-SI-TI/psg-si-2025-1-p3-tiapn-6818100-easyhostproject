using EasyHost.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHost.Domain.Entities
{
    public class Servico
    {
        private Guid _id;
        private int _reservaId;
        private string _funcionarioResponsavel;
        private string _descricao;
        private StatusServico _statusServico;
        private DateTime _criadoEm;
        private DateTime? _concluidoEm;

        public Servico(int reservaId, string funcionarioResponsavel, string descricao)
        {
            _id = Guid.NewGuid();
            _reservaId = reservaId;
            _funcionarioResponsavel = funcionarioResponsavel;
            _descricao = descricao;
            _statusServico = StatusServico.Pendente;
            _criadoEm = DateTime.Now;
        }

        public void MudarServicoStatus(StatusServico novoStatus)
        {
            _statusServico = novoStatus;

            if (novoStatus == StatusServico.Concluido)
                _concluidoEm = DateTime.Now;
        }

        public void EditarDescServico(string novaDescricao)
        {
            if (string.IsNullOrWhiteSpace(novaDescricao))
                throw new ArgumentException("Descrição inválida");

            _descricao = novaDescricao;
        }
    }

}
